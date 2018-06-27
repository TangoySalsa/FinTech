using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;

namespace Logica
{
  public class LogicaAsignacionSolicitudes
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logica));
        BaseDatos.clsAsignacionSolicitudes bdAsignacion = new BaseDatos.clsAsignacionSolicitudes();
        public List<AsignacionSolicitudes> ConsultarAsignaciones(int IdAsesor)
        {
            try
            {
                List<AsignacionSolicitudes> ListaCuentasCobrar = bdAsignacion.ConsultarAsignaciones(IdAsesor);

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
