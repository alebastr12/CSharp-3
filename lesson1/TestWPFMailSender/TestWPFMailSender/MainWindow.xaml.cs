using System;
using System.Windows;


namespace TestWPFMailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EmailSendServiceClass Email;
        public MainWindow()
        {
            InitializeComponent();
            Email = new EmailSendServiceClass();
            DataContext = Email;
            
        }

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            string[] EmailsTo = EmailToBox.Text.Split(';');
            if (EmailsTo.Length > 0)
            {
                Email.To.Clear();
                foreach(string email in EmailsTo)
                {
                    Email.To.Add(new Person(email,"Имя"));
                }
                Email.Password = PasswordBox.SecurePassword;
                //Email.EmailServer.Port = Convert.ToInt32(PortBox.Text);
                try
                {
                    Email.SendMessage(SubjectBox.Text, BodyBox.Text);
                    MessageBox.Show("Почта отправлена успешно!", "Успех!!!",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при отправке почты \r\n{ex.Message}", "Ошибка!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
