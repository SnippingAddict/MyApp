using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyApp.UserControlWindows.Entertainment
{
    public  class Switch : INotifyPropertyChanged
    {

        

        private Visibility vis;
        public Visibility Vis
        {
            get { return vis; }
            set { vis = value;
                OnPropertyChanged("Vis"); }
        }

        #region INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs("Vis"));
        }
        #endregion

        public void switchControlUser()
        {
            Vis = Visibility.Collapsed;
        }
    }
}
