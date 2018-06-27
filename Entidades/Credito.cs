using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Credito
    {
        private int id;
        private int idSolicitud;
        private string comentario;

        public int IdSolicitud
        {
            get
            { return idSolicitud; }
            set
            { idSolicitud = value; }
        }

        public string Comentario
        {
            get
            { return comentario; }
            set
            { comentario = value; }
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
    }
}
