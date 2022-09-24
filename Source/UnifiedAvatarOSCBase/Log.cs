using System;
using System.Collections.Concurrent;

namespace UnifiedAvatarOSCBase
{
    public struct SendLog
    {
        public string address;
        public string data;
        public string module;
    }

    public class Log
    {
        public ConcurrentQueue<string> MessageQueue { get => msgQueue; }
        public ConcurrentQueue<SendLog> OscSendQueue { get => sendQueue; }

        ConcurrentQueue<string> msgQueue = new ConcurrentQueue<string>();
        ConcurrentQueue<SendLog> sendQueue = new ConcurrentQueue<SendLog>();

        static Log instance;

        public static Log Instance
        {
            get
            {
                if (instance == null)
                    instance = new Log();
                return instance;
            }
        }

        public static void Send(string address,string data,string module)
        {
            instance?.sendQueue.Enqueue(new SendLog(){ address = address, data = data, module = module });
            Console.WriteLine(address + data + module);
        }

        public static void Msg(string message)
        {
            instance?.msgQueue.Enqueue(message);
            Console.WriteLine(message);
        }
    }
}
