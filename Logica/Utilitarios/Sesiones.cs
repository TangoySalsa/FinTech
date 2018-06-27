using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Runtime.Serialization;

namespace Logica.Utilitarios
{
    public class Sesiones
    {

        private string nomUsuario;


        [DataMember]
        public string NomUsuario
        {
            get { return nomUsuario; }
            set { nomUsuario = value; }
        }

    }
}
