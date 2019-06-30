using MailSenderLib.Data.BaseEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Data
{
    public class Message : Entity
    {
        public string subject { get; set; }

        public string body { get; set; }
    }
}