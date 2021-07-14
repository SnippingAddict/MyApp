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

namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Timer aTimer;

        public MainWindow()
        {
            //possible three milisecond load after button click for usercontrol switch
            InitializeComponent();

            YoutubeUser.Visibility = Visibility.Hidden;
            MoviesUser.Visibility = Visibility.Hidden;
            QuotesUser.Visibility = Visibility.Hidden;
            MusicUser.Visibility = Visibility.Hidden;
        }

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

        private void Quotes_Click(object sender, RoutedEventArgs e)
        {
            QuotesUser.Visibility = Visibility.Visible;
            switchGrid();
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            YoutubeUser.Visibility = Visibility.Visible;
            switchGrid();
        }

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            MusicUser.Visibility = Visibility.Visible;
            switchGrid();
        }

        public void switchGrid()
        {
            User_Grid.Visibility = Visibility.Visible;
            Items_Grid.Visibility = Visibility.Collapsed;
        }
    }
}
