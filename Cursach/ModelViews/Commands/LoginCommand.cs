using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cursach.Views;

namespace Cursach.ModelViews.Commands
{
    class LoginCommand: ICommand
    {
        private LoginPage page;

        public LoginCommand(LoginPage page)
        {
            this.page = page;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Operations ops = new Operations();
            string login = page.loginBox.Text.Trim(' ');
            string password = page.passwordBox.Text.Trim(' ');

            if (ops.Login(login, password))
            {
                this.page.NavigationService.Navigate(new MainMenu());
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
