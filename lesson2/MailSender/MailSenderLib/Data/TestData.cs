using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Data
{
    public static class TestData
    {
        public static Server[] Servers { get; } = Enumerable.Range(0, 10).Select(i => new Server
        {
            Name = $"Сервер {i}",
            Address = $"smtp.server{i}.ru",
            Port = 25,
            UserName = $"User {i}",
            Password = $"Password{i}"
        }).ToArray();

        public static Sender[] Senders { get; } = Enumerable.Range(0, 10).Select(i => new Sender
        {
            Name = $"User {i}",
            Address = $"user{i}@yandex.ru"
        }).ToArray();

        

        public static Messege[] Messeges { get; } = Enumerable.Range(0, 10).Select(i => new Messege
        {
            subject = $"Тема {i}",
            body = $"Текст письма №{i}"
        }).ToArray();
    }
}
