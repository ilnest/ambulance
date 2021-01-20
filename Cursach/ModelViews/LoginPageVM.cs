using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Cursach.Views;
using Cursach.ModelViews.Commands;

namespace Cursach.ModelViews
{
    class LoginPageVM
    {

        public ICommand LoginCommand { get; set; }
        private LoginPage page;

        public LoginPageVM(LoginPage page)
        {
            this.page = page;
            LoginCommand = new LoginCommand(page);
        }

    }
}
