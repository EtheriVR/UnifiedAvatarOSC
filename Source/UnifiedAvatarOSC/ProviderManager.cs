using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UnifiedAvatarOSCBase;

namespace UnifiedAvatarOSC
{
    internal class ProviderManager
    {
        
        public List<Provider> AllProviders { get => allProviders; }

        public bool LoadsAllIfNull = true;

        private List<Provider> allProviders = new List<Provider>();

        private Stopwatch time = Stopwatch.StartNew();

        private bool providersLoaded = false;

        public void LoadProviders()
        {
            var directory = new DirectoryInfo(Directory.GetCurrentDirectory() + "/Modules");

            if (directory.Exists == false)
                directory.Create();

            var modules = directory.GetFiles("*.dll", SearchOption.AllDirectories);
            
            foreach (var file in modules)
            {
                var DLL = Assembly.LoadFile(file.FullName);
                foreach (Type type in DLL.GetExportedTypes())
                {
                    var isProvider = type.GetInterfaces().Contains(typeof(IUnifiedAvatarOSCProvider));

                    if (isProvider)
                    {
                        var c = Activator.CreateInstance(type) as IUnifiedAvatarOSCProvider;

                        var methods = c.GetType()
                            .GetMethods()
                            .Where(m => m.GetCustomAttributes(true)
                            .Any(a => a.GetType() == typeof(OSCCallback)));

                        Parameters parameters =  c.GetType().GetCustomAttribute<Parameters>(true);
                        
                        if (parameters != null)
                        {
                            List<ProviderCallback> callbackList = new List<ProviderCallback>();
                            if (methods.Any())
                            {
                                foreach (var method in methods)
                                {
                                    var callbacks = method.GetCustomAttributes(true)
                                        .Where(a => a.GetType() == typeof(OSCCallback))
                                        .Cast<OSCCallback>()
                                        .ToList();

                                    if (callbacks.Any())
                                    {
                                        var callbackStrings = callbacks.SelectMany(p => p.Addresses).Distinct().ToArray();
                                        callbackList.Add(new ProviderCallback(method, callbackStrings));
                                    }
                                }
                            }

                            allProviders.Add(new Provider(c, parameters.Addresses,callbackList));
                            Log.Msg("Loaded provider: " + c.ProviderName);
                        }
                        else
                        {
                            Log.Msg("Ignored provider: " + type.Name);
                        }
                    }
                }
            }
            providersLoaded = true;
        }

        public void AvatarChanged(string avatarId, IUnifiedAvatarOSC osc)
        {
            AvatarDefinitionLoader.Instance.LoadDescription(avatarId);
            var currentAvatar = AvatarDefinitionLoader.Instance.CurrentAvatarDescriptor;
            if (currentAvatar == null)
            {
                if (LoadsAllIfNull)
                {
                    AllProviders.Where(p => p.IsActive == false).ToList().ForEach(p => p.Activate(osc));
                    return;
                }
                else
                {
                    AllProviders.Where(p => p.IsActive == true).ToList().ForEach(p => p.Deactivate());
                    return;
                }
            }

            var avyParms = currentAvatar.Parameters.Select(p => p.Name);

            foreach (var provider in AllProviders)
            {
                bool hasParam = false;
                foreach (var avyP in avyParms)
                {
                    if (provider.Addresses.Any(a => avyP.Contains(a)))
                    {
                        hasParam = true;
                    }
                }

                if(hasParam)
                {
                    if (provider.IsActive == false)
                        provider.Activate(osc);
                }
                else
                {
                    if (provider.IsActive)
                        provider.Deactivate();
                }
            }
        }

        public void Update(IUnifiedAvatarOSC osc)
        {
            foreach(var provider in allProviders.Where(p => p.IsActive))
            {
                long elapsed = time.ElapsedMilliseconds;
                long deltaTime = elapsed - provider.LastUpdate;

                if (deltaTime > provider.OSCProvider.UpdateRate)
                {
                    provider.OSCProvider.Update(osc, deltaTime/1000.0f);
                    provider.LastUpdate = elapsed;
                }
            }
        } 

        public void PushMessage(string address,IList<object> arguments)
        {
            if (providersLoaded == false)
                return;

            foreach (var provider in allProviders.Where(p => p.IsActive))
            {
                provider
                    .Callbacks
                    .Where(p => p.Callbacks.Contains(address) ||
                            p.Callbacks.Contains(address.Split('/').Last())).ToList().ForEach(c =>
                {
                    object[] args = { address, arguments };
                    c.Method.Invoke(provider.OSCProvider, args);
                });
            }
        }

    }
}
