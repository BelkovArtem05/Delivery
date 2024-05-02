using Delivery.Model.Models;
using Delivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.ComponentModel;
using Delivery.ViewModel;

namespace Delivery.ViewModel.EditViewModel
{
    internal class EditCategoryViewModel : NotifyPropertyChanged
    {
        public List<Categories> Categories { get; set; } = DataWorker.SelectAllCategories();

        private MainViewModel _mainViewModel;
        public EditCategoryViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
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
                Name = _selectedCategory.Name;
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


        private RelayCommand _editCategoryCommand;
        public RelayCommand EditCategoryCommand
        {
            get
            {
                if (_editCategoryCommand == null)
                {
                    _editCategoryCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editCategory(SelectedCategory, Name) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            _mainViewModel.Food = DataWorker.SelectAllFoodTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                            
                        }
                    });
                }
                return _editCategoryCommand;
            }
        }
    }
}
