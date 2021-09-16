using MyApp.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.UserControlWindows.Health.Counter
{
    public class CalculateModel : ObservableObject
    {
        private int _itemId;
        private string _itemName;
        private int _calories;
        private int _totalCalories;
        public int _weight;

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

        public int Weight
        {
            get { return _weight; }
            set
            {
                if (value != _weight)
                {
                    _weight = value;
                    OnPropertyChanged("ItemId");
                }
            }
        }

        public string ItemName
        {
            get { return _itemName; }
            set
            {
                if (value != _itemName)
                {
                    _itemName = value;
                    OnPropertyChanged("ItemName");
                }
            }
        }

        public int Calories
        {
            get { return _calories; }
            set
            {
                if (value != _calories)
                {
                    _calories = value;
                    OnPropertyChanged("Calories");
                }
            }
        }

        public int TotalCalories
        {
            get { return _totalCalories; }
            set
            {
                if (value != _totalCalories)
                {
                    _totalCalories = value;
                    OnPropertyChanged("TotalCalories");
                }
            }
        }
    }
}
