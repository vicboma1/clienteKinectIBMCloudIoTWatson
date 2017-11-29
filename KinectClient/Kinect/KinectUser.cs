using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    public class KinectUser
    {
        /// <summary>
        /// Unique id of the body
        /// </summary>
        public ulong id { get; set; }
        /// <summary>
        /// List of body parts
        /// </summary>
        public List<KinectBodyPart> bodyParts { get; set; }
        /// <summary>
        /// True when the left hand is closed
        /// </summary>
        public string leftHandState { get; set; }
        /// <summary>
        /// True when the right hand is closed
        /// </summary>
        public string rightHandState { get; set; }

       
        public static KinectUser Create(Body b)
        {
            return new KinectUser().Initialize(b);
        }

        KinectUser() { }

        public KinectUser Initialize(Body b)
        {

            id = b.TrackingId;
            bodyParts = new List<KinectBodyPart>();
            
            leftHandState = b.HandLeftState.ToString();
            rightHandState = b.HandRightState.ToString();

            foreach (var j in b?.Joints?.Values)
            {
                var part = KinectBodyPart.Create(j);
                bodyParts.Add(part);
            }

            return this;
        }
    }

}
