using MailSenderLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.EF;

namespace MailSenderLib.Services.EFServices
{
    public class RecipientDataServicesEF : DataInEF<Recipient>, IRecipientsDataService
    {
        public RecipientDataServicesEF(MailSenderDB db) : base(db) { }
        public override IEnumerable<Recipient> GetAll()
        {
            return _db.Recipients;
        }

        public override Recipient GetById(int id)
        {
            return _db.Recipients.Find(id);
        }
    }
}
