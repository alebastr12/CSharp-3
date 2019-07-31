namespace MailSenderLib.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MailSenderLib.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<MailSenderLib.Data.EF.MailSenderDB>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MailSenderLib.Data.EF.MailSenderDB context)
        {
            if (!context.Recipients.Any())
            {
                Recipient[] recipients = new Recipient[50];
                for (int i = 0; i < recipients.Length; i++)
                {
                    recipients[i] = new Recipient
                    {
                        Name = $"Получатель {i}",
                        Address = $"address{i}@ya.ru",
                        Description = $"Описание {i} получателя"
                    };
                }
                context.Recipients.AddRange(recipients);
            }
            if (!context.Senders.Any())
            {
                Sender[] senders = new Sender[50];
                for (int i = 0; i < senders.Length; i++)
                {
                    senders[i] = new Sender
                    {
                        Name = $"Отправитель {i}",
                        Address = $"address{i}@ya.ru",
                        Description = $"Описание {i} отправителя"
                    };
                }
                context.Senders.AddRange(senders);
            }
            if (!context.Messages.Any())
            {
                Message[] messages = new Message[50];
                for (int i = 0; i < messages.Length; i++)
                {
                    messages[i] = new Message
                    {
                        subject=$"Тема письма {i}",
                        body=$"Текст письма №{i}"
                    };
                }
                context.Messages.AddRange(messages);
            }
            if (!context.Servers.Any())
            {
                Server[] servers = new Server[50];
                for (int i = 0; i < servers.Length; i++)
                {
                    servers[i] = new Server
                    {
                        Name = $"Сервер {i}",
                        Address = $"smtp.ru",
                        UserName = $"Имя пользователя {i}",
                        Password = $"qwerty{i}",
                        UseSSL = true,
                        Port=25
                        
                    };
                }
                context.Servers.AddRange(servers);
            }
            context.SaveChanges();
        }
    }
}
