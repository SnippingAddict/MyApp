using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MyApp.UserControlWindows
{
    /// <summary>
    /// Interaction logic for MoviesUser.xaml
    /// </summary>
    public partial class MoviesUser : UserControl, INotifyPropertyChanged
    {
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;

        public MoviesUser()
        {
            InitializeComponent();

            //myMediaElement.Source = new Uri(Environment.CurrentDirectory + @"\videoExample.mkv");
            //myMediaElement.Play


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

            

        /// <summary>Change the volume of the media.</summary> 
        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {

            myMediaElement.Volume = (double)volumeSlider.Value;
            //OnNotifyPropertyChanged("volumeIcon");
            var sliderVal = volumeSlider.Value;
            //Debug.WriteLine(sliderVal);

            if (sliderVal >= 50 && sliderVal <= 75)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeMedium;
            } else if (sliderVal <= 25 && sliderVal >= 0)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeLow;
            }
            else if (sliderVal == 100 && sliderVal >= 75)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeHigh;
            } else if (sliderVal == 0)
            {
                volumeIcon.Kind = MaterialDesignThemes.Wpf.PackIconKind.VolumeOff;
            }
        }

        public CornerRadius CornerRadius { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Check for property event for the given property name (string p)
        /// </summary>
        private void OnNotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));

            }
        }

        /// <summary>
        /// When the media opens, initialize the "Seek To" slider maximum value
        /// to the total number of miliseconds in the length of the media clip.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_MediaOpened(object sender, EventArgs e)
        {
            timelineSlider.Maximum = myMediaElement.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        /// <summary>
        /// When the media playback is finished. Stop() the media to seek to media start.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Element_MediaEnded(object sender, EventArgs e)
        {
            myMediaElement.Stop();
        }

        // Jump to different parts of the media (seek to).
        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            myMediaElement.Position = ts;
        }

        /// <summary>
        /// Initialize slider values
        /// </summary>
        void InitializePropertyValues()
        {
            myMediaElement.Volume = (double)volumeSlider.Value;
        }

        /// <summary>
        /// Play media.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
           
        //    InitializePropertyValues();
        //}

        ///// <summary>
        ///// Pause media.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Button_Click_1(object sender, RoutedEventArgs e)
        //{
        //    myMediaElement.Pause();
        //}

        ///// <summary>
        ///// Stop media.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void Button_Click_2(object sender, RoutedEventArgs e)
        //{
        //    // The Stop method stops and resets the media to be played from
        //    // the beginning.
        //    myMediaElement.Stop();
        //}

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
        }

        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Open_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Media files (*.mp3;*.mpg;*.mpeg;*.mkv)|*.mp3;*.mpg;*.mpeg;*.mkv|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() != null)
                myMediaElement.Source = new Uri(openFileDialog.FileName);
            myMediaElement.Visibility = Visibility.Visible;
        }

        private void Play_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (myMediaElement != null) && (myMediaElement.Source != null);
        }

        private void Play_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Play();
            mediaPlayerIsPlaying = true;
        }

        private void Pause_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Pause_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Pause();
        }

        private void Stop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = mediaPlayerIsPlaying;
        }

        private void Stop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            myMediaElement.Stop();
            mediaPlayerIsPlaying = false;
        }

        private void volumeButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public bool Visibily
        {
            get { return (bool)GetValue(VisibilyProperty); }
            set { SetValue(VisibilyProperty, value); }
        }

        public static readonly DependencyProperty VisibilyProperty =
            DependencyProperty.Register("Visibily", typeof(bool), typeof(MoviesUser), new PropertyMetadata(true));

        private void majmmun_Click(object sender, RoutedEventArgs e)
        {
            Visibily = true;
        }

        private void majmmun2_Click(object sender, RoutedEventArgs e)
        {
            Visibily = false;
        }

        private void majmmun2_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Visibily = false;

        }
    }
}
