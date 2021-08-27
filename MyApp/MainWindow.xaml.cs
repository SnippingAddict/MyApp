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
    /// </summary
    public partial class MainWindow : Window, INotifyPropertyChanged
    {


        public static Visibility checkEntertainment;
        public static Visibility checkEntertainment1;

        private TimeSpan trackTime;
        public TimeSpan TrackTime
        {
            get { return trackTime; }
            set
            {
                trackTime = value;
                Debug.WriteLine(TrackTime + "idemosasd");
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

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


        /// <summary>Window DragMove</summary
        private void Window_MouseOver(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        //Hamburger menu item commands
        #region
        private void popUpIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void youtube_menu_Click(object sender, RoutedEventArgs e)
        {
            homeUser.Visibility = Visibility.Collapsed;
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 1;
        }

        private void music_menu_Click(object sender, RoutedEventArgs e)
        {
            homeUser.Visibility = Visibility.Collapsed;
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 2;
        }

        private void quotes_menu_Click(object sender, RoutedEventArgs e)
        {
            homeUser.Visibility = Visibility.Collapsed;
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 3;
        }

        private void movies_menu_Click(object sender, RoutedEventArgs e)
        {
            textTransition.SelectedIndex = 1;
            userSwitch.Vis = 4;
            homeUser.Visibility = Visibility.Collapsed;
        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            homeUser.Visibility = Visibility.Visible;
            textTransition.SelectedIndex = 0;
            userSwitch.Vis = 0;
        }

        private void entertainment_menu_Click(object sender, RoutedEventArgs e)
        {
            userSwitch.Vis = 0;
            homeUser.Visibility = Visibility.Collapsed;
            textTransition.SelectedIndex = 1;
        }
        #endregion  
    }

    //Kind of a f you class, to something stupid but w.e
    public class TrackTimeHelp
    {
        private TimeSpan trackTime;
        public TimeSpan TrackTime
        {
            get { return trackTime; }
            set
            {
                trackTime = value;
                Debug.WriteLine(TrackTime + "idemosasd");
            }
        }
    }
}
