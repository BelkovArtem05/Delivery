using Delivery.Model.Models;
using Delivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Delivery.ViewModel
{
    internal class EditClientViewModel : NotifyPropertyChanged
    {
        public List<Clients> Clients { get; set; } = DataWorker.SelectAllClients();


        private MainViewModel _mainViewModel;
        public EditClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private Clients _selectedClient;
        public Clients SelectedClient
        {
            get
            {
                return _selectedClient;   
            }
            set
            {
                _selectedClient = value;
                Firstname = _selectedClient.Firstname;
                Lastname = _selectedClient.Lastname;
                Fathername = _selectedClient.Fathername;
                Phone = _selectedClient.Phone;
            }
        }

        private string _Firstname;
        public string Firstname
        {
            get { return _Firstname; }
            set
            {
                _Firstname = value;
                OnPropertyChanged("Firstname");
            }
        }

        private string _lastname;
        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged("Lastname");
            }
        }

        private string _fathername;
        public string Fathername
        {
            get { return _fathername; }
            set
            {
                _fathername = value;
                OnPropertyChanged("Fathername");
            }
        }

        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        private RelayCommand _editClientCommand;
        public RelayCommand EditClientCommand
        {
            get
            {
                if (_editClientCommand == null)
                {
                    _editClientCommand = new RelayCommand((o) =>
                    {
                    if (DataWorker.editClient(SelectedClient, Firstname, Lastname, Fathername, Phone, Email) == true)
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
                return _editClientCommand;
            }
        }
    }
}
