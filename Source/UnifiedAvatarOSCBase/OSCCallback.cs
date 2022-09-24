using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedAvatarOSCBase
{
    /// <summary>
    /// Attribute declaring a method as a callback
    /// </summary>
    public class OSCCallback : Attribute
    {
        private string[] addresses;
        public string[] Addresses { get => addresses; }

        /// <summary>
        /// Methods with this attribute will get callbacks with data from the specified addresses
        /// </summary>
        /// <param name="addresses"></param>
        public OSCCallback(params string[] addresses)
        {
            this.addresses = addresses;
        }
    }
}
