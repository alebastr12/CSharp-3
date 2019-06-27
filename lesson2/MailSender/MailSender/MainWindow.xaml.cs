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
using MailSender.Components;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabController_OnLeftButtonClick(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex--;
            
            TabControllerCheck();
        }
        private void TabController_OnRightButtonClick(object sender, EventArgs e)
        {
            MainTabControl.SelectedIndex++;

            TabControllerCheck();
        }

        private void ToPlane_ButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedItem = PlaneTab;

            TabControllerCheck();
        }
        private void TabControllerCheck()
        {
            TabController.IsLeftButtonVisible = MainTabControl.SelectedIndex > 0;
            TabController.IsRirhtButtonVisible = MainTabControl.SelectedIndex < MainTabControl.Items.Count - 1;
        }

        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabControllerCheck();
        }
    }
}
