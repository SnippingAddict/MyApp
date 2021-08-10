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

namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public readonly SwitchUser sw = new SwitchUser();
        public MainWindow()
        {
            //possible three milisecond load after button click for usercontrol switch
            InitializeComponent();

            //MoviesUser.Visibility = Visibility.Hidden;
            //QuotesUser.Visibility = Visibility.Hidden;
            //MusicUser.Visibility = Visibility.Hidden;

            //Vis = sw;
            DataContext = this;
            //datacontext je resenje, mora se naci nacin ucitavanja konteksta property iz drugog user control-a

        }

        private bool vis;
        public bool Vis
        {
            get { return vis; }
            set
            {
                if (vis != sw.Vis)
                {
                    vis = sw.Vis;
                    OnPropertyChanged("Vis");  // To notify when the property is changed
                }
            }
        }

        #region INotifyPropertyChanged implementation
        // Basically, the UI thread subscribes to this event and update the binding if the received Property Name correspond to the Binding Path element
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

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

        //private void Quotes_Click(object sender, RoutedEventArgs e)
        //{
        //    QuotesUser.Visibility = Visibility.Visible;
        //    switchGrid();
        //}

        //private void Youtube_Click(object sender, RoutedEventArgs e)
        //{
        //    YoutubeUser.Visibility = Visibility.Visible;
        //    switchGrid();
        //}

        //private void Music_Click(object sender, RoutedEventArgs e)
        //{
        //    MusicUser.Visibility = Visibility.Visible;
        //    switchGrid();
        //}

        public void switchGrid()
        {

        }

        private void popUpIzlaz_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Vis = sw.Vis;
        }
    }
}
