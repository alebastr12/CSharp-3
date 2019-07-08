using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;
using System.Net;
using System.Net.Mail;
using System.Security;
using System.Threading;

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
            try
            {
                using (var message = new MailMessage())
                {    
                    message.To.Add(new MailAddress(To.Address, To.Name));
                    message.From=new MailAddress(From.Address, From.Name);
                    message.Subject = Message.subject;
                    message.Body = Message.body;

                    using (var client = new SmtpClient(_Server.Address, _Server.Port))
                    {
                        client.EnableSsl = _Server.UseSSL;
                        client.Credentials = new NetworkCredential(_Server.UserName, _Server.Password);
                        client.Send(message);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Send(Message Message, Sender From, IEnumerable<Recipient> To)
        {
            foreach (var item in To)
            {
                Recipient recipient= item;
                ThreadPool.QueueUserWorkItem(p => Send(Message, From, recipient));
            }
        }
    }
}
