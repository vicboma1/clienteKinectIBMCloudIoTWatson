using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyBasics
{
    public class KinectBodyPart
    {
        /// <summary>
        /// Name of the body part
        /// </summary>
        public string name;
        /// <summary>
        /// Indicates if a position has been calculated
        /// </summary>
        public bool present;
        /// <summary>
        /// Indictes if the body part is tracked, this means that the sensor has recognized this body part so its position is not infered
        /// </summary>
        public bool tracked;
        /// <summary>
        /// 3D position of the body part
        /// </summary>
        public float[] position;

        public static KinectBodyPart Create(Joint k)
        {
            return new KinectBodyPart().Initialize(k);
        }

        KinectBodyPart()
        {

        }


        private KinectBodyPart Initialize(Joint k)
        {
            this.name = string.Empty;
            this.position = new float[] { 0, 0, 0 };

            this.JointBodyPart(k);

            return this;
        }

        private void JointBodyPart(Joint j)
        {
            name = Enum.GetName(typeof(JointType), j.JointType);

            present = (j.TrackingState != TrackingState.NotTracked);
            tracked = (j.TrackingState == TrackingState.Tracked);

            if (present)
            {
                position = new float[]
                {
                    j.Position.X,
                    j.Position.Y,
                    j.Position.Z
                };
            }

        }
    }
}
