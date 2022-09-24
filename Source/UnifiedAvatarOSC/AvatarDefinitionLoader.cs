using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UnifiedAvatarOSCBase;

namespace UnifiedAvatarOSC
{
    public class AvatarDefinitionLoader
    {
        private static AvatarDefinitionLoader instance;

        AvatarDescriptor avatarDescriptor;
        public AvatarDescriptor CurrentAvatarDescriptor { get => avatarDescriptor; }

        public static AvatarDefinitionLoader Instance
        {
            get
            {
                if (instance == null)
                    instance = new AvatarDefinitionLoader();

                return instance;
            }
        }

        public void LoadDescription(string avatarId)
        {
            string oscFolderPath =
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", @"LocalLow\VRChat\VRChat\OSC\");

            var directory = new DirectoryInfo(oscFolderPath);
            
            var descriptors = directory.GetFiles("*.json", SearchOption.AllDirectories);
            if (avatarId == "")
                return;

            foreach (var descriptor in descriptors)
            {
                if (descriptor.Name.Contains(avatarId))
                {
                    string data = File.ReadAllText(descriptor.FullName);
                    avatarDescriptor = JsonConvert.DeserializeObject<AvatarDescriptor>(data);
                    Console.WriteLine("Avatar descriptor found: " + avatarDescriptor?.Name);
                    Log.Msg("Loaded avatar: " + avatarDescriptor?.Name);
                }
            }
        }
    }
}
