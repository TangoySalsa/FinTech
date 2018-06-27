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
    public class clsBaja
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsBaja));

        public int Baja(string NroTelefono, int idSuscripcion)
        {            
            try
            {
                string query = "";
                query = string.Format(Querys.ResourceManager.GetString("Update_Suscripcion", CultureInfo.CurrentCulture), "506" + NroTelefono, idSuscripcion);
                return SqlHelper.ExecuteNonQuery(con, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return 999;
            }           
        }

        public int Baja(string NroTelefono)
        {
            DataTable dt = new DataTable();
            try
            {
                string query = "";
                query = string.Format(Querys.ResourceManager.GetString("Update_Suscripcion_All", CultureInfo.CurrentCulture), "506" + NroTelefono);
                return SqlHelper.ExecuteNonQuery(con, CommandType.Text, query);                
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return 999;
            }           
        }

        public int BlackList(string NroTelefono, int config)
        {
            try
            {
                string query = "";
                if (config == 1)
                    query = string.Format(Querys.ResourceManager.GetString("BlackListIN", CultureInfo.CurrentCulture), "506" + NroTelefono);
                else if (config == 0)
                    query = string.Format(Querys.ResourceManager.GetString("BlackListOUT", CultureInfo.CurrentCulture), "506" + NroTelefono);

                return SqlHelper.ExecuteNonQuery(con, CommandType.Text, query);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return 999;
            }
        }
    }
}
