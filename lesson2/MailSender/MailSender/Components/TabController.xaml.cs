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
    /// Логика взаимодействия для TabController.xaml
    /// </summary>
    public partial class TabController : UserControl
    {
        public event EventHandler ButtonLeftClick;

        public event EventHandler ButtonRightClick;

        public bool IsLeftButtonVisible
        {
            get => ButtonLeft.Visibility == Visibility.Visible;
            set => ButtonLeft.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        public bool IsRirhtButtonVisible
        {
            get => ButtonRight.Visibility == Visibility.Visible;
            set => ButtonRight.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        public TabController()
        {
            InitializeComponent();
        }

        private void OnClick_Button(object sender, RoutedEventArgs e)
        {
            if (!(sender is Button button)) return;

            switch (button.Name)
            {
                case "ButtonLeft": ButtonLeftClick?.Invoke(this, EventArgs.Empty);
                    break;
                case "ButtonRight": ButtonRightClick?.Invoke(this, EventArgs.Empty);
                    break;
                default:
                    break;
            }
        }

    }
}
