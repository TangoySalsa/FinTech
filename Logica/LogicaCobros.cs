using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Logica.Utilitarios;
using System.Web.UI;
using System.Web;
using Entidades;


namespace Logica
{
   public class LogicaCobros
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logica));
        BaseDatos.Cobros bdCobro = new BaseDatos.Cobros();
        public List<EntidadesCobros> ConsultarCobro(string Identificacion, string FechaInicio, string FechaFin, string IdCredito)
        {
            try
            {
                List<EntidadesCobros> ListaCuentasCobrar = bdCobro.ConsultarCobro(Identificacion, FechaInicio,FechaFin, IdCredito);

                return ListaCuentasCobrar;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

    }
}
