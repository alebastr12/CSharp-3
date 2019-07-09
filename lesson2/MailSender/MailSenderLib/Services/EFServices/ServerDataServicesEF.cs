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

        public override void Edit(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Address = item.Address;
            db_item.Name = item.Name;
            db_item.Password = item.Password;
            db_item.Port = item.Port;
            db_item.UserName = item.UserName;
            db_item.UseSSL = item.UseSSL;

            _db.SaveChanges();
        }

        public override async Task EditAsync(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = await GetByIdAsync(item.Id).ConfigureAwait(false);
            if (db_item is null) return;

            db_item.Address = item.Address;
            db_item.Name = item.Name;
            db_item.Password = item.Password;
            db_item.Port = item.Port;
            db_item.UserName = item.UserName;
            db_item.UseSSL = item.UseSSL;

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
