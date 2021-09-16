using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyApp.UserControlWindows
{
    /// <summary>
    /// Interaction logic for MoviesUser.xaml
    /// </summary>
    public partial class MoviesUser : UserControl
    {
        //Some declarations
        private bool mediaPlayerIsPlaying = false;
        private bool mediaPlayerIsPaused = false;
        private bool userIsDraggingSlider = false;
        private DispatcherTimer timer = new DispatcherTimer();
        public bool movieActive;
        public int count;
        private Timer aTimer;


        public MoviesUser()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        #region Code used for movie controls

        /// <summary>Change the volume of the media.</summary> 
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {

            myMediaElement.Volume = (double)volumeSlider.Value;
            var sliderVal = volumeSlider.Value;
            Debug.WriteLine(myMediaElement.Volume);

            if (sliderVal <= 0.5 && sliderVal > 0)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeMedium;
            }
            else if (sliderVal == 1 && sliderVal >= 0.5)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeHigh;
            }
            else if (sliderVal == 0)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeOff;
            }
        }

        //Volume toggle button
        private void volumeButton_Click(object sender, RoutedEventArgs e)
        {
            if (volumeButton.IsChecked == false)
            {
                myMediaElement.Volume = 0;
                volumeSlider.Value = 0;
            }
            else
            {
                volumeSlider.Value = 1;
                myMediaElement.Volume = 1;
            }

        }

        /// <summary>
        /// Initialize slider values
        /// </summary>
        private void timer_Tick(object sender, EventArgs e)
        {
            if ((myMediaElement.Source != null) && (myMediaElement.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                timelineSlider.Minimum = 0;
                timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalSeconds;
                timelineSlider.Value = myMediaElement.Position.TotalSeconds;
            }
        }

        //Three timelineSlider methods for manipulating slider values and media length
        private void timelineSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }

        private void timelineSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            myMediaElement.Position = TimeSpan.FromSeconds(timelineSlider.Value);
        }

        private void timelineSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            lblProgressStatus.Text = TimeSpan.FromSeconds(timelineSlider.Value).ToString(@"hh\:mm\:ss");
            //int SliderValue = (int)timelineSlider.Value;
            //TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            //myMediaElement.Position = ts;
        }

        //Button commands
        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //Open file search dialog
        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mp4;*.mpg;*.mpeg;*.mkv)|*.mp3;*.mp4;*.mpg;*.mpeg;*.mkv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                myMediaElement.Source = new Uri(openFileDialog.FileName);
                if (myMediaElement.Source != null)
                {
                    mediaPlayerIsPlaying = true;
                    myMediaElement.Play();
                }
                Debug.WriteLine(myMediaElement.Source);
            }

            if (mediaPlayerIsPlaying == true)
            {
                fScreenMode();
                controlsFadeOut();
                myMediaElement.Visibility = Visibility.Visible;
            }

        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (myMediaElement != null) && (myMediaElement.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Play();
            mediaPlayerIsPlaying = true;
            myMediaElement.Visibility = Visibility.Visible;
            mediaPlayerIsPaused = false;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Pause();
            mediaPlayerIsPaused = true;
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Stop();
            mediaPlayerIsPlaying = false;
            myMediaElement.Visibility = Visibility.Collapsed;
            timelineSlider.Value = 0;
        }

        //Used for movie controls fade animation
        //Needs more code optimizing, pointless repeating
        private void controlsFadeOut()
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard myStoryboard = new Storyboard();

            myDoubleAnimation.To = 0;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(90.0));
            Storyboard.SetTargetName(myDoubleAnimation, ControlsFade.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(OpacityProperty));

            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Begin(this);

        }

        //Needs more code optimizing, pointless repeating
        private void controlsFadeIn()
        {
            DoubleAnimation myDoubleAnimation = new DoubleAnimation();
            Storyboard myStoryboard = new Storyboard();

            myDoubleAnimation.To = 1;
            myDoubleAnimation.Duration = new Duration(TimeSpan.FromMilliseconds(90.0));
            Storyboard.SetTargetName(myDoubleAnimation, ControlsFade.Name);
            Storyboard.SetTargetProperty(myDoubleAnimation,
                new PropertyPath(OpacityProperty));

            myStoryboard.Children.Add(myDoubleAnimation);
            myStoryboard.Begin(this);

        }

        private void ControlsFade_MouseEnter(object sender, MouseEventArgs e)
        {
            controlsFadeIn();
        }

        private void ControlsFade_MouseLeave(object sender, MouseEventArgs e)
        {
            if (mediaPlayerIsPlaying == true && mediaPlayerIsPaused == false)
            {
                controlsFadeOut();
            }
        }

        #endregion


        #region Movie fullscreen control, was fun
        //
        //  The way i made the fullscreen option is autistic.
        //  It works, however it needs a lot more polishing and maybe even a better way of going in and out of fullscreen.
        //  Would love to explain it all but im too lazy, if you're interested in understanding this just focus on mediaelement and timelineSlider timespan
        //

        private Window _fullScreenWindow;
        private DependencyObject _originalParent;

        //Affects the usual MovieUser background
        public void fScreenMode()
        {
            rectangleGrid.Background = Brushes.Black;
            movieRectangle.Visibility = Visibility.Collapsed;
            openButton.Visibility = Visibility.Collapsed;
        }

        private TimeSpan trackTime;

        private void valueTransfer()
        {
            MainWindow mW = new MainWindow();
            myMediaElement.Position = TimeSpan.FromSeconds(timelineSlider.Value);
            trackTime = TimeSpan.FromSeconds(timelineSlider.Value);
        }

        //Big win with this option
        //Transferring the user control to another parent window and going fullscreen
        private void FullScreenButton_Click(object sender, RoutedEventArgs e)
        {
            var rec = movieRectangle;

            if (_fullScreenWindow == null) //go fullscreen
            {
                if (mediaPlayerIsPlaying == true)
                {
                    fScreenMode();
                }
                _fullScreenWindow = new Window(); //create full screen window
                _originalParent = movieUserControl.Parent;
                RemoveChildHelper.RemoveChild(_originalParent, this); //remove the user control from current parent
                _fullScreenWindow.Content = this; //add the user control to full screen window
                _fullScreenWindow.WindowStyle = WindowStyle.None;
                _fullScreenWindow.WindowState = WindowState.Maximized;
                _fullScreenWindow.ResizeMode = ResizeMode.NoResize;
                _fullScreenWindow.Show();
                valueTransfer();
            }
            else //exit fullscreen
            {
                valueTransfer();
                if (mediaPlayerIsPlaying != true)
                {
                    openButton.Visibility = Visibility.Visible;
                    rec.Visibility = Visibility.Visible;
                }
                var parent = Parent;
                RemoveChildHelper.RemoveChild(parent, this);
                RemoveChildHelper.AddToParent(movieUserControl, _originalParent);

                _fullScreenWindow.Close();
                _fullScreenWindow = null;

                //Timer for timedevent
                aTimer = new Timer();
                aTimer.Interval = 50;
                aTimer.Elapsed += OnTimedEvent;
                aTimer.Enabled = true;
            }
        }

        //Begins the movie after the user leaves fullscreen
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Debug.WriteLine(trackTime);
            this.Dispatcher.Invoke(() =>
            {
                //cannot be changed without Dispatcher.Invoke, threads seem pretty fun
                //Link to issue "https://stackoverflow.com/questions/9732709/the-calling-thread-cannot-access-this-object-because-a-different-thread-owns-it"

                myMediaElement.Position = trackTime;
                timelineSlider.Value = myMediaElement.Position.TotalSeconds;
            });
            aTimer.Enabled = false;
        }
        #endregion

    }

    //Helper class for removing child from parent
    public static class RemoveChildHelper
    {
        //Add child to parent method
        public static void AddToParent(this UIElement child, DependencyObject parent, int? index = null)
        {
            if (parent == null)
                return;

            if (parent is ItemsControl itemsControl)
                if (index == null)
                    itemsControl.Items.Add(child);
                else
                    itemsControl.Items.Insert(index.Value, child);
            else if (parent is Panel panel)
                if (index == null)
                    panel.Children.Add(child);
                else
                    panel.Children.Insert(index.Value, child);
            else if (parent is Decorator decorator)
                decorator.Child = child;
            else if (parent is ContentPresenter contentPresenter)
                contentPresenter.Content = child;
            else if (parent is ContentControl contentControl)
                contentControl.Content = child;
        }

        //Remove child from parent method
        public static void RemoveChild(this DependencyObject parent, UIElement child)
        {
            var panel = parent as Panel;
            if (panel != null)
            {
                panel.Children.Remove(child);
                return;
            }

            var decorator = parent as Decorator;
            if (decorator != null)
            {
                if (decorator.Child == child)
                {
                    decorator.Child = null;
                }
                return;
            }

            var contentPresenter = parent as ContentPresenter;
            if (contentPresenter != null)
            {
                if (contentPresenter.Content == child)
                {
                    contentPresenter.Content = null;
                }
                return;
            }

            var contentControl = parent as ContentControl;
            if (contentControl != null)
            {
                if (contentControl.Content == child)
                {
                    contentControl.Content = null;
                }
                return;
            }

        }
    }

}