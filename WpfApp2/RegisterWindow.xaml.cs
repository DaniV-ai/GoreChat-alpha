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
using Entity_Classes;
using System.Security.Cryptography;

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

            // Username field validations
            if (username_tb.Text == "")
            {
                MessageBox.Show("Enter something to the username field. Your friends will look for you by it");
                return;
            }
            if (username_tb.Text.Contains(" "))
            {
                MessageBox.Show("Enter something else to the username field. There is no spaces allowed");
                return;
            }
            //Check via DB
            //if (username_tb.Text is unique)

            // E-Mail field validations
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

            // Password fields validations
            if (pass_tb.Password == "")
            {
                MessageBox.Show("Enter something to the password field. You will need it at next authorization");
                return;
            }
            if (pass_tb.Password.Length < 8)
            {
                MessageBox.Show("Password must be at least 8 symbols or it won`t be safe");
                return;
            }
            if (pass_tb.Password != confirmPass_tb.Password)
            {
                MessageBox.Show("Passwords are different. Check them out and make them same");
                return;
            }

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("GoreChat", "no.reply.gorechat@gmail.com"));
            message.To.Add(new MailboxAddress(username, email));
            message.Subject = "GoreChat - Confirmation";

            Random codeGen = new Random();
            code = codeGen.Next(100000, 999999);


            message.Body = new TextPart("html")
            {
                Text = "<!DOCTYPE html PUBLIC '-//W3C//DTD XHTML 1.0 Transitional//EN' 'http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd'><html xmlns='http://www.w3.org/1999/xhtml' xmlns:o='urn:schemas-microsoft-com:office:office' style='width:100%;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'><head><meta charset='UTF-8'><meta content='width=device-width, initial-scale=1' name='viewport'><meta name='x-apple-disable-message-reformatting'><meta http-equiv='X-UA-Compatible' content='IE=edge'><meta content='telephone=no' name='format-detection'><title>Новий лист</title><!--[if (mso 16)]><style type='text/css'>     a {text-decoration: none;}     </style><![endif]--><!--[if gte mso 9]><style>sup { font-size: 100% !important; }</style><![endif]--><!--[if gte mso 9]><xml> <o:OfficeDocumentSettings> <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch> </o:OfficeDocumentSettings> </xml><![endif]--><!--[if !mso]><!-- --><link href='https://fonts.googleapis.com/css?family=Roboto:400,400i,700,700i' rel='stylesheet'><!--<![endif]--><style type='text/css'>#outlook a {	padding:0;}.ExternalClass {	width:100%;}.ExternalClass,.ExternalClass p,.ExternalClass span,.ExternalClass font,.ExternalClass td,.ExternalClass div {	line-height:100%;}.es-button {	mso-style-priority:100!important;	text-decoration:none!important;}a[x-apple-data-detectors] {	color:inherit!important;	text-decoration:none!important;	font-size:inherit!important;	font-family:inherit!important;	font-weight:inherit!important;	line-height:inherit!important;}.es-desk-hidden {	display:none;	float:left;	overflow:hidden;	width:0;	max-height:0;	line-height:0;	mso-hide:all;}.es-button-border:hover a.es-button, .es-button-border:hover button.es-button {	background:#3498db!important;	border-color:#3498db!important;}.es-button-border:hover {	border-color:#1f68b1 #1f68b1 #1f68b1 #1f68b1!important;	background:#3498db!important;}td .es-button-border:hover a.es-button-1566986321426 {	background:#2980d9!important;	border-color:#2980d9!important;}td .es-button-border-1566986321449:hover {	background:#2980d9!important;}[data-ogsb] .es-button {	border-width:0!important;	padding:10px 40px 10px 40px!important;}@media only screen and (max-width:600px) {p, ul li, ol li, a { line-height:150%!important } h1, h2, h3, h1 a, h2 a, h3 a { line-height:120%!important } h1 { font-size:26px!important; text-align:center } h2 { font-size:24px!important; text-align:center } h3 { font-size:20px!important; text-align:center } .es-header-body h1 a, .es-content-body h1 a, .es-footer-body h1 a { font-size:26px!important } .es-header-body h2 a, .es-content-body h2 a, .es-footer-body h2 a { font-size:24px!important } .es-header-body h3 a, .es-content-body h3 a, .es-footer-body h3 a { font-size:20px!important } .es-menu td a { font-size:13px!important } .es-header-body p, .es-header-body ul li, .es-header-body ol li, .es-header-body a { font-size:13px!important } .es-content-body p, .es-content-body ul li, .es-content-body ol li, .es-content-body a { font-size:14px!important } .es-footer-body p, .es-footer-body ul li, .es-footer-body ol li, .es-footer-body a { font-size:13px!important } .es-infoblock p, .es-infoblock ul li, .es-infoblock ol li, .es-infoblock a { font-size:11px!important } *[class='gmail-fix'] { display:none!important } .es-m-txt-c, .es-m-txt-c h1, .es-m-txt-c h2, .es-m-txt-c h3 { text-align:center!important } .es-m-txt-r, .es-m-txt-r h1, .es-m-txt-r h2, .es-m-txt-r h3 { text-align:right!important } .es-m-txt-l, .es-m-txt-l h1, .es-m-txt-l h2, .es-m-txt-l h3 { text-align:left!important } .es-m-txt-r img, .es-m-txt-c img, .es-m-txt-l img { display:inline!important } .es-button-border { display:block!important } a.es-button, button.es-button { font-size:14px!important; display:block!important; border-left-width:0px!important; border-right-width:0px!important } .es-btn-fw { border-width:10px 0px!important; text-align:center!important } .es-adaptive table, .es-btn-fw, .es-btn-fw-brdr, .es-left, .es-right { width:100%!important } .es-content table, .es-header table, .es-footer table, .es-content, .es-footer, .es-header { width:100%!important; max-width:600px!important } .es-adapt-td { display:block!important; width:100%!important } .adapt-img { width:100%!important; height:auto!important } .es-m-p0 { padding:0px!important } .es-m-p0r { padding-right:0px!important } .es-m-p0l { padding-left:0px!important } .es-m-p0t { padding-top:0px!important } .es-m-p0b { padding-bottom:0!important } .es-m-p20b { padding-bottom:20px!important } .es-mobile-hidden, .es-hidden { display:none!important } tr.es-desk-hidden, td.es-desk-hidden, table.es-desk-hidden { width:auto!important; overflow:visible!important; float:none!important; max-height:inherit!important; line-height:inherit!important } tr.es-desk-hidden { display:table-row!important } table.es-desk-hidden { display:table!important } td.es-desk-menu-hidden { display:table-cell!important } .es-menu td { width:1%!important } table.es-table-not-adapt, .esd-block-html table { width:auto!important } table.es-social { display:inline-block!important } table.es-social td { display:inline-block!important } }</style></head> <body style='width:100%;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;padding:0;Margin:0'><div class='es-wrapper-color' style='background-color:transparent'><!--[if gte mso 9]><v:background xmlns:v='urn:schemas-microsoft-com:vml' fill='t'> <v:fill type='tile' color='transparent' origin='0.5, 0' position='0.5, 0'></v:fill> </v:background><![endif]--><table class='es-wrapper' width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;padding:0;Margin:0;width:100%;height:100%;background-repeat:repeat;background-position:center top;background-color:transparent'><tr style='border-collapse:collapse'><td valign='top' style='padding:0;Margin:0'><table cellpadding='0' cellspacing='0' class='es-content' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr style='border-collapse:collapse'><td class='es-info-area' align='center' style='padding:0;Margin:0'><table bgcolor='#FFFFFF' class='es-content-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px'><tr style='border-collapse:collapse'><td align='left' bgcolor='#1f1c59' style='Margin:0;padding-top:10px;padding-bottom:10px;padding-left:20px;padding-right:20px;background-color:#1f1c59'><table cellpadding='0' cellspacing='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td align='center' valign='top' style='padding:0;Margin:0;width:560px'><table cellpadding='0' cellspacing='0' width='100%' bgcolor='#1f1c59' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:#1f1c59' role='presentation'><tr style='border-collapse:collapse'><td align='center' class='es-infoblock' style='padding:0;Margin:0;line-height:0px;font-size:0px;color:#CCCCCC'><img class='adapt-img' src='https://jckxhu.stripocdn.email/content/guids/CABINET_b894da79416996aca29a384b0da9a509/images/izobrazenie_20220418_122728472.png' alt style='display:block;border:0;outline:none;text-decoration:none;-ms-interpolation-mode:bicubic' width='469'></td> </tr></table></td></tr></table></td></tr></table></td> </tr></table><table class='es-content' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><table class='es-content-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px' cellspacing='0' cellpadding='0' bgcolor='transparent' align='center'><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;padding-left:20px;padding-right:20px;background-color:#1f1c59' bgcolor='#1f1c59' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;border-width:5px;border-style:solid;border-color:transparent;background-color:transparent' width='100%' cellspacing='0' cellpadding='0' bgcolor='transparent' role='presentation'><tr style='border-collapse:collapse'><td bgcolor='transparent' align='center' style='padding:0;Margin:0;padding-bottom:5px;padding-top:10px'><h3 style='Margin:0;line-height:36px;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;font-size:30px;font-style:normal;font-weight:bold;color:#f47847'>Dear " + username + "</h3> </td></tr><tr style='border-collapse:collapse'><td bgcolor='transparent' align='center' style='padding:0;Margin:0;padding-top:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;color:#16b695;font-size:18px'>This mail was entered as confirmal in registration proccess in GoreChat App.</p></td></tr><tr style='border-collapse:collapse'><td bgcolor='transparent' align='center' style='padding:0;Margin:0;padding-top:5px;padding-bottom:5px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;color:#16b695;font-size:18px'>If you wasn`t asking for confirmation in our app just ignore this letter.</p></td></tr></table></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;background-position:center bottom' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:600px'><table style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;background-position:center bottom;background-color:#ffffff;border-radius:0px 0px 5px 5px' width='100%' cellspacing='0' cellpadding='0' bgcolor='#ffffff' role='presentation'><tr style='border-collapse:collapse'><td height='15' align='center' bgcolor='#1f1c59' style='padding:0;Margin:0'></td></tr></table></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;padding-left:20px;padding-right:20px;background-position:center bottom' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td height='10' align='center' style='padding:0;Margin:0'></td></tr></table></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;background-position:center bottom' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:600px'><table style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;background-position:center bottom;background-color:#ffffff;border-radius:5px 5px 0px 0px' width='100%' cellspacing='0' cellpadding='0' bgcolor='#ffffff' role='presentation'><tr style='border-collapse:collapse'><td height='16' align='center' bgcolor='#1f1c59' style='padding:0;Margin:0'></td></tr></table></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;padding-left:20px;padding-right:20px;background-color:#1f1c59' bgcolor='#1f1c59' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td class='es-m-p20b' align='left' style='padding:0;Margin:0;width:560px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;color:#16b695;font-size:18px'>Here is you confirmation code</p></td> </tr></table></td></tr></table></td></tr><tr style='border-collapse:collapse'><td style='padding:0;Margin:0;background-position:center bottom' align='left'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:600px'><table style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:separate;border-spacing:0px;background-position:center bottom;background-color:#ffffff;border-radius:0px 0px 5px 5px' width='100%' cellspacing='0' cellpadding='0' bgcolor='#ffffff' role='presentation'><tr style='border-collapse:collapse'><td height='32' align='center' bgcolor='#1f1c59' style='padding:0;Margin:0'></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:600px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td height='60' align='center' style='padding:0;Margin:0'></td></tr></table></td></tr></table></td> </tr><tr style='border-collapse:collapse'><td style='Margin:0;padding-top:15px;padding-left:20px;padding-right:20px;padding-bottom:25px;background-color:#1f1c59' bgcolor='#1f1c59' align='left'><table cellspacing='0' cellpadding='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:108px;color:#f47847;font-size:72px'><h1>" + code + "</h1></p></td></tr></table></td> </tr></table></td></tr></table></td> </tr></table><table class='es-footer' cellspacing='0' cellpadding='0' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%;background-color:transparent;background-repeat:repeat;background-position:center top'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><table class='es-footer-body' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px' cellspacing='0' cellpadding='0' bgcolor='#FFFFFF' align='center'><tr style='border-collapse:collapse'><td align='left' style='Margin:0;padding-top:15px;padding-left:20px;padding-right:20px;padding-bottom:25px'><table cellspacing='0' cellpadding='0' width='100%' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td height='20' align='center' style='padding:0;Margin:0'></td> </tr></table></td></tr></table></td></tr></table></td> </tr></table><table cellpadding='0' cellspacing='0' class='es-content' align='center' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;table-layout:fixed !important;width:100%'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><table bgcolor='transparent' class='es-content-body' align='center' cellpadding='0' cellspacing='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-color:transparent;width:600px'><tr style='border-collapse:collapse'><td align='left' style='Margin:0;padding-left:20px;padding-right:20px;padding-top:30px;padding-bottom:30px;background-color:#1f1c59' bgcolor='#1f1c59'><table width='100%' cellspacing='0' cellpadding='0' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table width='100%' cellspacing='0' cellpadding='0' role='presentation' style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px'><tr style='border-collapse:collapse'><td align='center' style='padding:0;Margin:0'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;color:#16b695;font-size:18px'>Gore Codery Inc. All rights are reserved 2022</p> </td></tr></table></td></tr><tr style='border-collapse:collapse'><td valign='top' align='center' style='padding:0;Margin:0;width:560px'><table style='mso-table-lspace:0pt;mso-table-rspace:0pt;border-collapse:collapse;border-spacing:0px;background-position:center top' width='100%' cellspacing='0' cellpadding='0' role='presentation'><tr style='border-collapse:collapse'><td class='es-m-txt-c' align='center' style='padding:0;Margin:0;padding-top:5px;padding-bottom:10px'><p style='Margin:0;-webkit-text-size-adjust:none;-ms-text-size-adjust:none;mso-line-height-rule:exactly;font-family:roboto, 'helvetica neue', helvetica, arial, sans-serif;line-height:27px;color:#16b695;font-size:18px'>This letter sends automaticly, you don`t need to responde to it.</p></td></tr></table></td></tr></table></td></tr></table></td></tr></table></td></tr></table></div></body></html>"
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
                //add
                ChatDB chat = new ChatDB();
                User user = new User();
                user.Username = username_tb.Text;
                user.Email = email_tb.Text;
                
                byte[] hash;
                byte[] password = Encoding.ASCII.GetBytes(pass_tb.Password);

                SHA256 mySHA256 = SHA256.Create();
                hash = mySHA256.ComputeHash(password);


                user.Hash = Encoding.ASCII.GetString(hash);
                MessageBox.Show(user.Hash);
                chat.Users.Add(user);
                chat.SaveChanges();
                
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
    }
}
