using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace MailSenderLib.Data.BaseEntityes
{
    public abstract class Human : NamedEntity
    {
        [Required,MaxLength(50)]
        public string Address { get; set; }
        public string Description { get; set; }
    }
}
