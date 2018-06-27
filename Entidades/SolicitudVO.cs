using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
   public class SolicitudVO
    {
        public SolicitudVO()
        {
            _ClienteSolicitud = new List<ClienteSolicitud>();
          
        }

        private List<ClienteSolicitud> _clienteSolicitud;
                          
        public List<ClienteSolicitud> _ClienteSolicitud
        {
            get
            {
                return _clienteSolicitud;
            }
            set { _clienteSolicitud = value; }
        }


    }
}
