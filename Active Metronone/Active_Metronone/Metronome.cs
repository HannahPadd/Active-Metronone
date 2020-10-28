using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Xamarin.Forms.PlatformConfiguration;
using Tizen.System;
using ElmSharp;
using System.Threading.Tasks;

namespace Active_Metronone {
    class Metronome {

        int bpm;
        public bool isActive = false;
        public Feedback feedback = new Feedback();
        App app = new App();
    

        public Metronome(int BPM)
        {
            this.bpm = BPM;
        }

        //Function in which the metronome runs
         public void Start(int bpm)
         {
            bool res = feedback.IsSupportedPattern(FeedbackType.Vibration, "Message");
            int timeInterval = 60000 / bpm;
            isActive = true;

            while (isActive && res) {
                WaitTime(timeInterval);
            }
        }

        //Function which counts for the metronome
        public async void WaitTime(int timeInterval)
        {
            await Task.Delay(timeInterval);
            feedback.Play(FeedbackType.Sound, "Tap");
            feedback.Stop();
        }

    }
}


