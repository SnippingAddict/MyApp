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

namespace MyApp.UserControlWindows.Entertainment
{
    /// <summary>
    /// Interaction logic for SwitchUser.xaml
    /// </summary>
    public partial class SwitchUser : UserControl, INotifyPropertyChanged
    {

        public static Visibility userVisibility;

        public SwitchUser()
        {
            InitializeComponent();
        }

        public int Vis
        {
            get { return (int)this.GetValue(StateProperty); }
            set
            {
                this.SetValue(StateProperty, value);
                OnNotifyPropertyChanged("Vis");
                checkUserControl(Vis);
            }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("Vis", typeof(int), typeof(SwitchUser));

        public double WinH
        {
            get { return (double)this.GetValue(StateProperty1); }
            set
            {
                this.SetValue(StateProperty1, value);
                OnNotifyPropertyChanged("WinH");
            }
        }

        public static readonly DependencyProperty StateProperty1 = DependencyProperty.Register("WinH", typeof(double), typeof(SwitchUser));
        
        public double WinW
        {
            get { return (double)this.GetValue(StateProperty2); }
            set
            {
                this.SetValue(StateProperty2, value);
                OnNotifyPropertyChanged("WinW");
                Debug.WriteLine("Prover WinW : " + WinW);
            }
        }

        public static readonly DependencyProperty StateProperty2 = DependencyProperty.Register("WinW", typeof(double), typeof(SwitchUser));

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

        //private void gifInitialization()
        //{
        //    ytGif.Source = new Uri(Environment.CurrentDirectory + @"\ytBack.gif");
        //    movieGif.Source = new Uri(Environment.CurrentDirectory + @"\moviegifback.gif");
        //}

        //private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        //{
        //    ytGif.Position = TimeSpan.FromMilliseconds(1);
        //    movieGif.Position = TimeSpan.FromMilliseconds(1);
        //}

        //Code for usercontrol visibility
        #region
        /// <summary>
        /// Change UserControl visibility based on param
        /// </summary>
        /// <param name="number"></param>

        public void checkUserControl(int number)
        {

            if (number == 0)
            {
                YoutubeUser.Visibility = Visibility.Collapsed;
                MoviesUser.Visibility = Visibility.Collapsed;
                QuotesUser.Visibility = Visibility.Collapsed;
                switch_grid.Visibility = Visibility.Visible;
                MusicUser.Visibility = Visibility.Collapsed;
            }
            if (number == 1)
            {
                YoutubeUser.Visibility = Visibility.Visible;
                MoviesUser.Visibility = Visibility.Collapsed;
                QuotesUser.Visibility = Visibility.Collapsed;
                switch_grid.Visibility = Visibility.Collapsed;
                MusicUser.Visibility = Visibility.Collapsed;
            }
            else if (number == 2)
            {
                YoutubeUser.Visibility = Visibility.Collapsed;
                MoviesUser.Visibility = Visibility.Collapsed;
                QuotesUser.Visibility = Visibility.Collapsed;
                switch_grid.Visibility = Visibility.Collapsed;
                MusicUser.Visibility = Visibility.Visible;
            }
            else if (number == 3)
            {
                YoutubeUser.Visibility = Visibility.Collapsed;
                MoviesUser.Visibility = Visibility.Collapsed;
                QuotesUser.Visibility = Visibility.Visible;
                switch_grid.Visibility = Visibility.Collapsed;
                MusicUser.Visibility = Visibility.Collapsed;
            }
            else if (number == 4)
            {
                YoutubeUser.Visibility = Visibility.Collapsed;
                MoviesUser.Visibility = Visibility.Visible;
                QuotesUser.Visibility = Visibility.Collapsed;
                switch_grid.Visibility = Visibility.Collapsed;
                MusicUser.Visibility = Visibility.Collapsed;
            }
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            Vis = 1;
            checkUserControl(Vis);
        }

        private void music_button_Click(object sender, RoutedEventArgs e)
        {
            Vis = 2;
            checkUserControl(Vis);
        }

        private void quotes_button_Click(object sender, RoutedEventArgs e)
        {
            Vis = 3;
            checkUserControl(Vis);
        }

        private void movies_button_Click(object sender, RoutedEventArgs e)
        {
            Vis = 4;
            checkUserControl(Vis);
        }
        #endregion 


        private bool fullscreen;

        public bool Fullscreen
        {
            get { return fullscreen; }
            set
            {
                fullscreen = value;
                Debug.WriteLine("Second line" + Fullscreen);
                OnNotifyPropertyChanged("Fullscreen");
                Console.WriteLine(Height);
            }
        }

        public void changeToFullscreen()
        {
            if (Fullscreen == true)
            {
                WinW = 1400;
                WinH = 700;
            }
            else if (Fullscreen == false)
            {
                WinW = 950;
                WinH = 513;
            }
        }
    }
}
