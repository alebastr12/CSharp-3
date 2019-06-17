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

namespace TestWPFMailSender
{
    public enum MessageImage
    {
        Information,
        Error
    }
    /// <summary>
    /// Логика взаимодействия для MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : Window
    {
        public MessageDialog(string Message, string Title, MessageImage img)
        {
            
            InitializeComponent();
            this.Message.Text = Message;
            this.Title = Title;
            if (img == MessageImage.Error)
            {
                Img.Source = new BitmapImage(new Uri(@"img\icons8-err-100.png", UriKind.RelativeOrAbsolute));
            }
            else if (img == MessageImage.Information)
            {
                Img.Source = new BitmapImage(new Uri(@"img\icons8-inf-100.png", UriKind.RelativeOrAbsolute));
            }
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
