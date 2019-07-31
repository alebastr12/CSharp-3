using MailSenderLib.Data.BaseEntityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MailSenderLib.Data
{
    public class Message : Entity
    {
        [Required,MaxLength(100)]
        public string subject { get; set; }
        [Required, MaxLength(100)]
        public string body { get; set; }
    }
}