using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.BaseEntityes;
using MailSenderLib.Data;

namespace MailSenderLib.Services.EFServices
{
    public abstract class DataInEF<T> : IDataServices<T> where T : Entity
    {
        protected readonly Data.EF.MailSenderDB _db;
        public DataInEF(Data.EF.MailSenderDB db)
        {
            _db = db;
        }

        public void Add(T item)
        {
            if (item.Id != 0) return;
            switch (item)
            {
                case Recipient recipient:
                    _db.Recipients.Add(recipient);
                    break;
                case Sender sender:
                    _db.Senders.Add(sender);
                    break;
                case Message message:
                    _db.Messages.Add(message);
                    break;
                case Server server:
                    _db.Servers.Add(server);
                    break;
                default:
                    break;
            }
            _db.SaveChanges();
        }

        public void Delete(T item)
        {
            switch (item)
            {
                case Recipient recipient:
                    var rec_item = _db.Recipients.FirstOrDefault(e => recipient.Id == e.Id);
                    if (rec_item is null) return;
                    _db.Recipients.Remove(recipient);
                    break;
                case Sender sender:
                    var sender_item = _db.Senders.FirstOrDefault(e => sender.Id == e.Id);
                    if (sender_item is null) return;
                    _db.Senders.Remove(sender);
                    break;
                case Message message:
                    var message_item = _db.Senders.FirstOrDefault(e => message.Id == e.Id);
                    if (message_item is null) return;
                    _db.Messages.Remove(message);
                    break;
                case Server server:
                    var server_item = _db.Senders.FirstOrDefault(e => server.Id == e.Id);
                    if (server_item is null) return;
                    _db.Servers.Remove(server);
                    break;
                default:
                    break;
            }
            _db.SaveChanges();
        }

        public void Edit(T item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null) return;
            switch (item)
            {
                case Recipient recipient:
                    (db_item as Recipient).Name = recipient.Name;
                    (db_item as Recipient).Address = recipient.Address;
                    (db_item as Recipient).Description = recipient.Description;
                    break;
                case Sender sender:
                    (db_item as Sender).Name = sender.Name;
                    (db_item as Sender).Address = sender.Address;
                    (db_item as Sender).Description = sender.Description;
                    break;
                case Message message:
                    (db_item as Message).body = message.body;
                    (db_item as Message).subject = message.subject;
                    break;
                case Server server:
                    (db_item as Server).Address = server.Address;
                    (db_item as Server).Name = server.Name;
                    (db_item as Server).Password = server.Password;
                    (db_item as Server).Port = server.Port;
                    (db_item as Server).UserName = server.UserName;
                    (db_item as Server).UseSSL = server.UseSSL;
                    break;
                default:
                    break;
            }
        }

        public abstract IEnumerable<T> GetAll();

        public abstract T GetById(int id);
    }
}
