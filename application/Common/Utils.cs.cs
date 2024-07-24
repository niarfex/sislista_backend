using Application.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
    internal class Utils
    {
        public static void registrarLog(string registro, string metodo, string tipo)
        {
            var folderlog = Path.Combine(Directory.GetCurrentDirectory(), "logs");

            if (!Directory.Exists(folderlog))
            {
                Directory.CreateDirectory(folderlog);
            }
            var filelog = Path.Combine(folderlog, "log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            if (!System.IO.File.Exists(filelog))
            {
                StreamWriter sw = new StreamWriter(filelog);
                sw.WriteLine("[" + DateTime.Now.ToString() + "] " + tipo + ": " + "{" + metodo + "} " + registro);
                sw.Close();
            }
            else
            {
                using (StreamWriter sw = System.IO.File.AppendText(filelog))
                {
                    sw.WriteLine("[" + DateTime.Now.ToString() + "] " + tipo + ": " + "{" + metodo + "} " + registro);
                    sw.Close();
                }
            }
        }
        
    }
}
