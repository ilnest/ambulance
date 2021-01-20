using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    public class Patient
    {
        public int ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Symptoms { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }

        public Patient(int id, string fName, string lName, int age, string address, string symptoms)
        {
            ID = id;
            FName = fName;
            LName = lName;
            Age = age;
            Address = address;
            Symptoms = symptoms;
        }
    }
}
