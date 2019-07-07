using MailSenderLib.Data.BaseEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace MailSenderLib.Data
{
    public class Server : NamedEntity
    {
        [Required,MaxLength(50)]
        public string Address { get; set; }
        [Required]
        public int Port { get; set; } = 25;
        [Required]
        public bool UseSSL { get; set; } = true;
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
