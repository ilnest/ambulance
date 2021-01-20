using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cursach
{
    class Action
    {
        public int ID { get; set;}
        public int ActUser { get; set; }
        public int ActPatient { get; set; }
        public int ActCar { get; set; }
        public int SpentTime { get; set; }
        public string Time { get; set; }

        public Action(int id, int user, int car, int patient, int spentTime, string time)
        {
            SpentTime = spentTime;
            ID = id;
            Time = time;
            ActUser = user;
            ActCar = car;
            ActPatient = patient;
        }
    }
}
