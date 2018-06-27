using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace Entidades
{
    public class Solicitudes
    {
        /// <summary>
        /// Solicitudes
        /// </summary>
        private int id;
        private int idSolicitud;
        private int idBuro;
        private DateTime? fechaSolicitud;
        private Int32 idProducto;
        private string fechaIngreso;
        private string usrModifica;
        private int idPersona;
        private string identificacion;
        private int banco;
        private string usoCredito;
        private Boolean ordenPatronal;
        private DateTime? fechaModificacion;


        /// <summary>
        /// Personas
        /// </summary>
        /// 
        private int idTipoIdentificacion;
        private string vencimientoIdentificacion;
        private string nombre;
        private string primerNombre;
        private string segundoNombre;
        private string primerApellido;
        private string segundoApellido;
        private int telefonoCel;
        private int telefonoFijo;
        private int telefonoLaboral;
        private string correo;
        private string correoOpcional;
        private int estadoCivil;
        private int sexo;
        private string fechaNacimiento;
        private int provincia;
        private int canton;
        private int distrito;
        private string detalleDireccion;
        private string cuenta;
        private string cuentasinpe;
        private string cuentaIban;
        /// <summary>
        /// Solicitudes
        /// </summary>
        /// 


        public string Cuenta
        {
            get
            { return cuenta; }
            set
            { cuenta = value; }
        }


        public int Banco
        {
            get
            { return banco; }
            set
            { banco = value; }
        }

        public string UsoCredito
        {
            get
            { return usoCredito; }
            set
            { usoCredito = value; }
        }

        public string Cuentasinpe
        {
            get
            { return cuentasinpe; }
            set
            { cuentasinpe = value; }
        }

        public string CuentaIban
        {
            get
            { return cuentaIban; }
            set
            { cuentaIban = value; }
        }




        public int IdSolicitud
        {
            get
            { return idSolicitud; }
            set
            { idSolicitud = value; }
        }

        public int IdBuro
        {
            get
            { return idBuro; }
            set
            { idBuro = value; }
        }

        public DateTime? FechaSolicitud
        {
            get
            { return fechaSolicitud; }
            set
            { fechaSolicitud = value; }
        }

        public Int32 IdProducto
        {
            get
            { return idProducto; }
            set
            { idProducto = value; }
        }

        public string FechaIngreso
        {
            get
            { return fechaIngreso; }
            set
            { fechaIngreso = value; }
        }

        public string UsrModifica
        {
            get
            { return usrModifica; }
            set
            { usrModifica = value; }
        }


        public int IdPersona
        {
            get
            { return idPersona; }
            set
            { idPersona = value; }
        }

        public string Identificacion
        {
            get
            { return identificacion; }
            set
            { identificacion = value; }
        }


        /// <summary>
        /// Personas
        /// </summary>
        /// 
        public int IdTipoIdentificacion
        {
            get
            { return idTipoIdentificacion; }
            set
            { idTipoIdentificacion = value; }
        }
        

        public string VencimientoIdentificacion
        {
            get
            { return vencimientoIdentificacion; }
            set
            { vencimientoIdentificacion = value; }
        }

        

        public string PrimerNombre
        {
            get
            { return primerNombre; }
            set
            { primerNombre = value; }
        }

      

        public string SegundoNombre
        {
            get
            { return segundoNombre; }
            set
            { segundoNombre = value; }
        }

      

        public string PrimerApellido
        {
            get
            { return primerApellido; }
            set
            { primerApellido = value; }
        }

     


        public string SegundoApellido
        {
            get
            { return segundoApellido; }
            set
            { segundoApellido = value; }
        }

      

        public int TelefonoCel
        {
            get
            { return telefonoCel; }
            set
            { telefonoCel = value; }
        }

   


        public int TelefonoFijo
        {
            get
            { return telefonoFijo; }
            set
            { telefonoFijo = value; }
        }


        public int TelefonoLaboral
        {
            get
            { return telefonoLaboral; }
            set
            { telefonoLaboral = value; }
        }

       

        public string Correo
        {
            get
            { return correo; }
            set
            { correo = value; }
        }




        public string CorreoOpcional
        {
            get
            { return correoOpcional; }
            set
            { correoOpcional = value; }
        }

    

        public int EstadoCivil
        {
            get
            { return estadoCivil; }
            set
            { estadoCivil = value; }
        }

    

        public int Sexo
        {
            get
            { return sexo; }
            set
            { sexo = value; }
        }



        public string FechaNacimiento
        {
            get
            { return fechaNacimiento; }
            set
            { fechaNacimiento = value; }
        }


 

        public int Provincia
        {
            get
            { return provincia; }
            set
            { provincia = value; }
        }



        public int Canton
        {
            get
            { return canton; }
            set
            { canton = value; }
        }

    

        public int Distrito
        {
            get
            { return distrito; }
            set
            { distrito = value; }
        }

     

        public string DetalleDireccion
        {
            get
            { return detalleDireccion; }
            set
            { detalleDireccion = value; }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public bool OrdenPatronal
        {
            get
            {
                return ordenPatronal;
            }

            set
            {
                ordenPatronal = value;
            }
        }

        public DateTime? FechaModificacion
        {
            get
            {
                return fechaModificacion;
            }

            set
            {
                fechaModificacion = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }
    }
}
