using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Services;
using MailSenderLib.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GalaSoft.MvvmLight.CommandWpf;
using MailSenderLib.Data.BaseEntityes;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly IRecipientsDataService _RecipientsDataService;
        private readonly IServerDataServices _ServerDataServices;
        private readonly ISenderDataServices _SenderDataServices;

        private string _Title = "Рассыльщик почты";

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        private string _Status = "Готов!";

        public string Status
        {
            get => _Status;
            set => Set(ref _Status, value);
        }

        private ObservableCollection<Recipient> _Recipients;
        public ObservableCollection<Recipient> Recipients
        {
            get => _Recipients;
            private set => Set(ref _Recipients, value);
        }

        private Recipient _CurrentRecipient;

        private ObservableCollection<Recipient> BackRecipients;
        private ObservableCollection<Server> _Servers = new ObservableCollection<Server>();
        public ObservableCollection<Server> Servers
        {
            get => _Servers;
            private set => Set(ref _Servers, value);
        }
        private ObservableCollection<Sender> _Senders = new ObservableCollection<Sender>();
        public ObservableCollection<Sender> Senders
        {
            get => _Senders;
            private set => Set(ref _Senders, value);
        }
        public Recipient CurrentRecipient
        {
            get => _CurrentRecipient;
            set => Set(ref _CurrentRecipient, value);
        }
        private string _Name;
        public string Name
        {
            get => _Name;
            set
            {
                value = value.ToLower();
                Set(ref _Name, value);
                if (string.IsNullOrWhiteSpace(value))
                {
                    Recipients = BackRecipients;
                    return;
                }
                //value = value.ToLower();
                //Set(ref _Name, value);
                Recipients= new ObservableCollection<Recipient>(BackRecipients.AsParallel()
                    .Where((e) => e.Name.ToLower().Contains(_Name)));
            }
        }
        public ICommand UpdateDataCommand { get; }
        public ICommand CreateRecipientCommand { get; }
        public ICommand SaveRecipientCommand { get; }
        public ICommand DeleteRecipientCommand { get; }
        

        public MainWindowViewModel(IRecipientsDataService recipientsDataService, IServerDataServices serverDataServices, 
            ISenderDataServices senderDataServices)
        {
            _SenderDataServices = senderDataServices;
            _ServerDataServices = serverDataServices;
            _RecipientsDataService = recipientsDataService;
            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, CanUpdateDataCommandExecute);
            CreateRecipientCommand = new RelayCommand(OnCreateRecipientCommandExecuted, CanCreateRecipientCommandExecute);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientCommandExecuted, CanSaveRecipientCommandExecuted);
            DeleteRecipientCommand = new RelayCommand(OnDeleteRecipientComand, CanDeleteRecipientCommandExecute);
        }

        private void OnDeleteRecipientComand()
        {
            _RecipientsDataService.Delete(_CurrentRecipient);
            _Recipients.Remove(_CurrentRecipient);
        }
        private bool CanDeleteRecipientCommandExecute()
        {
            return !(_CurrentRecipient is null);
        }
        private bool CanCreateRecipientCommandExecute() => true;
        private bool CanSaveRecipientCommandExecuted(Recipient recipient)
        {
            return (_CurrentRecipient?.IsNameValid() ?? false) & (_CurrentRecipient?.IsAddressValid() ?? false);
        }
        private void OnSaveRecipientCommandExecuted(Recipient obj)
        {
            _RecipientsDataService.Edit(obj);
            //UpdateData();
        }

        private void OnCreateRecipientCommandExecuted()
        {
            var new_recipient = new Recipient
            {
                Name = "Новый получатель",
                Address = "recipient@server.com"
            };
            _RecipientsDataService.Add(new_recipient);
            _Recipients.Add(new_recipient);
            CurrentRecipient = new_recipient;
        }

        private bool CanUpdateDataCommandExecute() => true;

        private void OnUpdateDataCommandExecuted()
        {
            UpdateData();
        }

        public void UpdateData()
        {
            Recipients = new ObservableCollection<Recipient>(_RecipientsDataService.GetAll());
            BackRecipients = new ObservableCollection<Recipient>(Recipients);

            void UpdateData<T>(IDataServices<T> Service, ObservableCollection<T> Collection)
                where T : Entity
            {
                Collection.Clear();
                foreach (var entity in Service.GetAll())
                    Collection.Add(entity);
            }

            UpdateData(_ServerDataServices, Servers);
            UpdateData(_SenderDataServices, Senders);

        }
    }
}
