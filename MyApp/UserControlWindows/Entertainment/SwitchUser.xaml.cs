using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        public static readonly MainWindow mainWindow = new MainWindow();
        public SwitchUser()
        {
            InitializeComponent();

            gifInitialization();

            Vis = false;
            // DataContext explains WPF in which object WPF has to check the binding path. Here Vis is in "this" then:
            YoutubeUser.Visibility = Visibility.Visible;
            MoviesUser.Visibility = Visibility.Hidden;
            QuotesUser.Visibility = Visibility.Hidden;
            MusicUser.Visibility = Visibility.Hidden;

        }

        private bool vis;
        public bool Vis
        {
            get { return vis; }
            set
            {
                if (vis != value)
                {
                    vis = value;
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
        private void gifInitialization()
        {
            ytGif.Source = new Uri(Environment.CurrentDirectory + @"\ytBack.gif");
            movieGif.Source = new Uri(Environment.CurrentDirectory + @"\moviegifback.gif");
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            ytGif.Position = TimeSpan.FromMilliseconds(1);
            movieGif.Position = TimeSpan.FromMilliseconds(1);

            //var videoPath = Environment.CurrentDirectory;
            //string projectDirectory = Directory.GetParent(videoPath).Parent.Parent.FullName;
            //ytGif.Source = new Uri(projectDirectory + @"images\Gifs\ytBack.gif", UriKind.Absolute);
            //ytTextBlock.Text = projectDirectory;
        }

        public void updateVisibility()
        {
            Vis = true;
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            YoutubeUser.Visibility = Visibility.Visible;
            switch_grid.Visibility = Visibility.Hidden;
            MoviesUser.Visibility = Visibility.Hidden;
            QuotesUser.Visibility = Visibility.Hidden;
            MusicUser.Visibility = Visibility.Hidden;
            
        }

        private void music_button_Click(object sender, RoutedEventArgs e)
        {
            YoutubeUser.Visibility = Visibility.Hidden;
            switch_grid.Visibility = Visibility.Hidden;
            MoviesUser.Visibility = Visibility.Hidden;
            QuotesUser.Visibility = Visibility.Hidden;
            MusicUser.Visibility = Visibility.Visible;
        }

        private void quotes_button_Click(object sender, RoutedEventArgs e)
        {
            YoutubeUser.Visibility = Visibility.Hidden;
            switch_grid.Visibility = Visibility.Hidden;
            MoviesUser.Visibility = Visibility.Hidden;
            QuotesUser.Visibility = Visibility.Visible;
            MusicUser.Visibility = Visibility.Hidden;
        }

        
    }
}
