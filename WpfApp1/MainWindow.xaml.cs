using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Mail;
using System.Net;

namespace WpfApp1
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

        private void btnEnvoyer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string from = txtFrom.Text;                 // Ton adresse Gmail
                string password = txtPassword.Password;     // Clé d’application Google 
                string to = txtTo.Text;
                string subject = txtSubject.Text;
                string body = txtMessage.Text;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587)
                {
                    Credentials = new NetworkCredential(from, password),
                    EnableSsl = true
                };

                MailMessage mail = new MailMessage(from, to, subject, body);

                client.Send(mail);

                MessageBox.Show("Mail envoyé avec succès !", "Succès", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur : {ex.Message}", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}