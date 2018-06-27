using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteSolicitud
    {
        private int id;
        private int idPersona;
        private int idBanco;
        private string cuenta;
        private string cuentaSinpe;
        private string cuentaIban;
        private DateTime? fFechaIngreso;
        private DateTime? fechaModificacion;
        private string usrModifica;
        private string descBanco;
        private char _operacion;
        private Boolean predeterminado;
        private List<ClienteSolicitud> _clienteSolicitud;
        public ClienteSolicitud()
        {
          
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

        public int IdPersona
        {
            get
            {
                return idPersona;
            }

            set
            {
                idPersona = value;
            }
        }

        public int IdBanco
        {
            get
            {
                return idBanco;
            }

            set
            {
                idBanco = value;
            }
        }

        public string Cuenta
        {
            get
            {
                return cuenta;
            }

            set
            {
                cuenta = value;
            }
        }

        public string CuentaSinpe
        {
            get
            {
                return cuentaSinpe;
            }

            set
            {
                cuentaSinpe = value;
            }
        }

        public string CuentaIban
        {
            get
            {
                return cuentaIban;
            }

            set
            {
                cuentaIban = value;
            }
        }

        public DateTime? FFechaIngreso
        {
            get
            {
                return fFechaIngreso;
            }

            set
            {
                fFechaIngreso = value;
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

        public string UsrModifica
        {
            get
            {
                return usrModifica;
            }

            set
            {
                usrModifica = value;
            }
        }
        public List<ClienteSolicitud> _ClienteSolicitud
        {
            get
            {
                return _clienteSolicitud;
            }
            set { _clienteSolicitud = value; }
        }

        public char Operacion
        {
            get
            {
                return _operacion;
            }

            set
            {
                _operacion = value;
            }
        }

        public string DescBanco
        {
            get
            {
                return descBanco;
            }

            set
            {
                descBanco = value;
            }
        }

        public bool Predeterminado
        {
            get
            {
                return predeterminado;
            }

            set
            {
                predeterminado = value;
            }
        }
    }
}
