using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace SimulationDeviceMQTT
{
    class Publisher
    {
        public static int varclass = 0;

        public Publisher()  
        {

        }


        public Publisher(int tenta)
        {
            string idDevice = "raspberry";
            MqttClient client = new MqttClient("10.154.128.153");
            client.Connect(Guid.NewGuid().ToString());
            client.Publish("device/command/", Encoding.UTF8.GetBytes("{\"name\":\"humiditySensor_wealthy-snails\",\"macAddress\":\"44:81:C0:0D:6C:E3\",\"deviceType\":\"humiditySensor\",\"metricValue\":\"0\"}"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);
           // client.Publish("device/" + idDevice + "/telemetry/", Encoding.UTF8.GetBytes("{\"name\":\"humiditySensor_wealthy-snails\",\"macAddress\":\"44:81:C0:0D:6C:E3\",\"deviceType\":\"humiditySensor\",\"metricValue\":\"0\"}"), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);
            Thread.Sleep(TimeSpan.FromSeconds(1));
            client.Disconnect();
            Console.WriteLine(tenta);

        }




        //client.Publish("device/telemetry", Encoding.UTF8.GetBytes("Hello, I'm a new pickle rick :" + tenta), MqttMsgBase.QOS_LEVEL_AT_MOST_ONCE, true);
        //client.MqttMsgPublished += client_MqttMsgPublished;
        //Thread.Sleep(TimeSpan.FromMilliseconds(10));




        void client_MqttMsgPublished(object sender, MqttMsgPublishedEventArgs e)
        {
            MqttClient client = (MqttClient)sender;

            Debug.WriteLine("MessageId = " + e.MessageId + " Published = " + e.IsPublished);
            if (e.IsPublished)
            {
                client.Disconnect();
                Console.WriteLine("Connection Closed");

            }


        }




    }
}

