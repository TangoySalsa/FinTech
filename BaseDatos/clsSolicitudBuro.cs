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


namespace BaseDatos
{
    public class clsSolicitudBuro
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsServicios));

        public DataTable ConsultaSolicitud(string Identificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarSolicitud", Identificacion).Tables[0];
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }


        public DataTable ConsultaSolicitudBuro(int IdSolicitud)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarBuroSolicitud", IdSolicitud).Tables[0];


            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

        public DataTable GuardarSolicitudBuro(int IdSolicitud, int Edad, int EstatusPersona, string NumeroAsegurado, int TipoAsegurado, int BienesInmuebles, int BienMueble,
                                               int Prendas, int Hipotecas, int ReportesComerciales, int Juicios, int Salario, int Provincia, int Canton,
                                               int Distrito, string Comentarios, string Direccion, int Estado)
        {
            DataTable dt = new DataTable();
            try
            {
                 SqlHelper.ExecuteNonQuery(con, "usp_InsertaBuro", IdSolicitud, Edad, EstatusPersona, NumeroAsegurado, TipoAsegurado, BienesInmuebles, BienMueble,
                                                                       Prendas, Hipotecas, ReportesComerciales, Juicios, Salario, Provincia, Canton, Distrito,
                                                                       Comentarios, Direccion, Estado);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }



        

             public DataTable ConsultaSolicitudRechazados()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarSolicitudRechazadas").Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }


        public DataTable ConsultaSolicitudesStatus(int status)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultaSolicitudesStatus", status).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

        public DataTable ApruebaSolicitud(int Id, int IdSolicitud)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ApruebaSolicitud",Id, IdSolicitud).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

    }
}
