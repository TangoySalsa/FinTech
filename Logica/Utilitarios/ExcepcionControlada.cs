using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Runtime.Serialization;

namespace Logica.Utilitarios
{
    public class ExcepcionControlada : Exception
    {
        public const String NuevoRegistro = "Se ingresaron los datos correctamente.";
        public const String EditarRegistro = "Se actualizaron los datos correctamente. ";
        /* Menasje de error */
        public const String ErrNuevoRegistro = "No se pudo ingresar los datos, favor intertarlo nuevamente.";
        public const String ErrEditarRegistro = "No se pudo actualizar los datos, favor intertarlo nuevamente.";
        public const String ErrConsultarRegistro = "No se pudo consultar los datos, favor intertarlo nuevamente.";
        public const String PermisosUsuario = "El usuario no cuenta con permisos para realizar esa funcionalidad.";
        public const String ErrCargarDatos = "Ocurrió un error a la hora de cargar los datos en el sistema.";
        public const String ErrCargarReporte = "Ocurrió un error a la hora de cargar los datos en el reporte.";
        public const String ErrSesion = "La sesión ha expirado.<br /> Por favor, ingrese al sistema de nuevo";
        /* Imagenes de Mensajes  */
        //public const String imgInf = @"Recursos\images\informacion_al_ciudadano1.jpg";
        //public const String imgErr = @"Recursos\images\Error_al_Usuario1.png";
        //public const String imgAdb = @"Recursos\images\Advertencia_al_Usuario1.jpg";
        /////* Pagina Mensaje*/
        //public const String frmDefault = "~/frmDefault.aspx";


        private Page page;
        private String detalleError;
        private enumMensajeFrm tipoMensaje;
        private Exception ex;

        public enum enumMensajeFrm
        {
            Informacion = 1,
            advertencia = 2,
            Error = 3
        }

        public ExcepcionControlada(string desMensaje)
        {
            desMensajeError = desMensaje;
        }

        public string pilaErrores { get; set; }


        public override string StackTrace
        {
            get
            {
                return this.pilaErrores;
            }
        }


        public ExcepcionControlada() : base() { }

        public ExcepcionControlada(Exception ex) : base(ex.Message, ex.InnerException) { this.pilaErrores = ex.StackTrace; }

        public ExcepcionControlada(Page pPage, String pDetalleError, enumMensajeFrm pTipoMensaje, Exception pEx)
        {
            this.page = pPage;
            this.detalleError = pDetalleError;
            this.tipoMensaje = pTipoMensaje;
            this.ex = pEx;
            if (ex != null)
                this.GuadarError();
        }

        private void GuadarError()
        {

        }

        [DataMember]
        public Page Page
        {
            get { return page; }
            set { page = value; }
        }

        [DataMember]
        public String DetalleError
        {
            get { return detalleError; }
            set { detalleError = value; }
        }

        [DataMember]
        public enumMensajeFrm TipoMensaje
        {
            get { return tipoMensaje; }
            set { tipoMensaje = value; }
        }

        [DataMember]
        public Exception Ex
        {
            get { return ex; }
            set { ex = value; }
        }


        /* NUEVO */

        private string desMensajeError;
        private string metodoError;
        private bool isRegistradoLog;


        [DataMember]
        public String DesMensajeError
        {
            get { return desMensajeError; }
            set { desMensajeError = value; }
        }

        [DataMember]
        public bool IsRegistradoLog
        {
            get { return isRegistradoLog; }
            set { isRegistradoLog = value; }
        }

        [DataMember]
        public string MetodoError
        {
            get { return metodoError; }
            set { metodoError = value; }
        }
    
}
}
