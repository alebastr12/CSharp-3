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

        public override void Edit(Message item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = GetById(item.Id);
            if (db_item is null) return;

            db_item.subject = item.subject;
            db_item.body = item.body;

            _db.SaveChanges();
        }

        public override async Task EditAsync(Message item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            var db_item = await GetByIdAsync(item.Id).ConfigureAwait(false);
            if (db_item is null) return;

            db_item.subject = item.subject;
            db_item.body = item.body;

            await _db.SaveChangesAsync().ConfigureAwait(false);
        }
    }
}
