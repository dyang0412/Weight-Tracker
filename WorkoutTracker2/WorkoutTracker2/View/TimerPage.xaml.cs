using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WorkoutTracker2.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TimerPage : ContentPage
    {
        int mins, secs;
        int resetmins, resetsecs;
        bool paused;
        private Timer timer;
        public TimerPage()
        {
            InitializeComponent();
            mins = 0;
            secs = 0;
            resetmins = 0;
            resetsecs = 0;
            timer = new Timer();
            timer.Interval = 1000;
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;
            
            if(mins == 0 && secs == 0)
            {
                timer.Close();
            }

            paused = true;

            btnStart.Clicked += delegate
            {
                
                setDuration();
                // Timer is Running
                if (!paused)
                {
                    timer.Stop();
                    paused = true;
                    btnStart.Text = "Resume";
                    btnStart.BackgroundColor = Color.LightGreen;
                    btnStart.BorderColor = Color.DarkGreen;
                    btnStart.TextColor = Color.DarkGreen;
                }

                //Timer is Paused
                else
                {
                    if (!btnStart.Text.Equals("Resume"))
                    {
                        resetmins = mins;
                        resetsecs = secs;
                    } 
                    timer.Start();
                    paused = false;
                    btnStart.Text = "Pause";
                    btnStart.BackgroundColor = Color.Firebrick;
                    btnStart.BorderColor = Color.DarkRed;
                    btnStart.TextColor = Color.White;
                }
            };

            btnReset.Clicked += delegate
            {
                timer.Stop();
                mins = resetmins;
                secs = resetsecs;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                btnStart.Text = "Start";
                btnStart.BackgroundColor = Color.LightGreen;
                btnStart.BorderColor = Color.DarkGreen;
                btnStart.TextColor = Color.DarkGreen;
                paused = true;
            };

            btnPlusFive.Clicked += delegate
            {
                secs = secs + 5;
                formatTime();
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btnMinusFive.Clicked += delegate
            {
                if(!(mins == 0 && secs == 0))
                {
                    secs = secs - 5;
                    formatTime();
                    lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                    resetmins = mins;
                    resetsecs = secs;
                }
            };

            btn20.Clicked += delegate
            {
                mins = 0;
                secs = 20;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btn30.Clicked += delegate
            {
                mins = 0;
                secs = 30;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btn45.Clicked += delegate
            {
                mins = 0;
                secs = 45;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btn60.Clicked += delegate
            {
                mins = 1;
                secs = 0;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btn90.Clicked += delegate
            {
                mins = 1;
                secs = 30;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            btn120.Clicked += delegate
            {
                mins = 2;
                secs = 0;
                lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                resetmins = mins;
                resetsecs = secs;
            };

            
        }
        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                if(!(secs < 0 && mins == 0))
                {
                    secs--;
                    if (secs < 0)
                    {
                        mins--;
                        secs = 59;
                    }
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                    });
                }
            }
            finally
            {
                if(secs > 0 && mins < 0)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        mins = resetmins;
                        secs = resetsecs;
                        lbltime.Text = String.Format("{0:00}:{1:00}", mins, secs);
                        Console.WriteLine("Stopping Timer");
                        btnStart.Text = "Start";
                        btnStart.BackgroundColor = Color.LightGreen;
                        btnStart.BorderColor = Color.DarkGreen;
                        btnStart.TextColor = Color.DarkGreen;
                        paused = true;
                    });
                    
                }
                else
                {
                    timer.Start();
                    Console.WriteLine($"Firing Timer:{mins}:{secs}");
                }
            }
            
        }


        private void setDuration()
        {
            string duration = lbltime.Text;
            string[] result;
            result = duration.Split(new char[] { ':' },StringSplitOptions.RemoveEmptyEntries);
            Int32.TryParse(result[0], out mins);
            Int32.TryParse(result[1], out secs);
            formatTime();
        }

        private void formatTime()
        {
            if (secs > 59)
            {
                mins = mins + (secs / 60);
                secs = secs % 60;
            }
            else if (secs < 0)
            {
                mins--;
                secs = 55;
            }
        }

    }
}