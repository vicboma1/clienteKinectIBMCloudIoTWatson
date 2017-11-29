using IBMWIoTP;
using Microsoft.Samples.Kinect.BodyBasics.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace Microsoft.Samples.Kinect.BodyIndexBasics
{
    public class IotConnection
    {
        private DeviceClient client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="clientID"></param>
        /// <param name="user"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static async Task<IotConnection> Create(JsonProperties jsonProperties)
        {
            return (await new IotConnection().Initialize(jsonProperties)); 
        }


        IotConnection() { }

        private async Task<IotConnection> Initialize(JsonProperties jsonProperties)
        {
            this.client = new DeviceClient(jsonProperties.ORG_ID, jsonProperties.DEVICE_TYPE, jsonProperties.DEVICE_ID, jsonProperties.AUTH_TOKEN, jsonProperties.TOKEN_KEY); //default port 1883
            await Task.Delay(10);
            return this;
        }

        public IotConnection Connect()
        {
            try
            {
                this.Close();
                this.client.connect();
            }catch(Exception e)
            {
                System.Diagnostics.Debug.Print(e.StackTrace);
            }

            return this;

        }

        public IotConnection Publish(string evt, string format, string msg)
        {
            if(this.client.isConnected())
                this.client.publishEvent(evt, format, msg);

            return this;
        }

        public void Close()
        {
            if (this.client.isConnected())
                this.client.disconnect();
        }
    }
}
