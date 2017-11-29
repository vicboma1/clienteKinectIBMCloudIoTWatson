using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyBasics
{

    public class JsonAdapterKinect
    {
        private const string PACKET_ID = "packetID";
        private const string USER_ID = "userId";
        private const string USER = "user";
        private const string ID = "id";
        private const string LEFT_HAND_STATE = "leftHandState";
        private const string RIGTH_HAND_STATE = "rightHandState";
        private const string BODY_PARTS = "bodyParts";
        private const string NAME = "name";
        private const string IS_PRESENT = "isPresent";
        private const string IS_TRACKED = "isTracked";
        private const string POSITIONS = "positions";
        private const string ERROR_EN_LAS_COORDENADAS_LEIDAS = "Error en las coordedanas leídas";
        public static String EMPTY = "[]";
        private string [] AXIS = { "x", "y", "z" };


        public static JsonAdapterKinect Create()
        {
            return new JsonAdapterKinect();
        }

        JsonAdapterKinect()
        {

        }

        public String ToJsonString(List<KinectUser> users, int packetID)
        {
            var sb = new StringBuilder();
            var jw = new JsonTextWriter(new StringWriter(sb)) {
                Formatting = Formatting.Indented
            };

            jw.WriteStartObject();

            this.PacketID(packetID, jw);
            this.Users(users, jw);

            jw.WriteEndObject();

            return sb.ToString();
        }

        private void Users(List<KinectUser> users, JsonTextWriter jw)
        {
            jw.WritePropertyName(USER);
            jw.WriteStartArray();

            this.Properties(users, jw);

            jw.WriteEndArray();
        }

        private void Properties(List<KinectUser> users, JsonTextWriter jw)
        {
            foreach (var user in users)
            {
                jw.WriteStartObject();

                ToPairKeyValue(jw, ID, user.id);
                ToPairKeyValue(jw, LEFT_HAND_STATE, user.leftHandState);
                ToPairKeyValue(jw, RIGTH_HAND_STATE, user.rightHandState);
                ToPairKeyValue(jw, USER_ID, string.Empty);

                this.BodyPartsProperties(jw, user);
            }
        }

        private void BodyPartsProperties(JsonTextWriter jw, KinectUser user)
        {
            jw.WritePropertyName(BODY_PARTS);
            jw.WriteStartArray();

            foreach (var bodyParts in user.bodyParts)
            {
                jw.WriteStartObject();

                ToPairKeyValue(jw, NAME, bodyParts.name);
                ToPairKeyValue(jw, IS_PRESENT, bodyParts.present);
                ToPairKeyValue(jw, IS_TRACKED, bodyParts.tracked);

                this.BodyPartsPosititons(jw, bodyParts);

                jw.WriteEndObject();
            }

            jw.WriteEndArray();
            jw.WriteEndObject();
        }

        private void BodyPartsPosititons(JsonTextWriter jw, KinectBodyPart bodyParts)
        {
            jw.WritePropertyName(POSITIONS);
            jw.WriteStartArray();

            jw.WriteStartObject();

            var size = bodyParts.position.Length;
            if (size != AXIS.Length)
                throw new Exception(ERROR_EN_LAS_COORDENADAS_LEIDAS);

            for (int i = 0; i < size; i++)
            {
                ToPairKeyValue(jw, AXIS[i], bodyParts.position[i]);
            }

            jw.WriteEndObject();
            jw.WriteEndArray();
        }

        private void PacketID(int packetID, JsonTextWriter jw)
        {
            ToPairKeyValue(jw, PACKET_ID, packetID);
        }

        private static void ToPairKeyValue(JsonTextWriter jw, String key, object value)
        {
            jw.WritePropertyName(key);
            jw.WriteValue(value);
        }
    }
}
