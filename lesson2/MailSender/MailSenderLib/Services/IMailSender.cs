using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;

namespace MailSenderLib.Services
{
    public interface IMailSender
    {
        void Send(Message Message, Sender From, Recipient To);
        void Send(Message Message, Sender From, IEnumerable<Recipient> To);
    }
}
