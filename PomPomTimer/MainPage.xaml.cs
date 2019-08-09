using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PomPomTimer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ContentDialog newTaskDialog;
        ObservableCollection<PomTimeBlock> pomTimeBlockList;

        public MainPage()
        {
            this.InitializeComponent();
            pomTimeBlockList = new ObservableCollection<PomTimeBlock>();

            SetUpWindow();            
        }

        private void SetUpWindow()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;
            titleBar.BackgroundColor = Windows.UI.Colors.White;
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.Transparent;
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.Transparent;

            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Transparent;

            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(200, 100));
            ApplicationView.PreferredLaunchViewSize = new Size(530, 800);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rootPivot.SelectedIndex = 1;
            AddSymbol.Symbol = Symbol.Back;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (rootPivot.SelectedIndex != 0)
            {
                rootPivot.SelectedIndex = 0;
                AddSymbol.Symbol = Symbol.Add;
                return;
            }

            ShowAddTaskDialog();
        }

        private void AddToPomItemsList(PomTimeBlock item)
        {
            pomTimeBlockList.Add(item);
            PomodoroItems.ItemsSource = pomTimeBlockList;
        }

        private async void ShowAddTaskDialog()
        {
            TextBox contentTextBox = new TextBox() { Width = 320, Height = 60, MaxLength = 50, PlaceholderText = "Discription of task" };
            contentTextBox.Header = "0 / 50";
            contentTextBox.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            contentTextBox.BorderThickness = new Thickness(1);

            newTaskDialog = new ContentDialog
            {
                Title = "Add Pomorodoro",
                Content = contentTextBox,
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Create",
                DefaultButton = ContentDialogButton.Primary
            };

            ContentDialogResult result = await newTaskDialog.ShowAsync();

            if (result == ContentDialogResult.Primary)
            {
                string selectedBreakValue = ((ComboBoxItem)BreakTime.SelectedValue).Content as string;
                string selectedTaskValue = ((ComboBoxItem)TaskTime.SelectedValue).Content as string;

                PomTimeBlock ptb = new PomTimeBlock() { Discription = contentTextBox.Text };
                ptb.SetTaskTime(Int32.Parse(selectedTaskValue) * 60);
                ptb.SetBreakTime(Int32.Parse(selectedBreakValue) * 60);
                ptb.parentReference = this;

                AddToPomItemsList(ptb);
            }
        }

        private void TaskTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskTime.SelectedValue == null || TaskTime == null || pomTimeBlockList == null)
                return;

            foreach(PomTimeBlock ptb in pomTimeBlockList)
            {
                string selectedValue = ((ComboBoxItem)TaskTime.SelectedValue).Content as string;

                if(selectedValue != null)
                    ptb.SetTaskTime(Int32.Parse(selectedValue) * 60);
            }

            PomodoroItems.ItemsSource = pomTimeBlockList;
        }

        private void BreakTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BreakTime.SelectedValue == null || BreakTime == null || pomTimeBlockList == null)
                return;

            foreach (PomTimeBlock ptb in pomTimeBlockList)
            {
                string selectedValue = ((ComboBoxItem)BreakTime.SelectedValue).Content as string;

                if (selectedValue != null)
                    ptb.SetBreakTime(Int32.Parse(selectedValue) * 60);
            }

            PomodoroItems.ItemsSource = pomTimeBlockList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (newTaskDialog.Content as TextBox).Header = (newTaskDialog.Content as TextBox).Text.Length.ToString() + " / 50";
        }

        public void RemoveItemFromList(object item)
        {
            pomTimeBlockList.Remove(item as PomTimeBlock);
            PomodoroItems.ItemsSource = pomTimeBlockList;
        }

        public void DuplicateItem(object item)
        {
            AddToPomItemsList(new PomTimeBlock() { Discription = (item as PomTimeBlock).Discription, parentReference = this });
        }

        private void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (pomTimeBlockList == null)
                return;

            foreach(PomTimeBlock ptb in pomTimeBlockList)
            {
                ptb.canSendSystemNotifications = notificationToggle.IsOn;
            }

            PomodoroItems.ItemsSource = pomTimeBlockList;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string accentResource = "PomodoroAccent";
            string gradientStartResource = "PomodoroStart";
            string gradientEndResource = "PomodoroEnd";

            if(ThemeBox.SelectedIndex == 1)
            {
                accentResource = "EnergyAccent";
                gradientStartResource = "EnergyStart";
                gradientEndResource = "EnergyEnd";
            }
            else if(ThemeBox.SelectedIndex == 2)
            {
                accentResource = "CoffeeAccent";
                gradientStartResource = "CoffeeStart";
                gradientEndResource = "CoffeeEnd";
            }
            else if(ThemeBox.SelectedIndex == 3)
            {
                accentResource = "SlateAccent";
                gradientStartResource = "SlateStart";
                gradientEndResource = "SlateEnd";
            }

            Application.Current.Resources["SystemAccentColor"] = (Color)Application.Current.Resources[accentResource];
            Application.Current.Resources["GradientStart"] = (Color)Application.Current.Resources[gradientStartResource];
            Application.Current.Resources["GradientEnd"] = (Color)Application.Current.Resources[gradientEndResource];

            RefreshApp();
        }

        private void RefreshApp()
        {
            AppRoot.RequestedTheme = ElementTheme.Light;
            AppRoot.RequestedTheme = ElementTheme.Dark;

            TaskTime.RequestedTheme = ElementTheme.Light;
            TaskTime.RequestedTheme = ElementTheme.Dark;

            BreakTime.RequestedTheme = ElementTheme.Light;
            BreakTime.RequestedTheme = ElementTheme.Dark;

            ThemeBox.RequestedTheme = ElementTheme.Light;
            ThemeBox.RequestedTheme = ElementTheme.Dark;

            notificationToggle.RequestedTheme = ElementTheme.Light;
            notificationToggle.RequestedTheme = ElementTheme.Dark;

            PomodoroItems.RequestedTheme = ElementTheme.Light;
            PomodoroItems.RequestedTheme = ElementTheme.Dark;

            if (pomTimeBlockList == null)
                return;

            foreach(PomTimeBlock ptb in pomTimeBlockList)
            {
                ptb.RequestedTheme = ElementTheme.Light;
                ptb.RequestedTheme = ElementTheme.Dark;
            }

            PomodoroItems.ItemsSource = pomTimeBlockList;
        }
    }
}
