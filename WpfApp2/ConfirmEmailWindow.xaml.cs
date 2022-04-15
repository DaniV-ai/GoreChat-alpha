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
    /// <summary>
    /// Логика взаимодействия для ConfirmEmailWindow.xaml
    /// </summary>
    public partial class ConfirmEmailWindow : Window
    {
        int code = -1;
        public ConfirmEmailWindow(int sendedCode)
        {
            InitializeComponent();
            code = sendedCode;
            MessageBox.Show(code.ToString());
        }

        private void confirm_btn_Click(object sender, RoutedEventArgs e)
        {
            // TODO : Add user to DB

            if (!(code.ToString() == code_tb.Text))
            {
                MessageBox.Show("Entered code is incorrect. Please check it one more time and try again");
                return;
            }

            DialogResult = true;
            this.Close();
        }
    }
}
