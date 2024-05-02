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
    internal class AddCategoryViewModel : NotifyPropertyChanged
    { 

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

        private RelayCommand _addCategoryCommand;
        public RelayCommand AddCategoryCommand
        {
            get
            {
                if(_addCategoryCommand == null)
                {
                    _addCategoryCommand = new RelayCommand((o) =>
                    {
                        if(DataWorker.createCategory(Name) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            Name = null;
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addCategoryCommand;
            }
        }


    }
}
