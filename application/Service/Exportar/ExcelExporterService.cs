using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Output;
using Microsoft.IdentityModel.Tokens;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace Application.Service.Exportar
{
    public class ExcelExporterService : IExcelExporterService
    {
       
        public async Task<byte[]> ExportToExcel<T>(List<T> source)
        {
            var workbook = new XSSFWorkbook();
            var sheet = workbook.CreateSheet("Reporte");
            var rowHeader = sheet.CreateRow(0);

            var properties = typeof(T).GetProperties();

            //header
            var font = workbook.CreateFont();
            font.IsBold = true;
            var style = workbook.CreateCellStyle();
            style.SetFont(font);

            var colIndex = 0;
            var cellNro = rowHeader.CreateCell(colIndex);
            cellNro.SetCellValue("Nro.");
            cellNro.CellStyle = style;
            colIndex++;

            foreach (var property in properties)
            {
                DescriptionAttribute[] da = (DescriptionAttribute[])property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                var cell = rowHeader.CreateCell(colIndex);
                cell.SetCellValue(da[0].Description.ToString());
                cell.CellStyle = style;
                colIndex++;
            }
            //end header


            //content
            var rowNum = 1;
            foreach (var item in source)
            {
                var rowContent = sheet.CreateRow(rowNum);
                var colContentIndex = 0;

                var cellContentNro = rowContent.CreateCell(colContentIndex);
                cellContentNro.SetCellValue(rowNum);
                colContentIndex++;

                foreach (var property in properties)
                {
                    var cellContent = rowContent.CreateCell(colContentIndex);
                    var value = property.GetValue(item, null);

                    DescriptionAttribute[] da = (DescriptionAttribute[])property.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (da[0].Description.ToString() == "Estado")
                    {
                        cellContent.SetCellValue(Convert.ToInt32(value)==0?"Inactivo":(Convert.ToInt32(value) == 1?"Activo":""));
                    }
                    else {
                        if (value == null)
                        {
                            cellContent.SetCellValue("");
                        }
                        else if (property.PropertyType == typeof(string))
                        {
                            cellContent.SetCellValue(value.ToString());
                        }
                        else if (property.PropertyType == typeof(int) || property.PropertyType == typeof(int?))
                        {
                            cellContent.SetCellValue(Convert.ToInt32(value));
                        }
                        else if (property.PropertyType == typeof(decimal) || property.PropertyType == typeof(decimal?))
                        {
                            cellContent.SetCellValue(Convert.ToDouble(value));
                        }
                        else if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                        {
                            var dateValue = (DateTime)value;
                            cellContent.SetCellValue(dateValue.ToString("yyyy-MM-dd"));
                        }
                        else cellContent.SetCellValue(value.ToString());
                    }    
                    colContentIndex++;
                }
                rowNum++;
            }

            //end content
            var stream = new MemoryStream();
            workbook.Write(stream);
            var content = stream.ToArray();

            return content;
        }
    }
}
