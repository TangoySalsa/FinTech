using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace BaseDatos
{
   public class clsAsignacionSolicitudes
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsServicios));
        #region CargaObjeto
        public List<AsignacionSolicitudes> ConsultarAsignaciones(int IdAsesor)
        {

            try
            {
                DataTable dtConsultaAsesores = new DataTable();
                dtConsultaAsesores = pr_ConsultarAsesores(IdAsesor);

                List<AsignacionSolicitudes> lis_encabezado = dtConsultaAsesores.AsEnumerable().Select(r => new AsignacionSolicitudes()
                {
                    Id = r.Field<int?>("Id") ?? 0,
                    IdSolicitud = r.Field<int?>("Id") ?? 0,
                    Nombre = r.Field<string>("Nombre") ?? string.Empty,
                    Cedula = r.Field<string>("Cedula") ?? string.Empty,
                    Producto = r.Field<string>("Producto") ?? string.Empty,
                    Monto = r.Field<decimal?>("Cuota") ?? 0,
                    Agente = r.Field<string>("Agente") ?? string.Empty
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
        public DataTable pr_ConsultarAsesores(int IdAsesor)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_Pendiente", IdAsesor).Tables[0];

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
