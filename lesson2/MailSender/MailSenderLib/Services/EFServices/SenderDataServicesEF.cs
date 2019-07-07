using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;
using MailSenderLib.Data.EF;

namespace MailSenderLib.Services.EFServices
{
    public class SenderDataServicesEF : DataInEF<Sender>, ISenderDataServices
    {
        public SenderDataServicesEF(MailSenderDB db):base(db)
        {

        }
        public override IEnumerable<Sender> GetAll()
        {
            return _db.Senders;
        }

        public override Sender GetById(int id)
        {
            return _db.Senders.Find(id);
        }
    }
}
