using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;
using System.Data;
using System.Globalization;

namespace BaseDatos
{
    public class clsVerificar
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsVerificar));

        public DataTable Verificar(string NroTelefono)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "";
                query = string.Format(Querys.ResourceManager.GetString("Obtener_Servicios", CultureInfo.CurrentCulture), "506" + NroTelefono);
                dt = SqlHelper.ExecuteDataset(con, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

        public DataTable BlackList(string NroTelefono)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "";
                query = string.Format(Querys.ResourceManager.GetString("Obtener_BlackList", CultureInfo.CurrentCulture), "506" + NroTelefono);
                dt = SqlHelper.ExecuteDataset(con, CommandType.Text, query).Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }
    }
}
