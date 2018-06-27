using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Data.Common;
using System.Net;
using Entidades;

namespace BaseDatos
{
  public class Cobros
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsServicios));
        #region CargaObjeto
        public List<EntidadesCobros> ConsultarCobro(string Identificacion,string FechaInicio, string FechaFin, string IdCredito)
        {

            try
            {
                DataTable dtConsultaCobro = new DataTable();
                dtConsultaCobro = pr_ConsultarCobros(Identificacion, FechaInicio, FechaFin, IdCredito);

                List<EntidadesCobros> lis_encabezado = dtConsultaCobro.AsEnumerable().Select(r => new EntidadesCobros()
                {
                    NumeroCredito = r.Field<int?>("NumeroCredito") ?? 0,
                    Identificacion = r.Field<string>("Identificacion") ?? string.Empty,
                    Nombre = r.Field<string>("Nombre") ?? string.Empty,
                    NombreProducto = r.Field<string>("NombreProducto") ?? string.Empty,
                    CantidadCuotas = r.Field<int?>("CantidadCuotas") ?? 0,
                    Cuota = r.Field<decimal?>("Cuota") ?? 0,
                    Principal = r.Field<decimal?>("Principal") ?? 0,
                    Intereses = r.Field<decimal?>("Intereses") ?? 0,
                    Tasa_Interes = r.Field<decimal?>("Tasa_Interes")?? 0,
                    Originacion = r.Field<decimal?>("Originacion") ?? 0,
                    FechaPago = r.Field<DateTime?>("FechaPago"),
                    TasaAnual = r.Field<decimal?>("TasaAnual") ?? 0,
                    Mes = r.Field<int?>("Mes") ?? 0,
                    Semana = r.Field<int?>("Semana") ?? 0,
                    Dias = r.Field<int?>("Dias") ?? 0,
                    Estatus = r.Field<string>("Estatus") ?? string.Empty
                }).ToList();

                return lis_encabezado;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }

        #endregion CargaObjeto

        #region StoreProcedure
        public DataTable pr_ConsultarCobros(string Identificacion, string FechaInicio, string FechaFin, string IdCredito)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarPagos", Identificacion, FechaInicio, FechaFin, IdCredito).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }
        #endregion StoreProcedure

    }
}
