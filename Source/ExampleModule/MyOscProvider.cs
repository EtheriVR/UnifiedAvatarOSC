using System;
using System.Collections.Generic;
using System.IO;
using UnifiedAvatarOSCBase;

namespace ExampleModule
{
    [Parameters("CoolParameter", "ParameterAddress", "ParameterAddress2")]
    public class MyOscProvider : IUnifiedAvatarOSCProvider
    {
        public string ProviderName => "MyProviderName";

        public long UpdateRate => 1000; //How many milliseconds between each update

        /// <summary>
        /// Runs when the provider gets loaded by the app
        /// </summary>
        /// <param name="osc"></param>
        public void Intialize(IUnifiedAvatarOSC osc)
        {
            osc.Send("This is data!", "Avatar/Params/Address", this);
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
        
        [OSCCallback("ParameterAddress","ParameterAddress2")]
        private void MyReceivingMethod(string address,IList<object> data)
        {
            Console.WriteLine("{0} Got Message: {1}", address,data[0].ToString());
            Log.Msg("The log also likes messages: " + data[0].ToString());

        }

        public void Update(IUnifiedAvatarOSC osc, float deltaTime)
        {
            //Send a cool value to the declared address
            osc.Send(1337.0f, this);
        }
    }
}
