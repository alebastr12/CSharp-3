using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailSenderLib.Data;
using System.IO;
using ClosedXML.Excel;

namespace MailSenderLib.Services.Reports
{
    public class RecipientsReportService : IRecipientReportService
    {
        public void GenerateReport(IEnumerable<Recipient> items, string filename)
        {
            XLWorkbook excel = new XLWorkbook();
            var worksheet = excel.Worksheets.Add("Получатели почты");

            //Заголовки
            worksheet.Cell("A" + 1).Value = "Id";
            worksheet.Cell("B" + 1).Value = "Имя";
            worksheet.Cell("C" + 1).Value = "E-mail";
            worksheet.Cell("D" + 1).Value = "Описание";
            var rngHeaders = worksheet.Range("A1:D1");
            rngHeaders.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            rngHeaders.Style.Font.Bold = true;
            rngHeaders.Style.Font.FontColor = XLColor.DarkBlue;
            rngHeaders.Style.Fill.BackgroundColor = XLColor.Aqua;

            for (int i = 0; i < items.Count(); i++)
            {
                worksheet.Cell($"A{i + 2}").Value = items.ElementAt(i).Id;
                worksheet.Cell($"B{i + 2}").Value = items.ElementAt(i).Name;
                worksheet.Cell($"C{i + 2}").Value = items.ElementAt(i).Address;
                worksheet.Cell($"D{i + 2}").Value = items.ElementAt(i).Description;
                if (i%2==0)
                    worksheet.Range($"A{i + 2}:D{i + 2}").Style.Fill.BackgroundColor = XLColor.LightGray;
                //worksheet.Range("A:D" + 2 + i).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            }
            worksheet.Columns().AdjustToContents();         
            excel.SaveAs(filename);
            
        }

        public async Task GenerateReportAsync(IEnumerable<Recipient> items, string filename)
        {
            await Task.Run(() => GenerateReport(items, filename));
        }
    }
}
