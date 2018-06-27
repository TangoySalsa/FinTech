using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class PagosCP
    {
        public PagosCP()
        {
             Pagos = new List<Pagos>();
            _ClienteSolicitud = new List<Solicitudes>();
        }

        private List<Pagos> _pagos;
        private List<Solicitudes> _clienteSolicitud;
  
        public List<Pagos> Pagos
        {
            get
            {
                return _pagos;
            }
            set { _pagos = value; }
        }

        public List<Solicitudes> _ClienteSolicitud
        {
            get
            {
                return _clienteSolicitud;
            }

            set
            {
                _clienteSolicitud = value;
            }
        }
    }
}
