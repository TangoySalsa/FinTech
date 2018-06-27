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
    public class clsServicios
    {
        private string con = ConfigurationManager.ConnectionStrings["dbCnn"].ConnectionString;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(clsServicios));

   
        public DataTable Servicios(string Identificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarPersonas", Identificacion).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

        public List<Solicitudes> ServiciosSolicitud(string Identificacion)
        {

            try
            {
                DataTable dsSolicitudes = new DataTable();
                dsSolicitudes = prServiciosSolicitud(Identificacion);

                List<Solicitudes> lis_encabezado = dsSolicitudes.AsEnumerable().Select(r => new Solicitudes()
                {
                    Id = r.Field<int?>("Id") ?? 0,
                    IdTipoIdentificacion = r.Field<int?>("IdTipoIdentificacion") ?? 0,
                    Identificacion = r.Field<string>("Identificacion") ?? string.Empty,
                    VencimientoIdentificacion = Convert.ToString(r.Field<DateTime?>("VencimientoIdentificacion")),
                    PrimerNombre = r.Field<string>("PrimerNombre") ?? string.Empty,
                    SegundoNombre = r.Field<string>("SegundoNombre") ?? string.Empty,
                    PrimerApellido = r.Field<string>("PrimerApellido") ?? string.Empty,
                    SegundoApellido = r.Field<string>("SegundoApellido") ?? string.Empty,
                    TelefonoCel = r.Field<int?>("TelefonoCel") ?? 0,
                    TelefonoFijo = r.Field<int?>("TelefonoFijo") ?? 0,
                    TelefonoLaboral = r.Field<int?>("TelefonoLaboral") ?? 0,
                    Correo = r.Field<string>("Correo") ?? string.Empty,
                    CorreoOpcional = r.Field<string>("CorreoOpcional") ?? string.Empty,
                    EstadoCivil = r.Field<int?>("EstadoCivil") ?? 0,
                    Sexo = r.Field<int?>("Sexo") ?? 0,
                    FechaNacimiento = Convert.ToString(r.Field<DateTime?>("FechaNacimiento")),
                    Provincia = r.Field<int?>("Provincia") ?? 0,
                    Canton = r.Field<int?>("Canton") ?? 0,
                    Distrito = r.Field<int?>("Distrito") ?? 0,
                    DetalleDireccion = r.Field<string>("DetalleDireccion") ?? string.Empty,
                    FechaIngreso = Convert.ToString(r.Field<DateTime?>("FechaIngreso")),
                    FechaModificacion = r.Field<DateTime?>("FechaModificacion"),
                    UsrModifica = r.Field<string>("UsrModifica") ?? string.Empty,
                    OrdenPatronal = Convert.ToBoolean(r.Field<int?>("OrdenPatronal") ?? 0),
                    IdProducto = r.Field<int?>("IdProducto") ?? 0

                }).ToList();

                return lis_encabezado;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }
        public DataTable prServiciosSolicitud(string Identificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarSolicitudesAsesor", Identificacion).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }
        



        #region ClienteSol
        public List<ClienteSolicitud> ObtenerCuentaSol(string Identificacion)
        {

            try
            {
                DataTable dsSolicitudes = new DataTable();
                dsSolicitudes = pr_ObtenerCuentasSol(Identificacion);

                List<ClienteSolicitud> lis_encabezado = dsSolicitudes.AsEnumerable().Select(r => new ClienteSolicitud()
                {
                    Id = r.Field<int?>("Id") ?? 0,
                    IdBanco = r.Field<int?>("IdBanco") ?? 0,
                    IdPersona = r.Field<int?>("IdPersona") ?? 0,
                    Cuenta = r.Field<string>("Cuenta") ?? string.Empty,
                    CuentaSinpe = r.Field<string>("CuentaSinpe") ?? string.Empty,
                    CuentaIban = r.Field<string>("CuentaIban") ?? string.Empty,
                    DescBanco = r.Field<string>("Descripcion") ?? string.Empty,
                    Predeterminado = r.Field<Boolean>("Predeterminado") 
                    //  FFechaIngreso = r.Field<DateTime?>("FechaIngreso"),
                    //  FechaModificacion = r.Field<DateTime?>("FechaModificacion"),
                    //  UsrModifica = r.Field<string>("UsrModifica") ?? string.Empty
                }).ToList();

                return lis_encabezado;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }

        public List<ClienteSolicitud> GuardarClienteSol(List<ClienteSolicitud> _ClienteSolicit)
        {

            try
            {
                foreach (var item in _ClienteSolicit)
                {
                    SqlHelper.ExecuteNonQuery(con, "usp_InsertaClienteSolicitud", item.Id,item.IdPersona,item.IdBanco,item.Cuenta,item.CuentaSinpe,item.CuentaIban,item.Predeterminado,item.Operacion);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;

        }
        #endregion ClienteSol
        public DataTable GuardarErrores(string Formulario, string Clase, string Error)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlHelper.ExecuteNonQuery(con, "usp_InsertarErroresFinTech", Formulario, Clase, Error);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }


        public DataTable ServiciosGuardar(int IdTipoIdentificacion, string Identificacion, string VencimientoIdentificacion,
                                          string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, int TelefonoCel,
                                          int TelefonoFijo, int TelefonoLaboral, string Correo, string CorreoOpcional, int EstadoCivil,
                                          int Sexo, string FechaNacimiento, int Provincia, int Canton, int Distrito, string DetalleDireccion,
            string UsrModifica, int IdProducto,/* string Cuenta, string Cuentasinpe, int banco,*/ string UsoCredito)
        {
            DataTable dt = new DataTable();
            try
            {
                 SqlHelper.ExecuteNonQuery(con, "usp_ActualizarPersonas",
                                                IdTipoIdentificacion, Identificacion, VencimientoIdentificacion,
                                                PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, TelefonoCel,
                TelefonoFijo, TelefonoLaboral, Correo, CorreoOpcional, EstadoCivil, Sexo, FechaNacimiento,
                Provincia, Canton, Distrito, DetalleDireccion, UsrModifica, IdProducto, 
                /*banco, Cuenta, Cuentasinpe,*/ UsoCredito
                );

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }


        public DataTable ServiciosExtraeSolicitudMax()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ExtraeMaxSolicitud").Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }

        public DataTable ConsultaSolicitudPendientes(Int32 Id, string Identificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultaSolicitudesAsesor","", Id,Identificacion).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;
        }
        public DataTable llenaComboFiltro(Int32 Id)
        {

            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_TraeStatusTipos",Id).Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;

        }
        
             public DataTable llenaComboAsesor()
        {

            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_TraeStatusTipos").Tables[0];

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return dt;

        }
        public DataSet llenaCombo(string tabla, string id, string nombre)
        {

            SqlConnection cxn = new SqlConnection(con);
            SqlDataAdapter da;
            DataSet ds;
            string sql;
            SqlCommand cm;

            sql = "SELECT " + id + ", " + nombre + " FROM " + tabla ;

            cm = new SqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cxn;

            da = new SqlDataAdapter(cm);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet llenaCombo1Parametro(string tabla, string id, string nombre, string parametro1, string valor1)
        {

            SqlConnection cxn = new SqlConnection(con);
            SqlDataAdapter da;
            DataSet ds;
            string sql;
            SqlCommand cm;

            sql = "SELECT " + id + ", " + nombre + " FROM " + tabla + " WHERE " + parametro1 + " = " + valor1;

            cm = new SqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cxn;

            da = new SqlDataAdapter(cm);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }

        public DataSet llenaCombo2Parametros(string tabla, string id, string nombre, string parametro1, string valor1
            , string parametro2, string valor2)
        {

            SqlConnection cxn = new SqlConnection(con);
            SqlDataAdapter da;
            DataSet ds;
            string sql;
            SqlCommand cm;

            sql = "SELECT " + id + ", " + nombre + " FROM " + tabla + " WHERE " + 
                   parametro1 + " = " + valor1 +" AND " + parametro2 + " = " + valor2;

            cm = new SqlCommand();
            cm.CommandText = sql;
            cm.CommandType = CommandType.Text;
            cm.Connection = cxn;

            da = new SqlDataAdapter(cm);
            ds = new DataSet();
            da.Fill(ds);
            return ds;

        }
        #region StoreProcedure 
        public DataTable pr_ObtenerCuentasSol(string Identificacion)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = SqlHelper.ExecuteDataset(con, "usp_ConsultarPersonasCuentas", Identificacion).Tables[0];

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
