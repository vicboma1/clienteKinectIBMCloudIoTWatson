using Microsoft.Kinect;
using Microsoft.Samples.Kinect.BodyBasics;
using Microsoft.Samples.Kinect.BodyBasics.Json;
using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Samples.Kinect.BodyIndexBasics
{
    public class IoTConnectionQueue
    {
        private volatile int PACKET_POST_ID = 0;

        private volatile bool threadStop;
        private Thread thread;

        private ConcurrentQueue<Body[]> queue;

        public static async Task<IoTConnectionQueue> Create(IotConnection connection, KinectDataHandler kinectDataHandler)
        {
            return (await new IoTConnectionQueue().Initialize(connection, kinectDataHandler));
        }


        IoTConnectionQueue() {
            threadStop = false;
        }

        private async Task<IoTConnectionQueue> Initialize(IotConnection connection, KinectDataHandler kinectDataHandler)
        {
            queue = new ConcurrentQueue<Body[]>();

            thread = new Thread(async () =>
            {
                while (!threadStop)
                {
                    while (!this.queue.IsEmpty)
                    {
                        var bodies = default(Body[]);
                        this.queue.TryDequeue(out bodies);

                        var packet_id = IncrementAndGetPacket();
                        var resJson = kinectDataHandler.ParseBodiesJson(bodies, packet_id);

                        if (resJson.ToString() != JsonAdapterKinect.EMPTY)
                        {
                            try
                            {
                                var result = connection.Publish(JsonProperties.EVENT, JsonProperties.FORMAT_JSON, resJson);
                                if (result == null)
                                    System.Diagnostics.Debug.Print("Error en la publicación " + resJson);
                            }
                            catch (Exception ee)
                            {
                                System.Diagnostics.Debug.Print("Error: "+ee.Message);
                            }
                            finally
                            {
                               if(packet_id % 100 == 0)
                                 System.Diagnostics.Debug.Print("Packet id: " + packet_id);
                            }
                        }
                        else
                            this.DecrementPacket();
                    }

                    await Task.Delay(50);
                }

            });

            thread.Start();

            await Task.Delay(1);

            return this;
        }

        private static int count = 0;

        public void Enqueue(Body[] bodies)
        {
            queue.Enqueue(bodies);
            //System.Diagnostics.Debug.Print("Enqueue " + (++count));
        }

        public void Close()
        {
            threadStop = true;
        }
       
        public int IncrementAndGetPacket()
        {
            //int.MaxValue = 2147483647 / ( 60packets/s * 60m * 60h) = 8 Horas y media
            if (int.MaxValue - 1 <= PACKET_POST_ID)
                Interlocked.Exchange(ref PACKET_POST_ID, 0);

            return Interlocked.Increment(ref PACKET_POST_ID);
        }

        public int DecrementPacket()
        {
            if (PACKET_POST_ID < 0)
                Interlocked.Exchange(ref PACKET_POST_ID, 0);

            return Interlocked.Decrement(ref PACKET_POST_ID);
        }
    }
}
