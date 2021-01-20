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
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursach.Views
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            MainWindow currWindow = (MainWindow)App.Current.MainWindow;
            currWindow.Title = "Menu";
            currWindow.Height = 600;
            currWindow.Width = 500;

            employee.Text = ServiceClass.CurrUser.FName + " " + ServiceClass.CurrUser.LName;
            this.DataContext = new ModelViews.MainMenuVM(this);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            currTime.Text = DateTime.Now.ToString();
        }
     
    }
}
