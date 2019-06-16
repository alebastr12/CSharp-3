using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWPFMailSender
{
    class Server
    {
        public string ServerName { get; set; }
        public int Port { get; set; }
        public override string ToString()
        {
            return ServerName + $":{Port}";
        }
    }
}
