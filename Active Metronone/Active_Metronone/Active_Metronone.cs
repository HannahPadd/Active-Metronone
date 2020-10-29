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
            metronome = new Metronome(currentBpm);

            //The buttons get created here
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
            stop.Clicked += OnButtonClicked;

            bpmCount = new Label
            {
                Text = $"Current bpm {currentBpm}",
                HorizontalOptions = LayoutOptions.Center,
            };



            // The root page of the application (this application only has 1 page)
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

        //Method that gets called when someone presses on a button
        void OnButtonClicked(object s, EventArgs e)
        {
            if (s == addbpmButton)
            {
                currentBpm += 1;
                bpmCount.Text = String.Format($"Current bpm {currentBpm}", bpmCount);

                metronome.setBpm(currentBpm);

            }

            if (s == decreasebpmButton)
            {
                currentBpm -= 1;
                bpmCount.Text = String.Format($"Current bpm {currentBpm}", bpmCount);

                metronome.setBpm(currentBpm);
            }

            if (s == startCount)
            {
                metronome.Start();
            }

            if (s == stop)
            {
                metronome.Stop();
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
