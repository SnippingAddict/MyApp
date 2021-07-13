using System;
using System.Collections.Generic;
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

namespace MyApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
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
            User_Grid.Visibility = Visibility.Visible;
            QuotesUser.Visibility = Visibility.Visible;

            Items_Grid.Visibility = Visibility.Collapsed;
        }

        private void Youtube_Click(object sender, RoutedEventArgs e)
        {
            YoutubeUser.Visibility = Visibility.Visible;

            User_Grid.Visibility = Visibility.Visible;
            Items_Grid.Visibility = Visibility.Collapsed;
        }
    }
}
