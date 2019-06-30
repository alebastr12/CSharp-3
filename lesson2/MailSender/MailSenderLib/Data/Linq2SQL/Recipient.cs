using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Data.Linq2SQL
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
                        if (!IsNameValid()) return "Имя не может быть менее трех символов.";
                        break;
                    case nameof(Adddress):
                        if (!IsAddressValid()) return "Недопустимый формат адреса.";
                        break;
                }

                return "";
            }
        }

        public string Error => "";

        public bool IsNameValid()
        {
            return !(Name is null | Name.Length < 4);
        }
        public bool IsAddressValid()
        {
            string[] val = Adddress.Split('@');
            if (val.Count() < 2) return false;
            return !(string.IsNullOrWhiteSpace(val[0]) | string.IsNullOrWhiteSpace(val[1]));
        }
    }
}
