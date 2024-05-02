using Delivery.View;
using Delivery.ViewModel.AddViewModel;
using Delivery.ViewModel.EditViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Delivery.ViewModel
{
    internal class CreatedWindow
    {
        public static void CreateWindow(object dataContext)
        {
            if (dataContext is AddFoodViewModel addFoodView)
            {
                AddFood addFood= new AddFood();
                addFood.DataContext = addFoodView;
                SettingWindow(addFood);
            }
            else if (dataContext is EditFoodViewModel editFood)
            {
                EditFood edit = new EditFood();
                edit.DataContext = editFood;
                SettingWindow(edit);
            }
            else if (dataContext is AddCategoryViewModel addCategoriesView)
            {
                AddCategory addCategory = new AddCategory();
                addCategory.DataContext = addCategoriesView;
                SettingWindow(addCategory);
            }
            else if (dataContext is EditCategoryViewModel editCategoryView)
            {
                EditCategory editCategory = new EditCategory();
                editCategory.DataContext = editCategoryView;
                SettingWindow(editCategory);
            }
            else if (dataContext is RemoveItemViewModel remove)
            {
                RemoveItem removeItem = new RemoveItem();
                removeItem.DataContext = remove;
                SettingWindow(removeItem);
            }
            else if (dataContext is AddOrderViewModel addOrderView)
            {
                AddOrder addOrder = new AddOrder();
                addOrder.DataContext = addOrderView;
                SettingWindow(addOrder);
            }
            else if (dataContext is EditOrderViewModel editOrderView)
            {
                EditOrder editOrder = new EditOrder();
                editOrder.DataContext = editOrderView;
                SettingWindow(editOrder);
            }
            else if (dataContext is AddClientViewModel addClientView)
            {
                AddClient addClient = new AddClient();
                addClient.DataContext = addClientView;
                SettingWindow(addClient);
            }
            else if (dataContext is EditClientViewModel editClientView)
            {
                EditClient editClient = new EditClient();
                editClient.DataContext = editClientView;
                SettingWindow(editClient);
            }

        }
        public static void CreateMessageBox(string message)
        {
            MessageBox.Show(message);
        }

        private static void SettingWindow(Window window)
        {
            window.Visibility = Visibility.Visible;
            window.Owner = Application.Current.MainWindow;
            window.ShowDialog();
        }
    }
}
