using MyApp.HelperClasses;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyApp.UserControlWindows.Health.Counter
{
    public class CalculateViewModel : ObservableObject
    {
        private int _itemId;
        private CalculateModel _currentItem;
        private ICommand _getItemCommand;
        private ICommand _saveItemCommand;
        List<CalculateModel> items = new List<CalculateModel>();

        #region Public Properties/Commands

        public CalculateModel CurrentItem
        {
            get { return _currentItem; }
            set
            {
                if (value != _currentItem)
                {
                    _currentItem = value;
                    OnPropertyChanged("CurrentItem");
                }
            }
        }

        public ICommand SaveItemCommand
        {
            get
            {
                if (_saveItemCommand == null)
                {
                    _saveItemCommand = new RelayCommand(
                        param => SaveItem(),
                        param => (CurrentItem != null)
                    );
                }
                return _saveItemCommand;
            }
        }

        public ICommand GetItemCommand
        {
            get
            {
                if (_getItemCommand == null)
                {
                    _getItemCommand = new RelayCommand(
                        param => GetItem(),
                        param => ItemId > 0
                    );
                }
                return _getItemCommand;
            }
        }

        public int ItemId
        {
            get { return _itemId; }
            set
            {
                if (value != _itemId)
                {
                    _itemId = value;
                    OnPropertyChanged("ItemId");
                }
            }
        }

        #endregion

        #region Private Helpers

        private void GetItem()
        {
            items = SQLiteDataAccess.LoadItems();
            CurrentItem = items[ItemId-1];
        }

        private void SaveItem()
        {
            SQLiteDataAccess.SaveItem(CurrentItem);
        }

        #endregion
    }
}
