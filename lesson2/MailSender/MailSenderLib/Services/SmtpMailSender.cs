using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;

namespace MailSenderLib.Services
{
    class SmtpMailSender : IMailSender
    {
        private readonly Server _Server;

        public SmtpMailSender(string Host, int Port, bool UseSSL, string Login, string Password)
        {
            _Server = new Server()
            {
                Address = Host,
                Port = Port,
                UseSSL = UseSSL,
                UserName = Login,
                Password = Password
            };
        }
        public SmtpMailSender(Server server)
        {
            _Server = server;
        }
        public void Send(Message Message, Sender From, Recipient To)
        {
            throw new NotImplementedException();
        }

        public void Send(Message Message, Sender From, IEnumerable<Recipient> To)
        {
            throw new NotImplementedException();
        }
    }
}
