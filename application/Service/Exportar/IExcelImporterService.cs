﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service.Exportar
{
    public interface IExcelImporterService
    {
        Task<string> ImportarMarcoLista(string filePath);
    }
}
