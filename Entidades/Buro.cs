using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Buro
    {

        private int idSolicitud;
        private int edad;
        private int bienMueble;
        private int bienesInmuebles;
        private int estatusPersona;
        private int reportesComerciales;
        private int juicios;
        private int prendas;
        private int hipotecas;
        private int salario;
        private int provincia;
        private int canton;
        private int distrito;
        private string direccion;
        private string comentarios;
        private int tipoAsegurado;
        private string numeroAsegurado;
        private int estado;
        /// <summary>
        /// Solicitudes
        /// </summary>
        /// 


        public int Estado
        {
            get
            { return estado; }
            set
            { estado = value; }
        }


        public int IdSolicitud
        {
            get
            { return idSolicitud; }
            set
            { idSolicitud = value; }
        }


        public int Edad
        {
            get
            { return edad; }
            set
            { edad = value; }
        }

        public int BienMueble
        {
            get
            { return bienMueble; }
            set
            { bienMueble = value; }
        }
        public int BienesInmuebles
        {
            get
            { return bienesInmuebles; }
            set
            { bienesInmuebles = value; }
        }

        public int EstatusPersona
        {
            get
            { return estatusPersona; }
            set
            { estatusPersona = value; }
        }

        public int ReportesComerciales
        {
            get
            { return reportesComerciales; }
            set
            { reportesComerciales = value; }
        }

        public int Juicios
        {
            get
            { return juicios; }
            set
            { juicios = value; }
        }

        public int Prendas
        {
            get
            { return prendas; }
            set
            { prendas = value; }
        }

        public int Hipotecas
        {
            get
            { return hipotecas; }
            set
            { hipotecas = value; }
        }

        public int Salario
        {
            get
            { return salario; }
            set
            { salario = value; }
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

        public int TipoAsegurado
        {
            get
            { return tipoAsegurado; }
            set
            { tipoAsegurado = value; }
        }

        public string NumeroAsegurado
        {
            get
            { return numeroAsegurado; }
            set
            { numeroAsegurado = value; }
        }

        public string Direccion
        {
            get
            { return direccion; }
            set
            { direccion = value; }
        }

        public string Comentarios
        {
            get
            { return comentarios; }
            set
            { comentarios = value; }
        }
    }
}
