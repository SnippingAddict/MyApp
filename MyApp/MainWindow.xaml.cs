using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
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
using System.Runtime.CompilerServices;
using System.IO;
using System.ComponentModel;
using MyApp.UserControlWindows.Entertainment;
using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System.Diagnostics;

namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public static Visibility checkEntertainment;
        public static Visibility checkEntertainment1;


        bool quote = false;
        bool movie = false;
        bool music = false;
        bool youtube = false;

        //public int Counter
        //{
        //    get;
        //    set;
        //}

        public int Counter
        {
            get { return (int)this.GetValue(StateProperty); }
            set
            {
               this.SetValue(StateProperty, value);
                OnNotifyPropertyChanged("Counter");
            }
        }

        public static readonly DependencyProperty StateProperty = DependencyProperty.Register("CheckEntertainment", typeof(int), typeof(MainWindow));

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnNotifyPropertyChanged(string p)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(p));
            }
        }

        public MainWindow()
        {
            InitializeComponent();

        }

        //private Visibility vis;
        //public Visibility Vis
        //{
        //    get { return vis; }
        //    set { vis = value; }
        //}

        private void ColorZone_MouseOver(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void Window_MouseOver(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //public void collapseEntertainmentControls()
        //{
        //    YoutubeUser.Visibility = Visibility.Collapsed;
        //    MoviesUser.Visibility = Visibility.Collapsed;
        //    QuotesUser.Visibility = Visibility.Collapsed;
        //    MusicUser.Visibility = Visibility.Collapsed;
        //}

        //public void checkUserControl()
        //{
        //    if (youtube == true)
        //    {
        //        YoutubeUser.Visibility = Visibility.Visible;
        //        MoviesUser.Visibility = Visibility.Collapsed;
        //        QuotesUser.Visibility = Visibility.Collapsed;
        //        MusicUser.Visibility = Visibility.Collapsed;
        //    }
        //    else if (quote == true)
        //    {
        //        YoutubeUser.Visibility = Visibility.Collapsed;
        //        MoviesUser.Visibility = Visibility.Collapsed;
        //        QuotesUser.Visibility = Visibility.Visible;
        //        MusicUser.Visibility = Visibility.Collapsed;
        //    }
        //    else if (music == true)
        //    {
        //        YoutubeUser.Visibility = Visibility.Collapsed;
        //        MoviesUser.Visibility = Visibility.Collapsed;
        //        QuotesUser.Visibility = Visibility.Collapsed;
        //        MusicUser.Visibility = Visibility.Visible;
        //    }
        //    else if (movie == true)
        //    {
        //        YoutubeUser.Visibility = Visibility.Collapsed;
        //        MoviesUser.Visibility = Visibility.Visible;
        //        QuotesUser.Visibility = Visibility.Collapsed;
        //        MusicUser.Visibility = Visibility.Collapsed;
        //    }
        //}

        private void popUpIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void youtube_menu_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 1;
        }

        private void music_menu_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 2;
        }

        private void quotes_menu_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 3;
        }

        private void movies_menu_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 4;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 0;
            userSwitch.Vis = 0;
        }

        private void entertainment_menu_Click(object sender, RoutedEventArgs e)
        {
            userSwitch.Vis = 0;
            Debug.WriteLine(userSwitch.Vis);
            textTransition.SelectedIndex = 1;
        }


    }
}
