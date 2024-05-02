using Delivery.Model;
using Delivery.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModel
{
    internal class AddOrderViewModel : NotifyPropertyChanged
    {
        private MainViewModel _mainViewModel;
        public List<Food> Food { get; set; } = DataWorker.SelectAllFood();
        public List<Workers> Workers { get; set; } = DataWorker.SelectAllWorkers();
        public List<Clients> Clients{ get; set; } = DataWorker.SelectAllClients();

        public AddOrderViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private int _foodId;
        public int FoodId
        {
            get { return _foodId; }
            set
            {
                _foodId= value;
                OnPropertyChanged("FoodId");
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
                FoodId = _selectedFood.IdFood;
            }
        }

        private int _workerId;
        public int WorkerId
        {
            get { return _workerId; }
            set
            {
                _workerId = value;
                OnPropertyChanged("WorkerId");
            }
        }

        private Workers _selectedWorker;
        public Workers SelectedWorker
        {
            get
            {
                return _selectedWorker;
            }
            set
            {
                _selectedWorker= value;
                WorkerId= _selectedWorker.IdWorker;
            }
        }

        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId= value;
                OnPropertyChanged("ClientId");
            }
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
                ClientId = _selectedClient.IdClient;
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

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status= value;
                OnPropertyChanged("Status");
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _status = value;
                OnPropertyChanged("Address");
            }
        }

        private RelayCommand _addOrderCommand;
        public RelayCommand AddOrderCommand
        {
            get
            {
                if (_addOrderCommand == null)
                {
                    _addOrderCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.createOrder(ClientId, WorkerId, FoodId, Price, Status, Address) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            ClientId = 0;
                            WorkerId = 0;
                            FoodId = 0;
                            Price = 0;
                            Address = "";
                            Status = "";
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");
                        }
                    });
                }
                return _addOrderCommand;
            }
        }
    }
}
