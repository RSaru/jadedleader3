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
            InitializeComponent();
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
                TimetableView time = new TimetableView();
                time.Show();
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
