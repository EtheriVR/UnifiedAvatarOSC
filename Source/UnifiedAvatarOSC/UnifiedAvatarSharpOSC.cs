using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnifiedAvatarOSCBase;
using OSCsharp.Net;
using System.Threading;
using System.Reflection;
using OSCsharp.Data;

namespace UnifiedAvatarOSC
{
    internal class UnifiedAvatarSharpOSC : IUnifiedAvatarOSC, IDisposable
    {
        UDPTransmitter client = null;
        UDPReceiver server = null;

        public delegate void AvatarIdHandler(string avatarId);
        public delegate void RecievedMessageHandler(string address, IList<object> args);

        public event AvatarIdHandler OnAvatarChanged;
        public event RecievedMessageHandler OnOscMessage;


        public UnifiedAvatarSharpOSC(string address, int sendPort, int recieve)
        {
            client = new UDPTransmitter(address, sendPort);
            client.Connect();
            server = new UDPReceiver(recieve,false);
            server.Start();
            server.PacketReceived += Server_PacketReceived;
        }

        private void Server_PacketReceived(object sender, OscPacketReceivedEventArgs e)
        {
            RecievedMessage(e.Packet);
        }

        private void RecievedMessage(OscPacket packet)
        {
            if (packet == null)
                return;
            var messageReceived = (OscMessage)packet;
            if (messageReceived.Address == "/avatar/change")
            {
                OnAvatarChanged?.Invoke(messageReceived.Data[0] as string);
            }

            OnOscMessage?.Invoke(messageReceived.Address, messageReceived.Data);
        }

        public void Dispose()
        {
            server.Stop();
        }

        public void Send(object input, string ParameterAddress, IUnifiedAvatarOSCProvider provider)
        {
            CheckAddress(ref ParameterAddress);

            var message = new OscMessage(ParameterAddress, input);
            client.Send(message);
            Log.Send(ParameterAddress, input.ToString(), provider.ProviderName);
        }

        public void Send(object input, IUnifiedAvatarOSCProvider provider)
        {
            var addresses = provider.GetType().GetCustomAttribute<Parameters>(true).Addresses;
            var address = addresses.FirstOrDefault();

            CheckAddress(ref address);

            var message = new OscMessage(address, input);
            client.Send(message);

            Log.Send(address, input.ToString(), provider.ProviderName);

            if (addresses.Length > 1)
                Log.Msg("Use specific parameter address if you have multiple defined addresses! (Using first)");

        }

        public void SendAbsolutePath(object input, string ParameterAddress, IUnifiedAvatarOSCProvider provider)
        {
            CheckAddress(ref ParameterAddress);
            var message = new OscMessage(ParameterAddress, input);

            client.Send(message);
            Log.Send(ParameterAddress, input.ToString(), provider.ProviderName);
        }

        private void CheckAddress(ref string address)
        {
            if (address.First() != '/')
                address = '/' + address;
        }
    }
}
