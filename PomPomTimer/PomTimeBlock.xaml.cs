using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Toolkit.Uwp.Notifications;
using Windows.UI.Notifications;
using System.Drawing;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace PomPomTimer
{
    public sealed partial class PomTimeBlock : UserControl
    {
        DispatcherTimer dispatcherTimer;
        ToastContent toastContent;
        ToastContent toastBreakTimeContent;

        private int pomsDone = 0;
        public double shortBreakTime = 2.5;
        public double workTime = 5.0;

        private bool shortBreak = false;
        private bool done = false;

        private string ShortBreakIcon = "\uEC32";
        private string pomodoroFilledDotIcon = "\uEA3B";
        private string playIcon = "\uE768";
        private string pauseIcon = "\uE769";
        private string restartIcon = "\uEC57";
        private string finishedIcon = "\uE8FB";

        public bool wasRightTapped = false;

        public object parentReference;

        public void SetTaskTime(int value)
        {
            TimerValueBar.Maximum = value;
            workTime = value;
        }

        public void SetBreakTime(int value)
        {
            shortBreakTime = value;
        }

        public PomTimeBlock()
        {
            this.InitializeComponent();

            toastContent = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Time for a Break!"
                            },
                            new AdaptiveText()
                            {
                                Text = "You've completed a Pomodoro, take some time to relax."
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                {
                    new ToastButton("Take Break", "button"),
                    new ToastButton("Dismiss", "dismiss")
                    {
                        ActivationType = ToastActivationType.Background
                    }
                }
                },
                Launch = "action=viewAlarm&alarmId=3",
                Scenario = ToastScenario.Alarm
            };

            toastBreakTimeContent = new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText()
                            {
                                Text = "Get Set... Go!"
                            },
                            new AdaptiveText()
                            {
                                Text = "Your break time's over, are you ready to get back to it?"
                            }
                        }
                    }
                },
                Actions = new ToastActionsCustom()
                {
                    Buttons =
                {
                    new ToastButton("I'm Ready", "button"),
                    new ToastButton("Dismiss", "dismiss")
                    {
                        ActivationType = ToastActivationType.Background
                    }
                }
                },
                Launch = "action=viewAlarm&alarmId=3",
                Scenario = ToastScenario.Alarm
            };
        }

        public static readonly DependencyProperty DiscriptionProperty = DependencyProperty.Register( "Discription", typeof(string), typeof(PomTimeBlock), null );

        public string Discription
        {
            get { return (string)GetValue(DiscriptionProperty); }
            set { DiscriptionBlock.Text = value as string; }
        }

        public static readonly DependencyProperty TimerValueProperty = DependencyProperty.Register("TimerValue", typeof(double), typeof(PomTimeBlock), null);

        public double TimerValue
        {
            get { return (double)GetValue(TimerValueProperty); }
            set { TimerValueBar.Value = value;  }
        }

        public void SetPomBlockState(string mode)
        {

        }
        
        public void StartTimers()
        {
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);

            dispatcherTimer.Start();
        }

        private void SendNotification()
        {
            var toastNotif = new ToastNotification(toastContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toastNotif);

            TimerValueBar.Value = 0;
            PlayPauseTimerSymbol.Glyph = ShortBreakIcon;
            dispatcherTimer.Stop();

            pomsDone++;

            if (pomsDone == 1)
                PomOne.Glyph = pomodoroFilledDotIcon;
            else if(pomsDone == 2)
                PomTwo.Glyph = pomodoroFilledDotIcon;
            else if (pomsDone == 3)
                PomThree.Glyph = pomodoroFilledDotIcon;
            else
                PomFour.Glyph = pomodoroFilledDotIcon;
        }

        private void SendBreakNotification()
        {
            var toastNotif = new ToastNotification(toastBreakTimeContent.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toastNotif);
        }

        // callback runs on UI thread
        void dispatcherTimer_Tick(object sender, object e)
        {
            // execute repeating task here
            TimerValueBar.Value += dispatcherTimer.Interval.TotalSeconds;

            if(TimerValueBar.Value >= TimerValueBar.Maximum && !shortBreak)
            {
                shortBreak = true;
                SendNotification();
            }
            else if(TimerValueBar.Value >= TimerValueBar.Maximum && shortBreak)
            {
                //send a different reminder
                PomButton.IsEnabled = true;
                TimerValueBar.Value = 0;
                dispatcherTimer.Stop();

                SendBreakNotification();

                if (pomsDone >= 4)
                {
                    pomsDone += 1;
                }
            }
        }

        private void DisablePomodoroTask()
        {
            done = true;
            MarkAsButton.Icon = new SymbolIcon(Symbol.Play);
            MarkAsButton.Text = "Enable Pomodoro";

            Windows.UI.Color color = new Windows.UI.Color();
            color.A = 0;
            root.Background = new SolidColorBrush(color);
            root.BorderThickness = new Thickness(1);

            Windows.UI.Color borderColor = new Windows.UI.Color();
            borderColor.A = Color.White.A;
            borderColor.R = Color.White.R;
            borderColor.G = Color.White.G;
            borderColor.B = Color.White.B;
            root.BorderBrush = new SolidColorBrush(borderColor);

            TimerValueBar.Visibility = Visibility.Collapsed;
            PomOne.Foreground = new SolidColorBrush(borderColor);
            PomTwo.Foreground = new SolidColorBrush(borderColor);
            PomThree.Foreground = new SolidColorBrush(borderColor);
            PomFour.Foreground = new SolidColorBrush(borderColor);
            DiscriptionBlock.Foreground = new SolidColorBrush(borderColor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!done && PomButton.IsEnabled)
            {
                if (!shortBreak)
                {
                    if (PlayPauseTimerSymbol.Glyph == playIcon)
                    {
                        PlayPauseTimerSymbol.Glyph = pauseIcon;
                        StartTimers();
                    }
                    else
                    {
                        PlayPauseTimerSymbol.Glyph = playIcon;
                        dispatcherTimer.Stop();
                    }
                }
                else
                {
                    if(PlayPauseTimerSymbol.Glyph == restartIcon)
                    {
                        shortBreak = false;
                        PlayPauseTimerSymbol.Glyph = pauseIcon;
                        
                        TimerValueBar.Maximum = workTime;
                        StartTimers();

                        return;
                    }

                    if (pomsDone <= 4)
                    {
                        if (pomsDone < 4)
                            PlayPauseTimerSymbol.Glyph = restartIcon;
                        else
                            PlayPauseTimerSymbol.Glyph = finishedIcon;

                        PomButton.IsEnabled = false;

                        TimerValueBar.Maximum = shortBreakTime;
                        StartTimers();
                    }
                    else if(pomsDone > 4)
                    {
                        PomButton.IsEnabled = false;
                        DisablePomodoroTask();
                    }
                }
            }
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            (parentReference as MainPage).RemoveItemFromList(this);
        }

        private void MenuFlyoutItem_Click_1(object sender, RoutedEventArgs e)
        {
            PlayPauseTimerSymbol.Glyph = finishedIcon;
            PomButton.IsEnabled = false;
            DisablePomodoroTask();
        }
    }
}
