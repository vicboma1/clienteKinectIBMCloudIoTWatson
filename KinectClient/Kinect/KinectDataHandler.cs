using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Kinect;
using System.IO;
using System.Globalization;

namespace Microsoft.Samples.Kinect.BodyBasics
{

    public class KinectDataHandler
    {
        private JsonAdapterKinect jsonAdapterKinect;

        public async static Task<KinectDataHandler> Create()
        {
            return (await new KinectDataHandler().Initialize());
        }

        public KinectDataHandler()
        {
            jsonAdapterKinect = JsonAdapterKinect.Create();

        }

        private async Task<KinectDataHandler> Initialize()
        {
            await Task.Delay(50);
            return this;
        }



        /// <summary>
        /// Creates the JSON message from the bodies information and calls sendData
        /// </summary>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public string ParseBodiesJson(Body[] bodies, int packetID)
        {
            var users = createNewKinect(bodies);
            return users.Count == 0 
                ? JsonAdapterKinect.EMPTY 
                : jsonAdapterKinect.ToJsonString(users, packetID);
        }

        /// <summary>
        /// Creates the JSON message from the bodies information and calls sendData
        /// </summary>
        /// <param name="bodies"></param>
        /// <returns></returns>
        public Boolean IsParseBodiesJson(Body[] bodies)
        {
            return IsCreateNewKinect(bodies); 
        }

        private Boolean IsCreateNewKinect(Body[] bodies)
        {
            var length = bodies.Length;
            for (int i = 0; i< length; i++)
            {
                var body = bodies[i];
                if (!body.IsTracked)
                    continue;

                return true;
            }

            return false;
        }

        private List<KinectUser> createNewKinect(Body[] bodies)
        {
            var users = new List<KinectUser>();

            var length = bodies.Length;
            for (int i = 0; i < length; i++)
            {
                var body = bodies[i];
                if (!body.IsTracked)
                    continue;

                var kinectuser = KinectUser.Create(body);
                users.Add(kinectuser);
            }

            return users;
        }

    }
}
