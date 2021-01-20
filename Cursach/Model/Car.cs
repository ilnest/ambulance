using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Cursach
{
    public class Car
    {
        public int ID { get; set; }
        public string Model { get; set; }
        public string NumberPlate { get; set; }
        public List<Point> Path { get; set; }
        public int Time { get; set; }
        public bool IsWorking { get; set; }

        public Ellipse CarEllipse { get; set; }

        public Car(int id, string model, string numberPlate, List<Point> path, int time)
        {
            ID = id;
            Model = model;
            NumberPlate = numberPlate;
            Time = time;

            Operations ops = new Operations();
            Path = ops.GetPoints(path);
        }

    }
}
