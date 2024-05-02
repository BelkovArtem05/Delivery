using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.View;
using Delivery.Model;
using Delivery.ViewModel.AddViewModel;
using Delivery.ViewModel.EditViewModel;
using System.Windows;
using Delivery.Model.Models;

namespace Delivery.ViewModel
{
    internal class MainViewModel : NotifyPropertyChanged
    {
        public MainViewModel(Workers worker)
        {
            Worker = worker.Firstname + " " + worker.Fathername+ " " + worker.Lastname;
        }
        public string Worker { get; set; }

        private List<FoodTable> _food= DataWorker.SelectAllFoodTable();
        public List<FoodTable> Food
        {
            get { return _food; }
            set
            {
                _food = value;
                OnPropertyChanged("Food");
            }
        }

        private List<OrdersTable> _orders = DataWorker.SelectAllOrdersTable();
        public List<OrdersTable> Orders
        {
            get { return _orders; }
            set
            {
                _orders = value;
                OnPropertyChanged("Orders");
            }
        }

        private List<ClientsTable> _clients= DataWorker.SelectAllClientsTable();
        public List<ClientsTable> Clients
        {
            get { return _clients; }
            set
            {
                _clients = value;
                OnPropertyChanged("Clients");
            }
        }

        private string _searchText = "";
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value.Replace(" ", string.Empty);
                OnPropertyChanged("SearchText");
            }
        }

        private RelayCommand _searchCommand;
        public RelayCommand SearchCommand
        {
            get
            {
                if(_searchCommand == null)
                {
                    _searchCommand = new RelayCommand((o) =>
                    {
                        if (SearchText != string.Empty)
                        {
                            Food = DataWorker.SelectAllFoodTable().Where(c => $"{c.Name}{c.Description}{c.Price}{c.CategoryName}".ToLower().Contains(SearchText.ToLower())).ToList();
                        }
                        else
                        {
                            Food = DataWorker.SelectAllFoodTable();
                        }
                    });
                }
                return _searchCommand;
            }
        }

        private RelayCommand _searchOrderCommand;
        public RelayCommand SearchOrderCommand
        {
            get
            {
                if (_searchOrderCommand == null)
                {
                    _searchOrderCommand = new RelayCommand((o) =>
                    {
                        if (SearchText != string.Empty)
                        {
                            Orders = DataWorker.SelectAllOrdersTable().Where(c => $"{c.NameClient}{c.NameWorker}{c.DeliveryPrice}{c.IdOrder}{c.NameFood}".ToLower().Contains(SearchText.ToLower())).ToList();
                        }
                        else
                        {
                            Orders = DataWorker.SelectAllOrdersTable();
                        }
                    });
                }
                return _searchOrderCommand;
            }
        }

        private RelayCommand _searchClientCommand;
        public RelayCommand SearchClientCommand
        {
            get
            {
                if (_searchClientCommand == null)
                {
                    _searchClientCommand = new RelayCommand((o) =>
                    {
                        if (SearchText != string.Empty)
                        {
                            Clients = DataWorker.SelectAllClientsTable().Where(c => $"{c.Firstname}{c.Lastname}{c.Fathername}{c.Id}{c.Email}".ToLower().Contains(SearchText.ToLower())).ToList();
                        }
                        else
                        {
                            Clients = DataWorker.SelectAllClientsTable();
                        }
                    });
                }
                return _searchClientCommand;
            }
        }

        private RelayCommand _openAddFoodWindow;
        public RelayCommand OpenAddFoodWindow
        {
            get
            {
                if (_openAddFoodWindow == null)
                {
                    _openAddFoodWindow = new RelayCommand((o) =>
                    {
                        AddFoodViewModel addFoodViewModel = new AddFoodViewModel(this);
                        CreatedWindow.CreateWindow(addFoodViewModel);
                    });
                }

                return _openAddFoodWindow;
            }
        }

        private RelayCommand _openEditFoodWindow;
        public RelayCommand OpenEditFoodWindow
        {
            get
            {
                if (_openEditFoodWindow == null)
                {
                    _openEditFoodWindow = new RelayCommand((o) =>
                    {
                        EditFoodViewModel editFoodViewModel = new EditFoodViewModel(this);
                        CreatedWindow.CreateWindow(editFoodViewModel);
                    });
                }

                return _openEditFoodWindow;
            }
        }

        private RelayCommand _openEditCategoriesWindow;
        public RelayCommand OpenEditCategoriesWindow
        {
            get
            {
                if(_openEditCategoriesWindow == null)
                {
                    _openEditCategoriesWindow = new RelayCommand((o) =>
                    {
                        EditCategoryViewModel editCategoriViewModel = new EditCategoryViewModel(this);
                        CreatedWindow.CreateWindow(editCategoriViewModel);
                    });
                }
                return _openEditCategoriesWindow;
            }
        }
                                
        private RelayCommand _openAddCategoriesWindow;
        public RelayCommand OpenAddCategoriesWindow
        {
            get
            {
                if (_openAddCategoriesWindow == null)
                {
                    _openAddCategoriesWindow = new RelayCommand((o) =>
                    {
                        AddCategoryViewModel addCategoriViewModel = new AddCategoryViewModel();
                        CreatedWindow.CreateWindow(addCategoriViewModel);
                    });
                }

                return _openAddCategoriesWindow;
            }
        }

        private RelayCommand _openRemoveCategoryWindow;
        public RelayCommand OpenRemoveCategoryWindow
        {
            get
            {
                if (_openRemoveCategoryWindow == null)
                {
                    _openRemoveCategoryWindow = new RelayCommand((o) =>
                    {
                       
                        
                        string text = "Выберете категорию";
                        List<object> list = DataWorker.SelectAllCategories().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);
                        
                    
                    });
                }
                return _openRemoveCategoryWindow;
            }
        }

        private RelayCommand _openRemoveFoodWindow;
        public RelayCommand OpenRemoveFoodWindow
        {
            get
            {
                if (_openRemoveFoodWindow == null)
                {
                    _openRemoveFoodWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете товар";
                        List<object> list = DataWorker.SelectAllFood().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);
                        CreatedWindow.CreateWindow(removeItemViewModel);
                     
                    });
                }
                return _openRemoveFoodWindow;
            }
        }

        private RelayCommand _openEditOrdersWindow;
        public RelayCommand OpenEditOrdersWindow
        {
            get
            {
                if (_openEditOrdersWindow == null)
                {
                    _openEditOrdersWindow = new RelayCommand((o) =>
                    {
                        EditOrderViewModel editOrdersViewModel = new EditOrderViewModel(this);
                        CreatedWindow.CreateWindow(editOrdersViewModel);
                    });
                }
                return _openEditOrdersWindow;
            }
        }

        private RelayCommand _openAddOrdersWindow;
        public RelayCommand OpenAddOrdersWindow
        {
            get
            {
                if (_openAddOrdersWindow == null)
                {
                    _openAddOrdersWindow = new RelayCommand((o) =>
                    {
                        AddOrderViewModel addOrderViewModel = new AddOrderViewModel(this);
                        CreatedWindow.CreateWindow(addOrderViewModel);
                    });
                }

                return _openAddOrdersWindow;
            }
        }

        private RelayCommand _openRemoveOrderWindow;
        public RelayCommand OpenRemoveOrdersWindow
        {
            get
            {
                if (_openRemoveOrderWindow == null)
                {
                    _openRemoveOrderWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете заказ";
                        List<object> list = DataWorker.SelectAllOrders().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveOrderWindow;
            }
        }



        private RelayCommand _openEditClientsWindow;
        public RelayCommand OpenEditClientsWindow
        {
            get
            {
                if (_openEditClientsWindow == null)
                {
                    _openEditClientsWindow = new RelayCommand((o) =>
                    {
                        EditClientViewModel editClientsViewModel = new EditClientViewModel(this);
                        CreatedWindow.CreateWindow(editClientsViewModel);
                    });
                }
                return _openEditClientsWindow;
            }
        }

        private RelayCommand _openAddClientsWindow;
        public RelayCommand OpenAddClientsWindow
        {
            get
            {
                if (_openAddClientsWindow == null)
                {
                    _openAddClientsWindow = new RelayCommand((o) =>
                    {
                        AddClientViewModel addClientViewModel = new AddClientViewModel(this);
                        CreatedWindow.CreateWindow(addClientViewModel);
                    });
                }

                return _openAddClientsWindow;
            }
        }

        private RelayCommand _openRemoveClientWindow;
        public RelayCommand OpenRemoveClientsWindow
        {
            get
            {
                if (_openRemoveClientWindow == null)
                {
                    _openRemoveClientWindow = new RelayCommand((o) =>
                    {
                        string text = "Выберете клиента";
                        List<object> list = DataWorker.SelectAllClients().Select(x => (object)x).ToList();
                        RemoveItemViewModel removeItemViewModel = new RemoveItemViewModel(text, list, this);

                        CreatedWindow.CreateWindow(removeItemViewModel);

                    });
                }
                return _openRemoveClientWindow;
            }
        }





    }

}
