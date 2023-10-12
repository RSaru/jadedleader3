using jadedleader3.Classes;
using jadedleader3.FileManager;
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

namespace jadedleader3
{
    /// <summary>
    /// Interaction logic for LecturerAccountCreation.xaml
    /// </summary>
    public partial class LecturerAccountCreation : Window
    {
        public LecturerAccountCreation()
        {
            InitializeComponent();
        }

        private void LecturerAccountCreationBtn_Click(object sender, RoutedEventArgs e)
        {

            IJsonFileHandler<LecturerAccount> lecturerHandler = new JsonFileHandler<LecturerAccount>();

            string usernameText = UsernameTxt.Text;
            string passwordText = PasswordTxt.Text; 

            LecturerAccount lecturerAccount = new LecturerAccount(usernameText, passwordText, lecturerHandler);

            lecturerAccount.CreateNewAccount(usernameText, passwordText);

            MessageBox.Show("Lecturer Account created");
        }

        private void btnLogIn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow themainwindow = new MainWindow();

            themainwindow.Show();

            this.Close();

        }
    }
}
