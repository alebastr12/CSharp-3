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
        protected readonly Data.Linq2SQL.RecipientsDataContext _db;

        public RecipientsDataServiceLinq2SQL(Data.Linq2SQL.RecipientsDataContext db)
        {
            _db = db;
        }
        public void Add(Recipient item)
        {
            if (item.Id != 0) return;
            _db.Recipient.InsertOnSubmit(new Data.Linq2SQL.Recipient
            {
                Name = item.Name,
                Adddress = item.Address,
                Description = item.Description
            });
            _db.SubmitChanges();
        }

        public void Delete(Recipient item)
        {
            var db_item = _db.Recipient.FirstOrDefault((i) => i.Id == item.Id);
            if (db_item is null) return;
            _db.Recipient.DeleteOnSubmit(db_item);
            _db.SubmitChanges();
        }

        public IEnumerable<Recipient> GetAll()
        {
            return _db.Recipient.Select(r => new Recipient
            {
                Id = r.Id,
                Name = r.Name,
                Address = r.Adddress,
                Description = r.Description
            })
           .ToArray();
        }

        public void Edit(Recipient item)
        {
            _db.SubmitChanges();
        }

        public Recipient GetById(int id)
        {
            return _db.Recipient.Select(r => new Recipient
           {
               Id = r.Id,
               Name = r.Name,
               Address = r.Adddress,
               Description = r.Description
           })
           .FirstOrDefault(r => r.Id == id);
        }
    }
}
