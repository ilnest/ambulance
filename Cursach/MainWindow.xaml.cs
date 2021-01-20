using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Threading;
using System.Threading.Tasks;
using System.Windows;
using Cursach.Views;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursach
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            ServiceClass.Connection = new SqlConnection(ServiceClass.connectionString);
            ServiceClass.Connection.Open();

            Console.WriteLine(DateTime.Now.ToString());

            frame.NavigationService.Navigate(new LoginPage());

            //Initializing service class
            ServiceClass.Cars = new List<Car>();

            List<Point> points1 = new List<Point> {new Point(206, 93), new Point(231, 133) , new Point(285, 184) , new Point(318, 205), new Point(332, 214), new Point(355, 220), new Point(352, 245), new Point(342, 243),
            new Point(323, 234),new Point(318, 237),new Point(307, 232),new Point(280, 261),new Point(195, 157),new Point(162, 115), new Point(206, 93)};
            Car car1 = new Car(1, "Mercedes-Benz Sprinter", "12HAG95", points1, 10);
            ServiceClass.Cars.Add(car1);

            List<Point> points2 = new List<Point> { new Point(461, 48), new Point(581, 108), new Point(579, 129), new Point(565, 142), new Point(579, 129), new Point(565, 142), new Point(579, 155), new Point(564, 169), new Point(553, 163),
            new Point(547, 176), new Point(557, 191), new Point(557, 214), new Point(564, 237), new Point(513, 234), new Point(501, 243), new Point(512, 318), new Point(406, 308), new Point(430, 91) };
            Car car2 = new Car(2, "Toyota Hiace", "45JOS16", points2, 60);
            ServiceClass.Cars.Add(car2);

            List<Point> points3 = new List<Point> { new Point(114, 456), new Point(340, 354), new Point(436, 361), new Point(453, 313), new Point(511, 321), new Point(415, 454), new Point(414, 474) };
            Car car3 = new Car(3, "Toyota Hiace", "31HAG34", points3, 0);
            ServiceClass.Cars.Add(car3);

            List<Point> points4 = new List<Point> { new Point(608, 1), new Point(556, 95), new Point(461, 49), new Point(431, 37), new Point(337, 21), new Point(315, 58), new Point(346, 63), new Point(428, 91), new Point(464, 51), new Point(557, 95) };
            Car car4 = new Car(4, "Tesla Y", "35HAG89", points4, 0);
            ServiceClass.Cars.Add(car4);

            List<Point> points5 = new List<Point> { new Point(105, 347), new Point(85, 309), new Point(64, 212), new Point(102, 204), new Point(91, 170), new Point(91, 141), new Point(129, 139), new Point(165, 119), new Point(206, 172), new Point(191, 192), new Point(182, 210), new Point(179, 244), new Point(194, 302) };
            Car car5 = new Car(5, "Mercedes-Benz Sprinter", "67JOB45", points5, 0);
            ServiceClass.Cars.Add(car5);

            randomTest = new Random();
            Operations ops = new Operations();
        
        }

        private Random randomTest;

        public void getDates()
        {
            DateTime endDate = new DateTime(2020, 12, 11,22,22,1);
            DateTime startDate = new DateTime(2019, 12, 11, 22, 22, 1);

            TimeSpan timeSpan = endDate - startDate;
            TimeSpan newSpan = new TimeSpan(randomTest.Next(1, 30), randomTest.Next(0, 59), randomTest.Next(0, 59), randomTest.Next(0, 59));
            DateTime newDate = startDate + newSpan;

            Console.WriteLine(newDate);

            string str = "";
        }

        void divideStr()
        {

            string str = Console.ReadLine();
            Console.WriteLine(str);
        }

        //void MakeNewAction(string fname, string lname)
        //{
        //    Operations ops = new Operations();
        //    ops.Add

        //    ops.AddAction();
        //}
    }
}
