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
    /// Interaction logic for PatientWindow.xaml
    /// </summary>
    public partial class PatientWindow : Window
    {
        private Patient patient;

        public PatientWindow(Patient p)
        {
            InitializeComponent();
            patient = p;

            fnameBlock.Text = patient.FName;
            lnameBlock.Text = patient.LName;
            addressBlock.Text = patient.Address;
            ageBlock.Text = patient.Age.ToString();
            symptomsBlock.Text = patient.Symptoms;
        }
    }
}
