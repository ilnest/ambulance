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
    class OperatorPageVM
    {
        public ICommand OperatorCommand { get; set; }
        private OperatorPage page;

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


        public OperatorPageVM(OperatorPage page)
        {
            this.page = page;
            OperatorCommand = new OperatorCommand(page);

            ops = new Operations();
        }
    }
}
