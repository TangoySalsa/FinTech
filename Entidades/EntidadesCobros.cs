using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Entidades
{
    public class EntidadesCobros
    {
        private int numeroCredito;
        private string identificacion;
        private string nombre;
        private string nombreProducto;
        private int cantidadCuotas;
        private decimal cuota;
        private decimal principal;
        private decimal intereses;
        private decimal tasa_Interes;
        private decimal originacion;
        private DateTime? fechaPago;
        private decimal tasaAnual;
        private int mes;
        private int semana;
        private int dias;
        private string estatus;
        private List<EntidadesCobros> _entidadesCobros;
        public EntidadesCobros()
        {

        }

        public int NumeroCredito
        {
            get
            {
                return numeroCredito;
            }

            set
            {
                numeroCredito = value;
            }
        }

        public string Identificacion
        {
            get
            {
                return identificacion;
            }

            set
            {
                identificacion = value;
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

        public string NombreProducto
        {
            get
            {
                return nombreProducto;
            }

            set
            {
                nombreProducto = value;
            }
        }

        public int CantidadCuotas
        {
            get
            {
                return cantidadCuotas;
            }

            set
            {
                cantidadCuotas = value;
            }
        }

        public decimal Cuota
        {
            get
            {
                return cuota;
            }

            set
            {
                cuota = value;
            }
        }

        public decimal Principal
        {
            get
            {
                return principal;
            }

            set
            {
                principal = value;
            }
        }

        public decimal Intereses
        {
            get
            {
                return intereses;
            }

            set
            {
                intereses = value;
            }
        }

        public decimal Tasa_Interes
        {
            get
            {
                return tasa_Interes;
            }

            set
            {
                tasa_Interes = value;
            }
        }

        public decimal Originacion
        {
            get
            {
                return originacion;
            }

            set
            {
                originacion = value;
            }
        }

        public DateTime? FechaPago
        {
            get
            {
                return fechaPago;
            }

            set
            {
                fechaPago = value;
            }
        }

        public decimal TasaAnual
        {
            get
            {
                return tasaAnual;
            }

            set
            {
                tasaAnual = value;
            }
        }

        public List<EntidadesCobros> _EntidadesCobros
        {
            get
            {
                return _entidadesCobros;
            }

            set
            {
                _entidadesCobros = value;
            }
        }

        public int Mes
        {
            get
            {
                return mes;
            }

            set
            {
                mes = value;
            }
        }

        public int Semana
        {
            get
            {
                return semana;
            }

            set
            {
                semana = value;
            }
        }

        public int Dias
        {
            get
            {
                return dias;
            }

            set
            {
                dias = value;
            }
        }

        public string Estatus
        {
            get
            {
                return estatus;
            }

            set
            {
                estatus = value;
            }
        }
    }
}
