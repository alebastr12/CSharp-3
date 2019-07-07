using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;
using MailSenderLib.Data.EF;

namespace MailSenderLib.Services.EFServices
{
    public class ServerDataServicesEF : DataInEF<Server>, IServerDataServices
    {
        public ServerDataServicesEF(MailSenderDB db):base(db)
        {

        }
        public override IEnumerable<Server> GetAll()
        {
            return _db.Servers;
        }

        public override Server GetById(int id)
        {
            return _db.Servers.Find(id);
        }
    }
}
