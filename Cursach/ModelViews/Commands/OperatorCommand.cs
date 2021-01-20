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
using System.Net.Mail;
using System.Net;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cursach.Views;

namespace Cursach.ModelViews.Commands
{
    class OperatorCommand : ICommand
    {
        private OperatorPage page;

        public OperatorCommand(OperatorPage page)
        {
            this.page = page;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Random r = new Random();
            int carId = 0;
            int time = r.Next(500, 1000);

            if (page.carList.SelectedItem == null)
            {
                MessageBox.Show("Выберите экипаж!");
                return;
            }


            string carName = (page.carList.SelectedItem as ListBoxItem).Name;
            Console.WriteLine(carName);

            string fname = page.fnameBox.Text.Trim(' ');
            string lname = page.lnameBox.Text.Trim(' ');
            string ageString = page.ageBox.Text.Trim(' ');
            string address = page.addressBox.Text.Trim(' ');
            string symptoms = page.symptomsBox.Text;

            if (fname == String.Empty || lname == String.Empty || ageString == String.Empty || address == String.Empty || symptoms == String.Empty)
            {
                MessageBox.Show("Заполните все поля!");
                return;
            }

            int age = 0;

            try
            {
                age = Convert.ToInt32(ageString);
            }
            catch (FormatException)
            {
                MessageBox.Show("Возраст подаётся в виде числа!");
                return;
            }

            if (carName == "car1Item")
            {
                if (page.car1Item.Background == Brushes.Red)
                {
                    MessageBox.Show("Экипаж на выезде! Выберите свободный автомобиль");
                    return;
                }

                carId = 0;
                ServiceClass.Cars[0].Time = time;
            }

            if (carName == "car2Item")
            {
                if (page.car2Item.Background == Brushes.Red)
                {
                    MessageBox.Show("Экипаж на выезде! Выберите свободный автомобиль");
                    return;
                }
                carId = 1;
                ServiceClass.Cars[1].Time = time;
            }

            if (carName == "car3Item")
            {
                if (page.car3Item.Background == Brushes.Red)
                {
                    MessageBox.Show("Экипаж на выезде! Выберите свободный автомобиль");
                    return;
                }
                carId = 2;
                ServiceClass.Cars[2].Time = time;
            }

            if (carName == "car4Item")
            {
                if (page.car4Item.Background == Brushes.Red)
                {
                    MessageBox.Show("Экипаж на выезде! Выберите свободный автомобиль");
                    return;
                }
                carId = 3;
                ServiceClass.Cars[3].Time = time;
            }

            if (carName == "car5Item")
            {
                if (page.car5Item.Background == Brushes.Red)
                {
                    MessageBox.Show("Экипаж на выезде! Выберите свободный автомобиль");
                    return;
                }
                carId = 4;
                ServiceClass.Cars[4].Time = time;
            }


            Operations ops = new Operations();

            ops.AddPatient(fname, lname, age, address, symptoms);
            ops.AddAction(carId + 1, ops.GetLastId(), ServiceClass.CurrUser.ID, time, DateTime.Now.ToString());

            page.fnameBox.Text = "";
            page.lnameBox.Text = "";
            page.ageBox.Text = "";
            page.addressBox.Text = "";
            page.symptomsBox.Text = "";
            MessageBox.Show("Successfully!");
            page.carList.SelectedIndex = -1;

            //sending email

            string res = $"First name: {fname}\nLast name: {lname}\nAge: {ageString}\nAddress: {address} \nSymtoms: {symptoms}";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("ilnest9357@gmail.com", "w.w.w.2000"),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("ilnest9357@gmail.com"),
                Subject = "Вызов скорой помощи",
                Body = res,
                IsBodyHtml = false,
            };
            mailMessage.To.Add("gloryi380507185632@gmail.com");

            smtpClient.Send(mailMessage);
        }
    }
}
