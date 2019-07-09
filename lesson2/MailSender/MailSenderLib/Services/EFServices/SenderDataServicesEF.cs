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

        public override void Edit(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.Address = item.Address;
            db_item.Name = item.Name;
            db_item.Description = item.Description;

            _db.SaveChanges();
        }

        public override async Task EditAsync(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = await GetByIdAsync(item.Id).ConfigureAwait(false);
            if (db_item is null) return;

            db_item.Address = item.Address;
            db_item.Name = item.Name;
            db_item.Description = item.Description;

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
