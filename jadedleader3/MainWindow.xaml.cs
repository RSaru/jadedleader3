using jadedleader3.Classes;
using jadedleader3.FileManager;
using jadedleader3.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jadedleader3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string FilePath = "C:\\Users\\joshy\\source\\repos\\jadedleader3\\jadedleader3\\JsonFiles\\UserAccounts.json";

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

        private void btnReturnSignUp_Click(object sender, RoutedEventArgs e)
        {

            

            IJsonFileHandler<UserAccount> userJsonFileHandler = new JsonFileHandler<UserAccount>();

            AuthenticationService<UserAccount> userAuthentication = new AuthenticationService<UserAccount>(userJsonFileHandler);

            IJsonFileHandler<LecturerAccount> lecturerJsonFileHandler = new JsonFileHandler<LecturerAccount>();

            AuthenticationService<LecturerAccount> lecturerAuthentication = new AuthenticationService<LecturerAccount>(lecturerJsonFileHandler);

            string userAccess = userAuthentication.Authenticate(txtUsername.Text, txtPassword.Text, FilePath);

            string lecturerAccess = lecturerAuthentication.Authenticate(txtUsername.Text, txtPassword.Text, FilePath);

            if(userAccess == "User")
            {
                //send them to the user window with the buttons disabled (not sure if this is what we actually want

                MessageBox.Show("User pathway");
            }
            else if(userAccess == "Lecturer")
            {
                MessageBox.Show("Lecturer pathway");
            }
            else
            {
                MessageBox.Show("Not a clue what's happening");
            }
            
                
        }

        private void testerbtn_Click(object sender, RoutedEventArgs e)
        {
            LecturerCreation lecture = new LecturerCreation();

            lecture.Show();

            this.Close();
        }
    }
}
