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
    /// Interaction logic for LecturerCreation.xaml
    /// </summary>
    public partial class LecturerCreation : Window
    {
        public LecturerCreation()
        {
            InitializeComponent();
        }

        private void CheckBtn_Click(object sender, RoutedEventArgs e)
        {
            IJsonFileHandler<LecturerAccount> jsonFileHandler = new JsonFileHandler<LecturerAccount>();


            string UsernameText = usernameTXT.Text;
            string PasswordText = PasswordTXT.Text;

            LecturerAccount user = new LecturerAccount(UsernameText, PasswordText, jsonFileHandler);



            user.CreateNewAccount(UsernameText, PasswordText);

            MessageBox.Show("done");
        }
    }
}
