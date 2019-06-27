using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Data
{
    public partial class Recipient : IDataErrorInfo
    {
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case nameof(Name):
                        if (Name is null) return "Пустая ссылка на строку с именем";
                        if (Name.Length < 4) return "Длина строки имени должна быть больше 3 символов";
                        break;
                    case nameof(Adddress):
                        if (Adddress is null) return "Пустая ссылка на строку с адресом";
                        string[] val = Adddress.Split('@');
                        if (val.Count() < 2) return "Недопустимый формат адреса";
                        if (string.IsNullOrWhiteSpace(val[0]) | string.IsNullOrWhiteSpace(val[1])) return "Недопустимый формат адреса";
                        break;
                }

                return "";
            }
        }

        public string Error => "";
    }
}
