using System;
using System.Collections.Generic;
using System.IO;
using UnifiedAvatarOSCBase;

namespace ExampleModule
{
    [Parameters(TestAddress1, TestAddress2, TestCallbackParameter, TestCallbackParameter2)]
    public class MyOscProvider : IUnifiedAvatarOSCProvider
    {
        public const string TestAddress1 = "/avatar/parameters/ExampleModule/TestParam";
        public const string TestAddress2 = "/avatar/parameters/ExampleModule/TestParam2";

        public const string TestCallbackParameter = "/avatar/parameters/ExampleModule/ExampleCallback";
        public const string TestCallbackParameter2 = "/avatar/parameters/ExampleModule/ExampleCallback2";

        public string ProviderName => "MyProviderName";

        public long UpdateRate => 1000; //How many milliseconds between each update

        /// <summary>
        /// Runs when the provider gets loaded by the app
        /// </summary>
        /// <param name="osc"></param>
        public void Initialize(IUnifiedAvatarOSC osc)
        {
            osc.Send("This is data!", TestAddress2, this);
        }

        /// <summary>
        /// Runs when the provider gets unloaded by the app
        /// </summary>
        public void Uninitialize()
        {
        }

        /// <summary>
        /// This is a callback for osc messages
        /// </summary>
        /// <param name="address">the address the message was sent to</param>
        /// <param name="data">the data provided</param>
        
        [OSCCallback(TestCallbackParameter, TestCallbackParameter2)]
        private void MyReceivingMethod(string address,IList<object> data)
        {
            Console.WriteLine("{0} Got Message: {1}", address,data[0].ToString());
            Log.Msg("The log also likes messages: " + data[0].ToString());

        }

        public void Update(IUnifiedAvatarOSC osc, float deltaTime)
        {
            //Send a cool value to the first declared address
            osc.Send(1337.0f, TestAddress1, this);
        }
    }
}
