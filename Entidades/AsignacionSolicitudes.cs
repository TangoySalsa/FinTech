using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
  public class AsignacionSolicitudes
    {
        private int id;
        private int idSolicitud;
        private string status;
        private string cedula;
        private string nombre;
        private string producto;
        private decimal monto;
        private string agente;

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

        public int IdSolicitud
        {
            get
            {
                return idSolicitud;
            }

            set
            {
                idSolicitud = value;
            }
        }

        public string Cedula
        {
            get
            {
                return cedula;
            }

            set
            {
                cedula = value;
            }
        }

        public string Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
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

        public string Producto
        {
            get
            {
                return producto;
            }

            set
            {
                producto = value;
            }
        }

        public decimal Monto
        {
            get
            {
                return monto;
            }

            set
            {
                monto = value;
            }
        }

        public string Agente
        {
            get
            {
                return agente;
            }

            set
            {
                agente = value;
            }
        }
    }
}
