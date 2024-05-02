using Delivery.Model.Models;
using Delivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModel
{
    internal class AddClientViewModel : NotifyPropertyChanged
    {
        public List<Clients> Clients { get; set; } = DataWorker.SelectAllClients();


        private MainViewModel _mainViewModel;
        public AddClientViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
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
                _phone= value;
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

        private RelayCommand _addClientCommand;
        public RelayCommand AddClientCommand
        {
            get
            {
                if (_addClientCommand == null)
                {
                    _addClientCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.createClient(Firstname, Lastname, Fathername, Phone, Email) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            
                            _mainViewModel.Clients = DataWorker.SelectAllClientsTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addClientCommand;
            }
        }
    }
}
