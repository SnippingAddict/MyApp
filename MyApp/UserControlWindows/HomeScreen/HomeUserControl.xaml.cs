using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
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

namespace MyApp.UserControlWindows.HomeScreen
{
    /// <summary>
    /// Interaction logic for HomeUserControl.xaml
    /// </summary>
    public partial class HomeUserControl : UserControl
    {

        public HomeUserControl()
        {
            InitializeComponent();

            //Task.Factory.StartNew(() =>
            //{
            //    BeginInvokeExample();
            //});
        }

        private void entertainment_button_Click(object sender, RoutedEventArgs e)
        {
            //Debug.WriteLine(userSwitch);
            //userSwitch.Vis = 0;
        }

        //private void BeginInvokeExample()
        //{
        //    Thread.Sleep(2000);
        //    DispatcherOperation op = Dispatcher.BeginInvoke((Action)(() =>
        //    {
        //        welcomeText.Text = "Welcome back Nikola";

        //    }));

        //}
    }
}
