using MailSenderLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data.EF;

namespace MailSenderLib.Services.EFServices
{
    public class MessageDataServicesEF : DataInEF<Message>, IMessageDataServices
    {
        public MessageDataServicesEF(MailSenderDB db):base(db)
        {

        }
        public override IEnumerable<Message> GetAll()
        {
            return _db.Messages;
        }

        public override Message GetById(int id)
        {
            return _db.Messages.Find(id);
        }
    }
}
