using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;

namespace MailSenderLib.Services
{
    public class SmtpMailSenderServices : IMailSenderServices
    {
        public IMailSender CreateSender(Server Server) =>
            new SmtpMailSender(Server.Address, Server.Port, Server.UseSSL, Server.UserName, Server.Password);
    }
}
