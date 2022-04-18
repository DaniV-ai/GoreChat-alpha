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

namespace WpfApp2
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            // Username validation
            if (username_tb.Text == "")
            {
                MessageBox.Show("Enter something to the username field.");
                return;
            }
            if (username_tb.Text.Contains(" "))
            {
                MessageBox.Show("Enter something else to the username field. There is no spaces allowed");
                return;
            }

            // Password validation
            if (pass_tb.Password == "")
            {
                MessageBox.Show("Enter something to the password field.");
                return;
            }
            if (pass_tb.Password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 symbols or it won`t be safe");
                return;
            }

            MainTextingWindow textingWindow = new MainTextingWindow();
            textingWindow.Show();
            // TODO : Checking credentials via DB

            // Connecting DB
            // Getting data from DB
            // Comparing user data and data from DB
        }
    }
}
