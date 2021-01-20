using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Text;
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
using Cursach.ModelViews;


namespace Cursach.Views
{
    /// <summary>
    /// Interaction logic for OperatorPage.xaml
    /// </summary>
    public partial class OperatorPage : Page
    {
        private int counter1;
        private int counter2;
        private int counter3;
        private int counter4;
        private int counter5;

        private int i1; // location of the car
        private int i2;
        private int i3;
        private int i4;
        private int i5;

        Operations ops;

        public OperatorPage()
        {
            ops = new Operations();

            counter1 = 0;
            counter2 = 0;
            counter3 = 0;
            counter4 = 0;
            counter5 = 0;

            InitializeComponent();
            MainWindow currWindow = (MainWindow)App.Current.MainWindow;
            currWindow.Title = "Menu";
            currWindow.Height = 650;
            currWindow.Width = 1250;

            this.DataContext = new OperatorPageVM(this);

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        void timer_Tick(object sender, EventArgs e)
        {

            Car car1 = ServiceClass.Cars[0];
            Car car2 = ServiceClass.Cars[1];
            Car car3 = ServiceClass.Cars[2];
            Car car4 = ServiceClass.Cars[3];
            Car car5 = ServiceClass.Cars[4];

            if (car2.Time != counter2 / 2 && car2.Time != 0)
            {
                car2Item.Background = Brushes.Red;
                secondCnvCarEllipse.Fill = Brushes.Red;

                int step = i2 % (car2.Path.Count - 1);

                Canvas.SetLeft(secondCnvCar, car2.Path[step].X);
                Canvas.SetTop(secondCnvCar, car2.Path[step].Y);

                counter2++;
                i2++;
            }
            else
            {
                counter2 = 0;
                car2.Time = 0;
                car2.IsWorking = false;
                car2Item.Background = Brushes.Green;
                secondCnvCarEllipse.Fill = Brushes.Yellow; ;
            }

            if (car1.Time != 0 && car1.Time != counter1 / 2)  //i1/2 because of the timestep is 0.5s, not 1s 
            {
                car1Item.Background = Brushes.Red;
                firstCnvCarEllipse.Fill = Brushes.Red;

                int step = i1 % (car1.Path.Count - 1);

                Canvas.SetLeft(firstCnvCar, car1.Path[step].X);
                Canvas.SetTop(firstCnvCar, car1.Path[step].Y);

                counter1++;
                i1++;
            }
            else
            {
                counter1 = 0;
                car1.Time = 0;
                car1.IsWorking = false;
                car1Item.Background = Brushes.Green;
                firstCnvCarEllipse.Fill = Brushes.Yellow;
            }

            if (car3.Time != counter3 / 2 && car3.Time != 0)
            {
                car3Item.Background = Brushes.Red;
                thirdCnvCarEllipse.Fill = Brushes.Red;

                int step = i3 % (car3.Path.Count - 1);

                Canvas.SetLeft(thirdCnvCar, car3.Path[step].X);
                Canvas.SetTop(thirdCnvCar, car3.Path[step].Y);

                counter3++;
                i3++;
            }
            else
            {
                counter3 = 0;
                car3.Time = 0;
                car3.IsWorking = false;
                car3Item.Background = Brushes.Green;
                thirdCnvCarEllipse.Fill = Brushes.Yellow;
            }

            if (car4.Time != counter4 / 2 && car4.Time != 0)
            {
                car4Item.Background = Brushes.Red;
                fourthCnvCarEllipse.Fill = Brushes.Red;

                int step = i4 % (car4.Path.Count - 1);

                Canvas.SetLeft(fourthCnvCar, car4.Path[step].X);
                Canvas.SetTop(fourthCnvCar, car4.Path[step].Y);

                counter4++;
                i4++;
            }
            else
            {
                counter4 = 0;
                car4.Time = 0;
                car4.IsWorking = false;
                car4Item.Background = Brushes.Green;
                fourthCnvCarEllipse.Fill = Brushes.Yellow;
            }


            if (car5.Time != counter5 / 2 && car5.Time != 0)
            {
                car5Item.Background = Brushes.Red;
                fifthCnvCarEllipse.Fill = Brushes.Red;

                int step = i5 % (car5.Path.Count - 1);

                Canvas.SetLeft(fifthCnvCar, car5.Path[step].X);
                Canvas.SetTop(fifthCnvCar, car5.Path[step].Y);

                counter5++;
                i5++;
            }
            else
            {
                counter5 = 0;
                car5.Time = 0;
                car5.IsWorking = false;
                car5Item.Background = Brushes.Green;
                fifthCnvCarEllipse.Fill = Brushes.Yellow; ;
            }
        }




       
    }
}
