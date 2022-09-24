using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnifiedAvatarOSCBase
{
    public interface IUnifiedAvatarOSC
    {
        void Send(object input, IUnifiedAvatarOSCProvider provider);
        void Send(object input, string ParameterAddress, IUnifiedAvatarOSCProvider provider);
        void SendAbsolutePath(object input, string ParameterAddress, IUnifiedAvatarOSCProvider provider);
    }
}
