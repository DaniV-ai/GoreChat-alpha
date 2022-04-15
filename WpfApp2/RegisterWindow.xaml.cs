using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
// email
using MimeKit;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Search;
using MailKit.Security;
namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public int code = -1;

        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void register_btn_Click(object sender, RoutedEventArgs e)
        {
            string username = username_tb.Text;
            string email = email_tb.Text;
            string pass = pass_tb.Password;

            if (username_tb.Text == "")
            {
                MessageBox.Show("Enter something to the username field. Your friends will look for you by it");
                return;
            }
            if (email_tb.Text == "")
            {
                MessageBox.Show("Enter something to the E-Mail field. We will verificate you by it");
                return;
            }
            if (!(new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$").IsMatch(email_tb.Text)))
            {
                MessageBox.Show("I don`t think entered E-Mail is correct. Check it one more time. We will verificate you by this E-Mail");
                return;
            }
            if (pass_tb.Password == "")
            {
                MessageBox.Show("Enter something to the password field. You will need it at next authorization");
                return;
            }
            if (pass_tb.Password != confirmPass_tb.Password)
            {
                MessageBox.Show("Passwords are different. Check them out and make them same");
                return;
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GoreChat", "no-reply@gorechat.com"));
            message.To.Add(new MailboxAddress(username, email));
            message.Subject = "GoreChat - Confirmation";

            Random codeGen = new Random();
            code = codeGen.Next(100000, 999999);

            message.Body = new TextPart("plain")
            {
                Text = username + ", here`s your confirmation in GoreChat " + code.ToString()
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 465, SecureSocketOptions.SslOnConnect);
                client.Authenticate("no.reply.gorechat@gmail.com", "GoreApp1");
                var options = FormatOptions.Default.Clone();
                if (client.Capabilities.HasFlag(SmtpCapabilities.UTF8))
                    options.International = true;
                client.Send(options, message);
                client.Disconnect(true);
            }

            ConfirmEmailWindow confirmWindow = new ConfirmEmailWindow(code);
            confirmWindow.ShowDialog();

            // TODO : 

            if (confirmWindow.DialogResult.Value)
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
