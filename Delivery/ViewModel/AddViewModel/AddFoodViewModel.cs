using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Delivery.Model.Models;
using Delivery.Model;

namespace Delivery.ViewModel.AddViewModel
{
    internal class AddFoodViewModel : NotifyPropertyChanged
    {
        public List<Categories> Categories { get; set; } = DataWorker.SelectAllCategories();
        private MainViewModel _mainViewModel;
        public AddFoodViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
        private string _name; 
        public string Name
        {
            get { return _name;  }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        private int _price;
        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged("Price");
            }
        }
        private int category;
        private string _description;
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        private int _quantity;
        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        private Categories _selectedCategory;
        public Categories SelectedCategory
        {
            get
            {
                return _selectedCategory;
            }
            set
            {
                _selectedCategory = value;
                category= _selectedCategory.IdCategory;
            }
        }

        private RelayCommand _addFoodCommand;
        public RelayCommand AddFoodCommand
        {
            get
            {
                if(_addFoodCommand == null)
                {
                    _addFoodCommand = new RelayCommand((o) =>
                    {
                        if(DataWorker.createFood(Name, Price, Description, category, Quantity) == true && Name.Length > 0)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            Name = null;
                            Description = null;
                            _mainViewModel.Food = DataWorker.SelectAllFoodTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addFoodCommand;
            }
        }


    }
}
