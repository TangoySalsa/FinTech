using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Pagos
    {
        private int id;
        private int idCredito;
        private int cuota;
        private DateTime? frechUsrIng;
        private DateTime? fechaPago;
        private DateTime? fechaPagoRealizado;
        private DateTime? fechaCredito;
        private decimal capital;
        private decimal interes;
        private decimal capitalPagado;
        private decimal interesPagado;
        private decimal diferencia;
        private decimal montoCuota;
        private decimal montoPagoCuota;
        private string usrIngresa;
        private decimal saldoActual;
        private decimal saldoAnterior;
        private decimal interesMora;
        private string status;
        private string nombreProducto;


        public Pagos()
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

        public int IdCredito
        {
            get
            {
                return idCredito;
            }

            set
            {
                idCredito = value;
            }
        }

        public DateTime? FrechUsrIng
        {
            get
            {
                return frechUsrIng;
            }

            set
            {
                frechUsrIng = value;
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

        public DateTime? FechaPagoRealizado
        {
            get
            {
                return fechaPagoRealizado;
            }

            set
            {
                fechaPagoRealizado = value;
            }
        }

        public decimal Capital
        {
            get
            {
                return capital;
            }

            set
            {
                capital = value;
            }
        }

        public decimal Interes
        {
            get
            {
                return interes;
            }

            set
            {
                interes = value;
            }
        }

        public decimal CapitalPagado
        {
            get
            {
                return capitalPagado;
            }

            set
            {
                capitalPagado = value;
            }
        }

        public decimal InteresPagado
        {
            get
            {
                return interesPagado;
            }

            set
            {
                interesPagado = value;
            }
        }

        public decimal Diferencia
        {
            get
            {
                return diferencia;
            }

            set
            {
                diferencia = value;
            }
        }

        public decimal MontoCuota
        {
            get
            {
                return montoCuota;
            }

            set
            {
                montoCuota = value;
            }
        }

        public decimal MontoPagoCuota
        {
            get
            {
                return montoPagoCuota;
            }

            set
            {
                montoPagoCuota = value;
            }
        }

        public string UsrIngresa
        {
            get
            {
                return usrIngresa;
            }

            set
            {
                usrIngresa = value;
            }
        }

        public decimal SaldoActual
        {
            get
            {
                return saldoActual;
            }

            set
            {
                saldoActual = value;
            }
        }

        public decimal SaldoAnterior
        {
            get
            {
                return saldoAnterior;
            }

            set
            {
                saldoAnterior = value;
            }
        }

        public decimal InteresMora
        {
            get
            {
                return interesMora;
            }

            set
            {
                interesMora = value;
            }
        }

        public int Cuota
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

        public DateTime? FechaCredito
        {
            get
            {
                return fechaCredito;
            }

            set
            {
                fechaCredito = value;
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
    }
}
