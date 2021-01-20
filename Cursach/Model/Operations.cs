using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Animation;
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
    class Operations
    {
        private SqlConnection connection;

        public Operations()
        {
            connection = ServiceClass.Connection;
        }

        public List<Point> GetPoints(List<Point> list)
        {
            List<Point> points = new List<Point>();

            for (int i = 0; i < list.Count; i++)
            {
                int next = i + 1;

                if (i == list.Count - 1)
                    next = 0;

                double a = list[next].X - list[i].X;
                double b = list[next].Y - list[i].Y;
                double c = Math.Sqrt(a * a + b * b);

                double stepNumber = c / 0.7;
                double xStep = a / stepNumber;
                double yStep = b / stepNumber;

                for (int iter = 0; iter < stepNumber; iter++)
                {
                    points.Add(new Point(list[i].X + xStep * iter, list[i].Y + yStep * iter));
                }
            }

            return points;
        }

        public void AddAction(int carID, int patientID, int userID, int spentTime, string time)
        {
            string sqlExpression = string.Format("INSERT INTO Actions (car_id, user_id, patient_id, spent_time, time) VALUES({0}, {1}, {2}, {3}, '{4}')", carID, userID, patientID, spentTime, time);

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                Console.WriteLine(sqlExpression);
            }
        }

        public int GetLastId()
        {
            string sqlExpression = "SELECT CAST(SCOPE_IDENTITY() AS INT)";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            int id = (int)command.ExecuteScalar();
            return id;
        }

        public void AddPatient(string fName, string lName, int age, string address, string symptoms)
        {
            string sqlExpression = string.Format("INSERT INTO Patient (fname, lname, age, address, symptoms) VALUES('{0}', '{1}', {2}, '{3}', '{4}')", fName, lName, age, address, symptoms);

            SqlCommand command = new SqlCommand(sqlExpression, connection);
            command.ExecuteNonQuery();
        }

        public ObservableCollection<Patient> GetPatients()
        {
            ObservableCollection<Patient> listOfPatients = new ObservableCollection<Patient>();

            string getItemsSql = string.Format("SELECT * FROM Patient");
            SqlCommand getPatients = new SqlCommand(getItemsSql, connection);
            SqlDataReader reader = getPatients.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return listOfPatients;
            }


            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object fname = reader.GetValue(1);
                object lname = reader.GetValue(2);
                object symptoms = reader.GetValue(3);
                object age = reader.GetValue(4);
                object address = reader.GetValue(5);
                listOfPatients.Add(new Patient((int)id, (string)fname, (string)lname, (int)age, (string)address, (string)symptoms));
            }

            reader.Close();
            return listOfPatients; ;
        }

        public ObservableCollection<User> GetUsers()
        {
            ObservableCollection<User> listOfUsers = new ObservableCollection<User>();

            string getUsersSql = string.Format("SELECT * FROM Users");
            SqlCommand getUsers = new SqlCommand(getUsersSql, connection);
            SqlDataReader reader = getUsers.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return listOfUsers;
            }


            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object fname = reader.GetValue(1);
                object lname = reader.GetValue(2);
                object accessLevel = reader.GetValue(3);
                object login = reader.GetValue(4);
                object password = reader.GetValue(5);
                listOfUsers.Add(new User((int)id, (string)fname, (string)lname, (int)accessLevel, (string)login, (string)password));
            }

            reader.Close();
            return listOfUsers; ;
        }

        //public ObservableCollection<Car> GetCars()
        //{
        //    ObservableCollection<Car> listOfCars = new ObservableCollection<Car>();

        //    string getUsersSql = string.Format("SELECT * FROM Car");
        //    SqlCommand getCars = new SqlCommand(getUsersSql, connection);
        //    SqlDataReader reader = getCars.ExecuteReader();
        //    if (!reader.HasRows)
        //    {
        //        reader.Close();

        //        return listOfCars;
        //    }


        //    while (reader.Read())
        //    {
        //        object id = reader.GetValue(0);
        //        object carModel = reader.GetValue(1);
        //        object numberPlate = reader.GetValue(2);
        //        listOfCars.Add(new Car((int)id, (string)fname, (string)lname, (int)accessLevel, (string)login, (string)password));
        //    }

        //    reader.Close();
        //    return listOfCars; ;
        //}

        public ObservableCollection<Action> GetActions()
        {
            ObservableCollection<Action> listOfActs = new ObservableCollection<Action>();

            string getActsSql = string.Format("SELECT * FROM Actions");
            SqlCommand getActs = new SqlCommand(getActsSql, connection);
            SqlDataReader reader = getActs.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();

                return listOfActs;
            }


            while (reader.Read())
            {
                object id = reader.GetValue(0);
                object carID = reader.GetValue(1);
                object userID = reader.GetValue(2);
                object patientID = reader.GetValue(3);
                object spentTime = reader.GetValue(4);
                object time = reader.GetValue(5);

                int actId = (int)id;
                int actCarId = (int)carID;
                int actUserID = (int)userID;
                int actPatientId = (int)patientID;
                int actSpentTime = (int)spentTime;
                string actTime = (string)time;

                listOfActs.Add(new Action(actId, actUserID, actCarId, actPatientId, actSpentTime, (string)actTime));
            }

            reader.Close();
            return listOfActs; ;
        }

        public bool Login(string login, string password)
        {
            string sqlExpression = $"SELECT * FROM Users WHERE Login='{login}'";
            SqlCommand command = new SqlCommand(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (!reader.HasRows)
            {
                reader.Close();
                return false;
            }
            else
            {
                reader.Close();
                sqlExpression = $"SELECT Password FROM Users WHERE Login='{login}'";
                command = new SqlCommand(sqlExpression, connection);
                reader = command.ExecuteReader();
                reader.Read();
                string passwordFromDB = ((string)reader.GetValue(0)).Trim(' ');
                reader.Close();
                if (password.Equals(passwordFromDB))
                {
                    sqlExpression = $"SELECT * FROM Users WHERE Login='{login}'";
                    command = new SqlCommand(sqlExpression, connection);
                    reader = command.ExecuteReader();
                    reader.Read();

                    int id = (int)reader.GetValue(0);
                    string fname = ((string)reader.GetValue(1)).Trim(' ');
                    string lname = ((string)reader.GetValue(2)).Trim(' ');
                    int accessLevel = (int)reader.GetValue(3);
                    User currUser = new User(id, fname, lname, accessLevel, login, password);
                    ServiceClass.CurrUser = currUser;

                    reader.Close();

                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
}
