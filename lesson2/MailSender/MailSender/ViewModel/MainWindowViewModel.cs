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
using GalaSoft.MvvmLight.Command;

namespace MailSender.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {

        private readonly IRecipientsDataService _RecipientsDataService;
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
                Recipients= new ObservableCollection<Recipient>(BackRecipients
                    .Where((e) => e.Name.ToLower().Contains(_Name)).AsParallel());
            }
        }
        public ICommand UpdateDataCommand { get; }
        public ICommand CreateRecipientCommand { get; }
        public ICommand SaveRecipientCommand { get; }
        public ICommand DeleteRecipientCommand { get; }
        

        public MainWindowViewModel(IRecipientsDataService recipientsDataService)
        {
            _RecipientsDataService = recipientsDataService;
            UpdateDataCommand = new RelayCommand(OnUpdateDataCommandExecuted, CanUpdateDataCommandExecute);
            CreateRecipientCommand = new RelayCommand(OnCreateRecipientCommandExecuted, CanCreateRecipientCommandExecute);
            SaveRecipientCommand = new RelayCommand<Recipient>(OnSaveRecipientCommandExecuted, CanSaveRecipientCommandExecuted);
            DeleteRecipientCommand = new RelayCommand(OnDeleteRecipientComand, CanDeleteRecipientCommandExecute);
        }

        private void OnDeleteRecipientComand()
        {
            _RecipientsDataService.Delete(_CurrentRecipient);
            UpdateData();
        }
        private bool CanDeleteRecipientCommandExecute() => _CurrentRecipient?.IsValid() ?? false;
        private bool CanCreateRecipientCommandExecute() => true;
        private bool CanSaveRecipientCommandExecuted(Recipient recipient) => recipient?.IsValid() ?? false;
        private void OnSaveRecipientCommandExecuted(Recipient obj)
        {
            _RecipientsDataService.Update(obj);
            UpdateData();
        }

        private void OnCreateRecipientCommandExecuted()
        {
            var new_recipient = new Recipient
            {
                Name = "Новый получатель",
                Adddress = "recipient@server.com"
            };
            _RecipientsDataService.Create(new_recipient);
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
        }
    }
}
