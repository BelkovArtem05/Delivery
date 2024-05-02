using Delivery.Model.Models;
using Delivery.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModel
{
    internal class EditOrderViewModel : NotifyPropertyChanged
    {
        public List<Orders> Orders { get; set; } = DataWorker.SelectAllOrders();

        private MainViewModel _mainViewModel;
        public EditOrderViewModel(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        private Orders _selectedOrder;
        public Orders SelectedOrder
        {
            get
            {
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                Status = _selectedOrder.Status;
                Id = _selectedOrder.IdOrder;
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _status;
        public string Status
        {
            get { return _status; }
            set
            {
                _status = value;
                OnPropertyChanged("Status");
            }
        }

        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged("Address");
            }
        }

        private RelayCommand _editOrderCommand;
        public RelayCommand EditOrderCommand
        {
            get
            {
                if (_editOrderCommand == null)
                {
                    _editOrderCommand = new RelayCommand((o) =>
                    {
                        if (DataWorker.editOrder(SelectedOrder, Status, Address) == true)
                        {
                            CreateWindow.CreateMessageBox("Успешно");
                            _mainViewModel.Orders = DataWorker.SelectAllOrdersTable();
                        }
                        else
                        {
                            CreateWindow.CreateMessageBox("Неудача");

                        }
                    });
                }
                return _editOrderCommand;
            }
        }
    }
}
