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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.Components
{
    /// <summary>
    /// Логика взаимодействия для ComboControl.xaml
    /// </summary>
    public partial class ComboControl : UserControl
    {
        public string TaxtLabel {
            get => label.Content.ToString();
            set => label.Content = value;
        }
        public System.Collections.IEnumerable ItemSource
        {
            get => combo.ItemsSource;
            set => combo.ItemsSource=value;
        }

        public DataTemplate ItemTemplate
        {
            get => combo.ItemTemplate;
            set => combo.ItemTemplate = value;
        }
        public ComboControl()
        {
            InitializeComponent();
        }
    }
}
