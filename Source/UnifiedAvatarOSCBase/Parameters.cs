using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedAvatarOSCBase
{
    /// <summary>
    /// Attribute declaring parameters that a module provides
    /// </summary>
    public class Parameters : Attribute
    {
        private string[] addresses;
        public string[] Addresses { get => addresses; }

        /// <summary>
        /// Provide addresses to register your modules
        /// </summary>
        /// <param name="addresses"></param>
        public Parameters(params string[] addresses)
        {
            this.addresses = addresses;
        }
    }
}
