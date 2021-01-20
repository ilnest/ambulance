using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        private Operations ops;

        public StatisticsPage()
        {
            ops = new Operations();

            this.DataContext = new ModelViews.StatisticsPageVM(this);

            InitializeComponent();
            MainWindow currWindow = (MainWindow)App.Current.MainWindow;
            currWindow.Title = "Statistics";
            currWindow.Height = 495;
            currWindow.Width = 1350;

            SetAverageTime();
            BestCar();
            WorstCar();
        }

        public void SetAverageTime()
        {
            ObservableCollection<Action> list = new ObservableCollection<Action>();

            list = ops.GetActions();

            double average = 0;

            int temp = 0;

            foreach(Action a in list)
            {
                temp += a.SpentTime;
            }

            average = temp / list.Count;

            averageTime.Content = (average.ToString() + " минут");
        }

        public void WorstCar()
        {
            int carID = 0;

            int number = 0;
            int bestNumber = 1000;

            foreach (Car c in ServiceClass.Cars)
            {
                foreach (Action a in ops.GetActions())
                {
                    if (a.ActCar == c.ID)
                        number++;
                }

                if (number < bestNumber)
                {
                    carID = c.ID;
                    bestNumber = number;
                }
                number = 0;
            }

            string res = "ID - " + ServiceClass.Cars[carID - 1].ID + "  " + ServiceClass.Cars[carID - 1].Model + "  " + ServiceClass.Cars[carID - 1].NumberPlate;

            worst.Content = res;
        }

        public void BestCar()
        {
            int carID = 0;

            int number = 0;
            int bestNumber = 0;

            foreach(Car c in ServiceClass.Cars)
            {
                foreach(Action a in ops.GetActions())
                {
                    if (a.ActCar == c.ID)
                        number++;
                }

                if (number > bestNumber)
                {
                    carID = c.ID;
                    bestNumber = number;
                }
                number = 0;
            }

            string res = "ID - " + ServiceClass.Cars[carID - 1].ID + "  " + ServiceClass.Cars[carID - 1].Model + "  " + ServiceClass.Cars[carID - 1].NumberPlate;


            best.Content = res;
        }

    }

    public class MyClass
    {
        public MyClass()
        {
            Line1.Add(new Data() { Id = 01, Value = getNumber("01") });
            Line1.Add(new Data() { Id = 02, Value = getNumber("02") });
            Line1.Add(new Data() { Id = 03, Value = getNumber("03") });
            Line1.Add(new Data() { Id = 04, Value = getNumber("04") });
            Line1.Add(new Data() { Id = 05, Value = getNumber("05") });
            Line1.Add(new Data() { Id = 06, Value = getNumber("06") });
            Line1.Add(new Data() { Id = 07, Value = getNumber("07") });
            Line1.Add(new Data() { Id = 08, Value = getNumber("08") });
            Line1.Add(new Data() { Id = 09, Value = getNumber("09") });
            Line1.Add(new Data() { Id = 10, Value = getNumber("10") });
            Line1.Add(new Data() { Id = 11, Value = getNumber("11") });
            Line1.Add(new Data() { Id = 12, Value = getNumber("12") });
            Line1.Add(new Data() { Id = 13, Value = getNumber("13") });
            Line1.Add(new Data() { Id = 14, Value = getNumber("14") });
            Line1.Add(new Data() { Id = 15, Value = getNumber("15") });
            Line1.Add(new Data() { Id = 16, Value = getNumber("16") });
            Line1.Add(new Data() { Id = 17, Value = getNumber("17") });
            Line1.Add(new Data() { Id = 18, Value = getNumber("18") });
            Line1.Add(new Data() { Id = 19, Value = getNumber("19") });
            Line1.Add(new Data() { Id = 20, Value = getNumber("20") });
            Line1.Add(new Data() { Id = 21, Value = getNumber("21") });
            Line1.Add(new Data() { Id = 22, Value = getNumber("22") });
            Line1.Add(new Data() { Id = 23, Value = getNumber("23") });
            Line1.Add(new Data() { Id = 00, Value = getNumber("00") });

        }

        private int getNumber(string hour)
        {
            Operations ops = new Operations();

            int res = 0;

            ObservableCollection<Action> list = ops.GetActions();
            foreach(Action a in list)
            {
                DateTime time = DateTime.Parse(a.Time);
                if(time.ToString("HH") == hour)
                {
                    res++;
                }
            }

            return res;
        }

        public List<Data> Line1 { get; set; } = new List<Data>();
        public class Data
        {
            public int Value { get; set; }
            public int Id { get; set; }
        }
    }
}
