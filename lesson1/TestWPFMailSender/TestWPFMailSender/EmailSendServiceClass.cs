using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace TestWPFMailSender
{
    class EmailSendServiceClass
    {
        public Person From { get; set; }
        public List<Person> To { get; set; }
        public Server EmailServer { get; set; } 
        public SecureString Password { set; private get; }

        public EmailSendServiceClass()
        {
            To = new List<Person>();
            EmailServer = new Server() //Забиваю данные по умолчанию
            {
                ServerName = "smtp.mail.ru",
                Port = 25
            };
            From = new Person("thegrace12@bk.ru", "Александр");
        }

        public bool SendMessage(string subject, string body)
        {
            try
            {
                using (var message = new MailMessage())
                {
                    if (!From.isNotNull())
                    {
                        throw new ArgumentNullException("Данные отправителя не могут быть пустыми!");
                    }
                    message.From = new MailAddress(From.Email,From.Name);
                    if (To.Count == 0)
                    {
                        throw new ArgumentNullException("Нет ни одного адресата!");
                    }
                    foreach(Person v in To)
                    {
                        if (!v.isNotNull())
                        {
                            throw new ArgumentNullException("Данные адресата не могут быть пустыми!");
                        }
                        message.To.Add(new MailAddress(v.Email,v.Name));
                    }
                    
                    message.Subject = subject;
                    message.Body = body;

                    using (var client = new SmtpClient(EmailServer.ServerName, EmailServer.Port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(From.Email, Password); //TODO: надо что то придумать с логином

                        client.Send(message);

                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
