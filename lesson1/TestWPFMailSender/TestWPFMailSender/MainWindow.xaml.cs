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
                try
                {
                    foreach (string email in EmailsTo)
                    {
                        Email.To.Add(new Person(email, "Имя"));
                    }
                    Email.Password = PasswordBox.SecurePassword;
                    Email.SendMessage(SubjectBox.Text, BodyBox.Text);
                    MessageDialog dialog = new MessageDialog("Почта отправлена успешно!", "Успех!!!", MessageImage.Information);
                    dialog.ShowDialog();
                }
                catch (Exception ex)
                {
                    MessageDialog ErrDialog = new MessageDialog($"Ошибка при отправке почты!\r\n{ex.Message}", "Ошибка!", MessageImage.Error);
                    ErrDialog.ShowDialog();
                }
            }
        }
    }
}
