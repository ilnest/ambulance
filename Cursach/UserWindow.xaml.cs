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
using System.Windows.Shapes;

namespace Cursach
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        private User user;

        public UserWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            fnameBlock.Text = user.FName;
            lnameBlock.Text = user.LName;
            
            if(user.AccessLevel == 1)
            {
                positionBlock.Text = "Оператор";
            }
            else
            {
                positionBlock.Text = "Главный врач";
            }
        }
    }
}
