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

namespace Cursach.Views
{
    /// <summary>
    /// Interaction logic for LogPage.xaml
    /// </summary>
    public partial class LogPage : Page
    {
        private Operations ops;

        public LogPage()
        {
            InitializeComponent();
            MainWindow currWindow = (MainWindow)App.Current.MainWindow;
            currWindow.Title = "Logs";
            currWindow.Height = 550 ;
            currWindow.Width = 700;
            ops = new Operations();


            dataGrid.ItemsSource = ops.GetActions().Reverse();
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.Column.Header.ToString() == "ActUser")
            {
                e.Column.Header = "USER";
            }

            if (e.Column.Header.ToString() == "ActPatient")
            {
                e.Column.Header = "PATIENT";
            }

            if (e.Column.Header.ToString() == "ActCar")
            {
                e.Column.Header = "CAR";
            }

            if (e.Column.Header.ToString() == "NumberInStock")
            {
                e.Column.Header = "Number";
            }

            if (e.Column.Header.ToString() == "NumberInStock")
            {
                e.Column.Header = "Number";
            }
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            DataGridCellInfo cellInfo = dataGrid.CurrentCell;
            DataGridColumn column = cellInfo.Column;
            int selectedColumn = column.DisplayIndex;
            Action selectedAction = (Action)dataGrid.SelectedItem;

            Operations ops = new Operations();

            Console.WriteLine(selectedColumn);

            if(selectedColumn == 1)
            {
                int userId = selectedAction.ActUser;

                foreach(User u in ops.GetUsers())
                {

                    if (u.ID == userId)
                    {
                        UserWindow window = new UserWindow(u);
                        window.Show();
                    }                 
                }
            }

            if (selectedColumn == 2)
            {
                int patientId = selectedAction.ActPatient;

                foreach (Patient p in ops.GetPatients())
                {
                    if (patientId == p.ID)
                    {
                        PatientWindow window = new PatientWindow(p);
                        window.Show();
                    }

                }
            }

            if (selectedColumn == 3)
            {
                int carId = selectedAction.ActCar;
                foreach(Car c in ServiceClass.Cars)
                {
                    if(c.ID == carId)
                    {
                        CarWindow window = new CarWindow(c);
                        window.Show();
                    }
                }

            }
        }
    }
}
