using MailSenderLib.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services.InMemory
{
    public class ServerDataInMemory : DataInMemory<Server>, IServerDataServices
    {
        public ServerDataInMemory()
        {
            for (var i = 1; i <= 10; i++)
                _Items.Add(new Server { Id = i, Name = $"Сервер {i}", Address = $"smtp.server{i}.com" });
        }
        public override void Edit(Server item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));
            Server db_item = GetById(item.Id);
            if (db_item is null) return;
            db_item.Name = item.Name;
            db_item.Password = item.Password;
            db_item.Port = item.Port;
            db_item.UserName = item.UserName;
            db_item.UseSSL = item.UseSSL;
            db_item.Address = item.Address;
        }
    }
}
