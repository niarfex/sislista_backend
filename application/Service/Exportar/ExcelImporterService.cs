using Application.Input;
using Domain.Model;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Application.Service.Exportar
{
    public class ExcelImporterService : IExcelImporterService
    {
        private readonly IGeneralService _generalService;
        private readonly IMarcoListaService _marcolistaservice;
        public ExcelImporterService(
            IGeneralService generalService
            , IMarcoListaService marcolistaService)
        {
            _generalService = generalService;
            _marcolistaservice = marcolistaService;
        }
        public async Task<string> ImportarMarcoLista(string filePath)
        {
            //List<MarcoListaModel> listaMarcos = new List<MarcoListaModel>();
            MarcoListaModel obj;
            String result = "";
            var listCondicionJuridica = await _generalService.GetCondicionJuridicas();
            var listDepartamentos = await _generalService.GetDepartamentos();
            var listTipoDocumento = await _generalService.GetTipoDocumento();
            var listTipoExplotacion = await _generalService.GetTipoExplotacion();
            var listMarcoListas = await _marcolistaservice.GetAll("");
            var listPeriodos = await _generalService.GetPeriodos();
            var maxPeriodo = listPeriodos.OrderByDescending(x => x.label).FirstOrDefault();

            var tipoSAA = long.Parse(listCondicionJuridica.Find(x => x.codigo == "SAA").value);//S.A.A.
            var tipoSAC = long.Parse(listCondicionJuridica.Find(x => x.codigo == "SAC").value);//S.A.C.
            var tipoSRL = long.Parse(listCondicionJuridica.Find(x => x.codigo == "SRL").value);//S.R.L.//S.C.R.L.
            var tipoEIRL = long.Parse(listCondicionJuridica.Find(x => x.codigo == "EIRL").value);//E.I.R.L.
            var tipoSA = long.Parse(listCondicionJuridica.Find(x => x.codigo == "SA").value);//S.A.     
            var tipoOTROS = long.Parse(listCondicionJuridica.Find(x => x.codigo == "OTRO").value);

            //var listProvincia = await _generalService.GetProvincias(objMarcoLista.IdUbigeo.Substring(0, 2));
            //var listDistrito = await _generalService.GetDistritos(objMarcoLista.IdUbigeo.Substring(0, 4));
            try
            {
                XSSFWorkbook workbook;
                using (var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    workbook = new XSSFWorkbook(stream);
                }
                var sheet = workbook.GetSheetAt(0);

                var rowHeader = sheet.GetRow(0);
                var currentRow = 1;
                while (currentRow <= sheet.LastRowNum)
                {
                    var row = sheet.GetRow(currentRow);
                    if (row == null) break;

                    obj = new MarcoListaModel();
                    obj.NumeroDocumento = row.GetCell(1).StringCellValue;
                    obj.IdAnio = long.Parse(maxPeriodo.value);
                    if (obj.NumeroDocumento.Trim().Length == 11)
                    {
                        obj.IdTipoDocumento = Convert.ToInt32(listTipoDocumento.Find(x => x.codigo.ToUpper() == "RUC").value);
                        if (row.GetCell(2) == null)
                        {
                            obj.RazonSocial = "";
                            obj.IdCondicionJuridica = tipoOTROS;
                        }
                        else
                        {
                            obj.RazonSocial = row.GetCell(2).StringCellValue;
                            if (row.GetCell(2).StringCellValue.Contains("S.C.R.L.") || row.GetCell(2).StringCellValue.Contains("S.R.L."))
                            {
                                obj.IdCondicionJuridica = tipoSRL;
                            }
                            else if (row.GetCell(2).StringCellValue.Contains("E.I.R.L."))
                            {
                                obj.IdCondicionJuridica = tipoEIRL;
                            }
                            else if (row.GetCell(2).StringCellValue.Contains("S.A.C."))
                            {
                                obj.IdCondicionJuridica = tipoSAC;
                            }
                            else if (row.GetCell(2).StringCellValue.Contains("S.A.A."))
                            {
                                obj.IdCondicionJuridica = tipoSAA;
                            }
                            else if (row.GetCell(2).StringCellValue.Contains("S.A."))
                            {
                                obj.IdCondicionJuridica = tipoSA;
                            }
                            else
                            {
                                obj.IdCondicionJuridica = tipoOTROS;
                            }
                        }

                        obj.DireccionFiscalDomicilio = row.GetCell(3).StringCellValue;
                        obj.NombreRepLegal = row.GetCell(4) == null ? null : row.GetCell(4).StringCellValue;

                        obj.Telefono = row.GetCell(6).StringCellValue.Trim().Length > 20 ? row.GetCell(6).StringCellValue.Trim().Substring(0, 20) : row.GetCell(6).StringCellValue.Trim();
                        obj.Celular = row.GetCell(7) == null ? null : (row.GetCell(7).StringCellValue.Trim().Length > 10 ? row.GetCell(7).StringCellValue.Trim().Substring(0, 10) : row.GetCell(7).StringCellValue.Trim());
                        obj.CorreoElectronico = row.GetCell(8).StringCellValue.Replace("/", ",");
                        if (listTipoExplotacion.FindAll(x => Regex.Replace(x.label.ToUpper().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "") == Regex.Replace(row.GetCell(9).StringCellValue.ToUpper().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "")).Count > 0)
                        {
                            obj.IdTipoExplotacion = Convert.ToInt32(listTipoExplotacion.Find(x => Regex.Replace(x.label.ToUpper().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "") == Regex.Replace(row.GetCell(9).StringCellValue.ToUpper().Normalize(NormalizationForm.FormD), @"[^a-zA-z0-9 ]+", "")).value);
                        }
                        else
                        {
                            obj.IdTipoExplotacion = null;
                            result = result + "Error con el tipo de explótación de la fila " + currentRow.ToString() + ";\n";
                        }
                        if (listDepartamentos.FindAll(x => x.label.ToUpper() == row.GetCell(10).StringCellValue.ToUpper()).Count() > 0)
                        {
                            obj.IdUbigeo = listDepartamentos.Find(x => x.label.ToUpper() == row.GetCell(10).StringCellValue.ToUpper()).value;
                            obj.IdDepartamento = obj.IdUbigeo;
                            var listProvincias = await _generalService.GetProvincias(obj.IdUbigeo);
                            if (listProvincias.FindAll(x => x.label.ToUpper() == row.GetCell(11).StringCellValue.ToUpper()).Count() > 0)
                            {
                                obj.IdUbigeo = listProvincias.Find(x => x.label.ToUpper() == row.GetCell(11).StringCellValue.ToUpper()).value;
                                var listDistritos = await _generalService.GetDistritos(obj.IdUbigeo);
                                if (listDistritos.FindAll(x => x.label.ToUpper() == row.GetCell(12).StringCellValue.ToUpper()).Count() > 0)
                                {
                                    obj.IdUbigeo = listDistritos.Find(x => x.label.ToUpper() == row.GetCell(12).StringCellValue.ToUpper()).value;
                                }
                                else
                                {
                                    obj.IdUbigeo = "";
                                    result = result + "Error con el distrito de la fila " + currentRow.ToString() + ";\n";
                                }
                            }
                            else
                            {
                                obj.IdUbigeo = "";
                                result = result + "Error con la provincia de la fila " + currentRow.ToString() + ";\n";
                            }
                        }
                        else
                        {
                            obj.IdUbigeo = "";
                            result = result + "Error con el departamento de la fila " + currentRow.ToString() + ";\n";
                        }

                        if (obj.IdUbigeo.Trim().Length < 6)
                        {
                            result = result + "Error con el ubigeo de la fila " + currentRow.ToString() + ";\n";
                            obj.IdUbigeo = null;
                        }
                        if (listMarcoListas.FindAll(x => x.IdAnio==obj.IdAnio && x.NumeroDocumento==obj.NumeroDocumento && x.IdDepartamento==obj.IdDepartamento).Count() > 0)
                        {
                            result = result + "Error con el número de documento del elemento de marco de lista de la fila " + currentRow.ToString() + " ya se encuentra registrado en un mismo Periodo y Departamento;\n" ;
                        }
                        else {
                            var resultado = await _marcolistaservice.CreateMarcoLista(obj);
                            if (resultado > 0)
                            {
                                result = result + "Fila " + currentRow.ToString() + " exitosa;\n";
                            }
                            else { result = result + "Error al registrar la fila " + currentRow.ToString() + ";\n"; }
                        }         
                    }
                    else
                    {
                        result = result + "Error con el RUC de la fila " + currentRow.ToString() + ";\n";
                    }
                    //listaMarcos.Add(obj);
                    currentRow++;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
