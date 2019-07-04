/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:MailSender"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using MailSenderLib.Data;
using MailSenderLib.Services;
using MailSenderLib.Services.Linq2SQL;
using MailSenderLib.Data.Linq2SQL;
using MailSenderLib.Services.InMemory;


namespace MailSender.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<RecipientsDataContext>())
                SimpleIoc.Default.Register(() => new RecipientsDataContext());

            SimpleIoc.Default.Register<IRecipientsDataService, RecipientsDataServiceLinq2SQL>();
            SimpleIoc.Default.Register<IServerDataServices, ServerDataInMemory>();
            SimpleIoc.Default.Register<ISenderDataServices, SenderDataInMemory>();

            SimpleIoc.Default.Register<MainWindowViewModel>();

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public MainWindowViewModel MainWindow => ServiceLocator.Current.GetInstance<MainWindowViewModel>();
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}