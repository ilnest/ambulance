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

namespace Cursach.Views
{
    /// <summary>
    /// Interaction logic for CarWindow.xaml
    /// </summary>
    public partial class CarWindow : Window
    {
        private Car car;

        public CarWindow(Car car)
        {
            InitializeComponent();
            this.car = car;
            modelBlock.Text = car.Model;
            plateBlock.Text = car.NumberPlate;
        }
    }
}
