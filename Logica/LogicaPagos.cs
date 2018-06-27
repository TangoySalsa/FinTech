using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Web;

namespace Logica
{
    public class LogicaPagos
    {
        BaseDatos.clsPagos bdPagos = new BaseDatos.clsPagos();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logica));
        public PagosCP ObtenerCobro(string Identificacion,int Credito, int Cuota)
        {
            PagosCP _ObtenerCobro = bdPagos.ObtenerCobro(Identificacion, Credito, Cuota);
            return _ObtenerCobro;
        }

        public DataTable llenaComboCuota(string Identificacion ,Int32 Id)
        {
            try
            {
                return bdPagos.llenaComboCuota(Identificacion,Id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataTable();
            }
        }
        public Pagos RealizarPago(Pagos _Pagos)
        {
            try
            {
                return bdPagos.RealizarPago(_Pagos);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return bdPagos.RealizarPago(_Pagos);
            }
        }
    }
}
