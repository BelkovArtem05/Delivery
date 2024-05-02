using Delivery.Model;
using Delivery.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.ViewModel
{
    internal class LoginViewModel
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public delegate void CloseWindow();
        public CloseWindow Close { get; set; }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand
        {
            get
            {
                if (_loginCommand == null)
                {
                    _loginCommand = new RelayCommand((o) =>
                    {
                        Workers worker = DataWorker.SelectAllWorkers().FirstOrDefault(p => p.Login == Login && p.Password == Password);
                        if (worker != null)
                        {
                            MainViewModel mainViewModel = new MainViewModel(worker);
                            CreateWindow.CreateMainWindow(mainViewModel);
                            Close();
                        }
                        else
                        {
                            CreatedWindow.CreateMessageBox("Неправильный логин или пароль");
                        }
                    },
                    (o) =>
                    {
                        return Login != "" && Password != "";
                    });
                }
                return _loginCommand;
            }
        }

    }
}
