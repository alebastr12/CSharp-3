using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;

namespace MailSenderLib.Services.Linq2SQL
{
    public class RecipientsDataServiceLinq2SQL : IRecipientsDataService
    {
        protected readonly RecipientsDataContext _db;

        public RecipientsDataServiceLinq2SQL(RecipientsDataContext db)
        {
            _db = db;
        }
        public void Create(Recipient item)
        {
            if (item.Id != 0) return;
            _db.Recipient.InsertOnSubmit(item);
            _db.SubmitChanges();
        }

        public void Delete(Recipient item)
        {
            _db.Recipient.DeleteOnSubmit(item);
            _db.SubmitChanges();
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient.AsEnumerable();
        }

        public void Update(Recipient item)
        {
            _db.SubmitChanges();
        }
    }
}
