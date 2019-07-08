using MailSenderLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.InMemory
{
    public class SenderDataInMemory : DataInMemory<Sender>, ISenderDataServices
    {
        public SenderDataInMemory()
        {
            for (var i = 1; i < 10; i++)
                _Items.Add(new Sender { Id = i, Name = $"Отправитель {i}", Address = $"sender{i}@server.com" });
        }
        public override void Edit(Sender item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            Sender db_item = GetById(item.Id);
            if (db_item is null) return;
            db_item.Name = item.Name;
            db_item.Address = item.Address;
            db_item.Description = item.Description;
        }
    }
}
