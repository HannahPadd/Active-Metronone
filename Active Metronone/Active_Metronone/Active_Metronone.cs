using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Xamarin.Forms;

namespace Active_Metronone
{
    public class App : Application
    {
        Button addbpmButton;
        Button decreasebpmButton;
        Button startCount;
        public Button stop;
        int currentBpm = 50;
        Label bpmCount;
        Metronome metronome;

        public App()
        {
            addbpmButton = new Button
            {
                Text = "+",
                BackgroundColor = Color.Green,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            addbpmButton.Clicked += OnButtonClicked;

            decreasebpmButton = new Button
            {
                Text = "-",
                BackgroundColor = Color.Red,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
            };
            decreasebpmButton.Clicked += OnButtonClicked;

            startCount = new Button
            {
                Text = "Start",
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
            };
            startCount.Clicked += OnButtonClicked;

            stop = new Button
            {
                Text = "Stop",
                BackgroundColor = Color.Black,
                HorizontalOptions = LayoutOptions.Center,
            };

            bpmCount = new Label
            {
                Text = $"Current bpm {currentBpm}",
                HorizontalOptions = LayoutOptions.Center,
            };



            // The root page of your application
            MainPage = new ContentPage
            {
                Content = new StackLayout
                {
                    VerticalOptions = LayoutOptions.Center,
                    Children = {
                        bpmCount,
                        addbpmButton,
                        decreasebpmButton,
                        startCount,
                        stop
                    }
                }
            };
        }

        void OnButtonClicked(object s, EventArgs e)
        {
            if (s == addbpmButton)
            {
                currentBpm += 1;
                bpmCount.Text = String.Format($"Current bpm {currentBpm}", bpmCount);

            }

            if (s == decreasebpmButton)
            {
                currentBpm -= 1;
                bpmCount.Text = String.Format($"Current bpm {currentBpm}", bpmCount);
            }

            if (s == startCount)
            {
                metronome = new Metronome(currentBpm);
                metronome.Start(currentBpm);
            }

            if (s == stop)
            {
                metronome.feedback.Stop();
                metronome.isActive = false;
            }
        }
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
