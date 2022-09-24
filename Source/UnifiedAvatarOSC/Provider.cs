using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAvatarOSCBase;

namespace UnifiedAvatarOSC
{
    internal class Provider
    {
        private IUnifiedAvatarOSCProvider provider;
        private long lastUpdate;
        private string[] addresses;
        private List<ProviderCallback> callbacks;
        private bool active = false;

        public IUnifiedAvatarOSCProvider OSCProvider { get => provider; }
        public long LastUpdate { get => lastUpdate; set => lastUpdate = value; }
        public string[] Addresses { get => addresses; }
        public List<ProviderCallback> Callbacks { get => callbacks; }
        public bool IsActive { get => active; }

        public Provider(IUnifiedAvatarOSCProvider provider, string[] addresses,List<ProviderCallback> callbacks)
        {
            this.provider = provider;
            this.addresses = addresses;
            this.callbacks = callbacks;

            active = false;
            LastUpdate = 0;
        }

        public void Activate(IUnifiedAvatarOSC osc)
        {
            provider.Intialize(osc);
            active = true;
        }

        public void Deactivate()
        {
            provider.Uninitialize();
            active = false;
        }
    }
}
