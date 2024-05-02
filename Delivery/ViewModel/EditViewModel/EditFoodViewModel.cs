using Delivery.Model.Models;
using Delivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModel.EditViewModel
{
    internal class EditFoodViewModel : NotifyPropertyChanged
    {
        public List<Categories> Categories { get; set; } = DataWorker.SelectAllCategories();
        public List<Food> Food { get; set; } = DataWorker.SelectAllFood();

        private MainViewModel _mainViewModel;
        public EditFoodViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private int categoryId;

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
                 categoryId = _selectedCategory.IdCategory;
            }
        }

        private Food _selectedFood;
        public Food SelectedFood
        {
            get
            {
                return _selectedFood;
            }
            set
            {
                _selectedFood = value;
                Name = _selectedFood.Name;
            }
        }

        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
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

        private RelayCommand _editFoodCommand;
        public RelayCommand EditFoodCommand
        {
            get
            {
                if (_editFoodCommand == null)
                {
                    _editFoodCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editFood(SelectedFood, Name, Price, Description, categoryId, Quantity) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                            _mainViewModel.Food = DataWorker.SelectAllFoodTable();
                            Food = DataWorker.SelectAllFood();
                        }
                    });
                }
                return _editFoodCommand;
            }
        }
    }
}
