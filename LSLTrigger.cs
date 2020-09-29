using System;
using LSL;

namespace TriggerLogger
{

    public class LSLTrigger
    {

        liblsl.StreamOutlet outl;

        public LSLTrigger()
        {
            var outLayer = StartStream();
            SetOutLayer(outLayer);
        }


        public void SetOutLayer(liblsl.StreamOutlet outLayer)
        {
            this.outl = outLayer;
        }


        public liblsl.StreamOutlet StartStream()

        {
            // liblsl.StreamInfo inf = new liblsl.StreamInfo("eyeLink_trigger", "Markers", 1, 0, liblsl.channel_format_t.cf_int32, "stim_triggers");
            liblsl.StreamInfo inf = new liblsl.StreamInfo("hardwareTest_trigger", "Markers", 1, 1, liblsl.channel_format_t.cf_float32, "sddsfsdf");
            liblsl.StreamOutlet outl = new liblsl.StreamOutlet(inf);
            return outl;
        }


        public void SendMark(int[] mark)
        {
            Console.WriteLine("Sending Mark: " + mark[0]);
            outl.push_sample(mark);
        }
    }   
}
