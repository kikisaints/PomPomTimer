using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
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

        public MainPage()
        {
            this.InitializeComponent();
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
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if(rootPivot.SelectedIndex != 0)
                rootPivot.SelectedIndex = 0;

            //AddNewPomo.ShowAt(AddButton as FrameworkElement);
            ShowAddTaskDialog();
        }

        private async void ShowAddTaskDialog()
        {
            TextBox contentTextBox = new TextBox() { Width = 320, Height = 56, MaxLength = 50, PlaceholderText = "Discription of task" };
            contentTextBox.Header = "0 / 50";
            contentTextBox.TextChanged += new TextChangedEventHandler(TextBox_TextChanged);
            contentTextBox.BorderThickness = new Thickness(1);

            newTaskDialog = new ContentDialog
            {
                Title = "Add Pomorodoro",
                Content = contentTextBox,
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Create"
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

                PomodoroItems.Items.Add(ptb);
            }
        }

        private void TaskTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskTime.SelectedValue == null || TaskTime == null)
                return;

            foreach(PomTimeBlock ptb in PomodoroItems.Items)
            {
                string selectedValue = ((ComboBoxItem)TaskTime.SelectedValue).Content as string;

                if(selectedValue != null)
                    ptb.SetTaskTime(Int32.Parse(selectedValue) * 60);
            }
        }

        private void BreakTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BreakTime.SelectedValue == null || BreakTime == null)
                return;

            foreach (PomTimeBlock ptb in PomodoroItems.Items)
            {
                string selectedValue = ((ComboBoxItem)BreakTime.SelectedValue).Content as string;

                if (selectedValue != null)
                    ptb.SetBreakTime(Int32.Parse(selectedValue) * 60);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            (newTaskDialog.Content as TextBox).Header = (newTaskDialog.Content as TextBox).Text.Length.ToString() + " / 50";
        }

        public void RemoveItemFromList(object item)
        {
            PomodoroItems.Items.Remove(item);
        }

        public void DuplicateItem(object item)
        {
            PomodoroItems.Items.Add(new PomTimeBlock() { Discription = (item as PomTimeBlock).Discription, parentReference = this });
        }
    }
}
