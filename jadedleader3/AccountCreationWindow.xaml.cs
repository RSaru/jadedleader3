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
    /// Interaction logic for AccountCreationWindow.xaml
    /// </summary>
    public partial class AccountCreationWindow : Window
    {
        public AccountCreationWindow()
        {
            InitializeComponent();

            
        }

        private void SignupBtn_Click(object sender, RoutedEventArgs e)
        {

            IJsonFileHandler<UserAccount> jsonFileHandler = new JsonFileHandler<UserAccount>();
            

            string UsernameText = UsernameTxt.Text;
            string PasswordText = PasswordTxt.Text;

            UserAccount user = new UserAccount(UsernameText, PasswordText, jsonFileHandler);

            

            user.CreateNewAccount(UsernameText, PasswordText);

            MessageBox.Show("done");

            

            
        }
    }
}
