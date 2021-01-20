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
    class OperatorPageCommand: ICommand
    {
        private MainMenu page;

        public OperatorPageCommand(MainMenu page)
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
            page.NavigationService.Navigate(new OperatorPage());                       
        }
    }
}
