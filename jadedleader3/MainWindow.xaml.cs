using System;
using System.CodeDom;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using jadedleader3.Classes;
using jadedleader3.FileManager;
using jadedleader3.Services;

namespace jadedleader3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            Lectures lectures = new Lectures();
            lectures.CourseName = "Applied Computear Science";
            lectures.ModuleCode = "1132";
            lectures.ModuleName = "Software Engineeraing";
            lectures.LecturerName = "Hueang-Min Son";
            lectures.RoomNumber = "69441";
            lectures.DayOfTheWeek = new string[] {"Thursday"};
            lectures.StartTime = DateTime.Parse("09:00:00");
            lectures.EndTime = DateTime.Parse("12:00:00");

            lectures.DeleteLecture(lectures);
        }

        private void AccountCreationPageBtn_Click(object sender, RoutedEventArgs e)
        {
            AccountCreationWindow accountCreationWindow = new AccountCreationWindow();

            accountCreationWindow.Show();

            this.Close();   
        }

        private void lecturerNavigationBtn_Click(object sender, RoutedEventArgs e)
        {
            LecturerAccountCreation lecturerAccountCreation = new LecturerAccountCreation();

            lecturerAccountCreation.Show();

            this.Close();
        }

        private void btnReturnSignUp_Click(object sender, RoutedEventArgs e)
        {

            IJsonFileHandler<LecturerAccount> lecturerFileHandler = new JsonFileHandler<LecturerAccount>();

            LoginService<LecturerAccount> LecturerLogin = new LoginService<LecturerAccount>(lecturerFileHandler);

            string username = txtUsername.Text;
            string password = txtPassword.Text;

            var login =  LecturerLogin.LoggingInUser(username, password);

            if(login == "Lecturer")
            {
                MessageBox.Show("Lecturer pathway");
            }
            else if(login == "User")
            {
                MessageBox.Show("User pathway");
            }
            else
            {
                MessageBox.Show("Nothing on file for this user!");
            }


        }
    }
}
