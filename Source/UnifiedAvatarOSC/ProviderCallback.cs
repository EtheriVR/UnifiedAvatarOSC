using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedAvatarOSC
{
    internal class ProviderCallback
    {
        private MethodInfo method;
        private string[] callbacks;
        public MethodInfo Method { get => method; }
        public string[] Callbacks { get => callbacks; }

        public ProviderCallback(MethodInfo method, string[] callbacks)
        {
            this.method = method;
            this.callbacks = callbacks;
        }
    }
}
