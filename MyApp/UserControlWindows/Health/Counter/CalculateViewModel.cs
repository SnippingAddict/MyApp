using MyApp.HelperClasses;
using System;
using System.Collections.Generic;
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
            // You should get the product from the database
            // but for now we'll just return a new object
            CalculateModel p = new CalculateModel();
            p.ItemId = ItemId;
            p.ItemName = "Test Product";
            p.Calories = 10;
            CurrentItem = p;
        }

        private void SaveItem()
        {
            // You would implement your Product save here
        }

        #endregion
    }
}
