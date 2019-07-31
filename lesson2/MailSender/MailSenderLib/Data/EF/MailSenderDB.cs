using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace MailSenderLib.Data.EF
{
    public class MailSenderDB : DbContext
    {
        public MailSenderDB() :this(Properties.Settings.Default.MailSenderDBConnectionString) { }
        public MailSenderDB(string ConectionString):base(ConectionString){ }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Server> Servers { get; set; }

    }
}
