using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderLib.Services
{
    public interface IDataReport<T>
    {
        void GenerateReport(IEnumerable<T> items, string filename);
        Task GenerateReportAsync(IEnumerable<T> items, string filename);
    }
}
