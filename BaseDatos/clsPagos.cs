using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Configuration;
using System.Data;
using Microsoft.ApplicationBlocks.Data;

namespace BaseDatos
{
  public class clsPagos
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsServicios));

        public PagosCP ObtenerCobro(string Identificacion, int Credito, int Cuota)
        {
            
            try
            {
                PagosCP _PagosCp = new PagosCP();
                DataTable dtPagos = new DataTable();
                dtPagos = prObtenerCobro(Identificacion, Credito, Cuota);

                List<Pagos> lis_Pagos = dtPagos.AsEnumerable().Select(r => new Pagos()
                {
                    IdCredito = r.Field<int?>("IdCredito") ?? 0,
                    Cuota = r.Field<int?>("Cuota") ?? 0,
                    FechaCredito = r.Field<DateTime?>("FechaCredito"),
                    FechaPago = r.Field<DateTime?>("FechaPago"),
                    Capital = r.Field<decimal?>("Capital")?? 0,
                    Interes = r.Field<decimal?>("Interes") ?? 0,
                    Status = r.Field<string>("Descripcion") ?? string.Empty,
                    NombreProducto = r.Field<string>("NombreProducto") ?? string.Empty,
                    Diferencia = r.Field<decimal?>("Diferencia") ?? 0,
                    SaldoActual = r.Field<decimal?>("SaldoActual") ?? 0,
                    SaldoAnterior = r.Field<decimal?>("SaldoAnterior") ?? 0,
                    InteresMora = r.Field<decimal?>("InteresMora") ?? 0,
                    MontoCuota = r.Field<decimal?>("MontoCuota") ?? 0

                }).ToList();

                List<Solicitudes> lis_Persona = dtPagos.AsEnumerable().Select(r => new Solicitudes()
                {
                    Nombre = r.Field<string>("Nombre") ?? string.Empty  

                }).ToList();

                _PagosCp._ClienteSolicitud = lis_Persona;
                _PagosCp.Pagos = lis_Pagos;
                return _PagosCp;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }
        #region Procedures
        public DataTable prObtenerCobro(string Identificacion, int Credito, int Cuota)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultaCreditosCuotas", Identificacion, Credito, Cuota).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }
        public DataTable llenaComboCuota(string Identificacion,int IdCredito)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_TraeNumeroCuotas", Identificacion,IdCredito).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;

        }

        public Pagos RealizarPago(Pagos _Pago)
        {

            try
            {
               
                    SqlHelper.ExecuteNonQuery(con, "usp_ActualizaPlanPagos", _Pago.IdCredito, _Pago.Cuota, _Pago.MontoPagoCuota);
                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }
        #endregion Procedures
    }
}
