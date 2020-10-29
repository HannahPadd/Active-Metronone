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
        Thread thread;

        public Metronome(int BPM)
        {
            this.bpm = BPM;
            thread = new Thread(this.Run);
        }
        
        public void Start()
        {
            if (!isActive)
            {
                isActive = true;
                thread.Start();
            }
        }
        

        //Function in which the metronome runs
        public void Run()
        {
            //bool res = feedback.IsSupportedPattern(FeedbackType.Vibration, "Message");

            while (isActive) {
                int timeInterval = 60000 / bpm;

                //Wait for next tick
                Thread.Sleep(timeInterval);

                //Tick
                feedback.Play(FeedbackType.Sound, "SilentModeDisabled"); 
                feedback.Play(FeedbackType.Vibration, "VibrationModeAbled");

                //feedback.Stop();
            }
        }

        public void Stop()
        {
            isActive = false;
        }

        public void setBpm(int bpm)
        {
            this.bpm = bpm;
        }

    }
}


