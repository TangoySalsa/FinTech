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
    public class Logica 
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logica));
        BaseDatos.clsLogin bdLog = new BaseDatos.clsLogin();
        BaseDatos.clsServicios bdSer = new BaseDatos.clsServicios();
        BaseDatos.clsSolicitudBuro bdSerB = new BaseDatos.clsSolicitudBuro();
        BaseDatos.clsCredito bdCre = new BaseDatos.clsCredito();       
 
        public DataTable Login(string user, string pass)
        {
            try
            {
                
                HttpContext.Current.Session["UserID"] = user;
                return bdLog.Login(user, pass);
               
            }

            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }


        public DataTable Servicios(string Identificacion)
        {
            try
            {
                return bdSer.Servicios(Identificacion);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataTable();
            }
        }

        public List<Solicitudes> ServiciosSolicitud(string Identificacion)
        {
            try
            {
                List<Solicitudes> ListaClienteSol =  bdSer.ServiciosSolicitud(Identificacion);

                return ListaClienteSol;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }
        //public DataTable ServiciosSolicitud(string Identificacion)
        //{
        //    try
        //    {
        //        return bdSer.ServiciosSolicitud(Identificacion);
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        return new DataTable();
        //    }
        //}



        

        public DataTable GuardarErrores(string Formulario, string Clase, string Error)
        {
            try
            {
                return bdSer.GuardarErrores(Formulario, Clase, Error);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }


        /// <summary>
        /// Extrae las solicitudes pendientes
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable ConsultaSolicitudPendientes(Int32 Id, string Identificacion)
        {
            try
            {
                return bdSer.ConsultaSolicitudPendientes(Id, Identificacion);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        /// <summary>
        /// Extrae las solicitudes que se van aprobar
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public DataTable ConsultaSolicitud(string Identificacion)
        {
            try
            {
                return bdSerB.ConsultaSolicitud(Identificacion);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }
        #region ClienteSolicitud
        public List<ClienteSolicitud> ObtenerCuentaSol(string Identificacion)
        {
            try
            {
                List<ClienteSolicitud> ListaClienteSol = bdSer.ObtenerCuentaSol(Identificacion);

                return ListaClienteSol;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        }

        public List<ClienteSolicitud> GuardarClienteSolicitud(List<ClienteSolicitud> _ClienteSol)
        {
            try
            {
                return bdSer.GuardarClienteSol(_ClienteSol);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return bdSer.GuardarClienteSol(_ClienteSol);
            }
        }
        #endregion ClienteSolicitud
            /// <summary>
            /// Extrae las solicitudes que se van aprobar
            /// </summary>
            /// <param name="IdSolicitud"></param>
            /// <returns></returns>
        public DataTable ConsultaSolicitudBuro(int IdSolicitud)
        {
            try
            {
                return bdSerB.ConsultaSolicitudBuro(IdSolicitud);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        public DataTable GuardarSolicitudBuro(int IdSolicitud, int Edad, int EstatusPersona, string NumeroAsegurado, int TipoAsegurado, int BienesInmuebles, int BienMueble,
                                              int Prendas, int Hipotecas, int ReportesComerciales, int Juicios, int Salario, int Provincia, int Canton,
                                              int Distrito, string Comentarios, string Direccion, int Estado)
        {
            try
            {
                return bdSerB.GuardarSolicitudBuro(IdSolicitud, Edad, EstatusPersona, NumeroAsegurado, TipoAsegurado, BienesInmuebles, BienMueble,
                                                    Prendas, Hipotecas, ReportesComerciales, Juicios, Salario, Provincia, Canton, Distrito, Comentarios, Direccion, Estado);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        public DataTable ServiciosGuardar(int IdTipoIdentificacion, string Identificacion, string VencimientoIdentificacion,
                                         string PrimerNombre, string SegundoNombre, string PrimerApellido, string SegundoApellido, int TelefonoCel,
                                         int TelefonoFijo, int TelefonoLaboral, string Correo, string CorreoOpcional, int EstadoCivil,
                                         int Sexo, string FechaNacimiento, int Provincia, int Canton, int Distrito, string DetalleDireccion,
           string UsrModifica, int IdProducto,/* string Cuenta, string Cuentasinpe, int Banco,*/ string UsoCredito)

        {
            try
            {
                return bdSer.ServiciosGuardar(IdTipoIdentificacion, Identificacion, VencimientoIdentificacion,
                                                PrimerNombre, SegundoNombre, PrimerApellido, SegundoApellido, TelefonoCel,
                TelefonoFijo, TelefonoLaboral, Correo, CorreoOpcional, EstadoCivil, Sexo, FechaNacimiento,
                Provincia, Canton, Distrito, DetalleDireccion, UsrModifica, IdProducto,/*/* Cuenta, Cuentasinpe, Banco,*/ UsoCredito);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }
         public DataTable ApruebaSolicitud(int Id, int IdSolicitud)
        {
            try
            {
                return bdSerB.ApruebaSolicitud(Id,IdSolicitud);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        public DataTable ConsultaSolicitudesStatus(int status)
        {
            try
            {
                return bdSerB.ConsultaSolicitudesStatus(status);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        public DataTable ConsultaSolicitudRechazados()
        {
            try
            {
                return bdSerB.ConsultaSolicitudRechazados();
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }

        /// <summary>
        /// Se guadan el credito aprobado por Contabilidad
        /// </summary>
        /// <param name="IdSolicitud"></param>
        /// <returns></returns>
        public DataTable GuardarCredito(int IdSolicitud, string Comentario)
        {
            try
            {
                return bdCre.GuardarCredito(IdSolicitud, Comentario);
            }
            catch (Exception ex)
            {
                Utilitarios.ExcepcionControlada excepcion = new Utilitarios.ExcepcionControlada(ex);
                Utilitarios.Utilitarios.RegistrarLog(Convert.ToString(HttpContext.Current.Session["UserID"]), excepcion);
                excepcion.IsRegistradoLog = true;
                return new DataTable();
            }
        }
    
    }
}
