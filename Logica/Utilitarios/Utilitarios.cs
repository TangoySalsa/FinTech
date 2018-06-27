using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace Logica.Utilitarios
{
    public class Utilitarios
    {

        BaseDatos.clsServicios bdSer = new BaseDatos.clsServicios();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Logica));
        public DataTable ExtraeSolicitudMax()
        {
            try
            {
                return bdSer.ServiciosExtraeSolicitudMax();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataTable();
            }
        }

        public DataSet LlenaComboBox(string tabla, string id, string nombre)
        {
            try
            {
                return bdSer.llenaCombo(tabla,id,nombre);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataSet();
            }
        }
        /// <summary>
        /// Se extrae de base de datos los status para llenar el combobox de filtrado 
        /// </summary>
        /// <returns></returns>
        public DataTable llenaComboFiltro(Int32 Id)
        {
            try
            {
                return bdSer.llenaComboFiltro(Id);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataTable();
            }
        }
        public DataTable llenaComboAsesor()
        {
            try
            {
                return bdSer.llenaComboAsesor();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataTable();
            }
        }
        public DataSet LlenaComboBox1Parametro(string tabla, string id, string nombre, string parametro1,string valor1)
        {
            try
            {
                return bdSer.llenaCombo1Parametro(tabla, id, nombre,parametro1,valor1);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataSet();
            }
        }

        public DataSet LlenaComboBox2Parametros(string tabla, string id, string nombre, string parametro1, 
            string valor1, string parametro2, string valor2)
        {
            try
            {
                return bdSer.llenaCombo2Parametros(tabla, id, nombre, parametro1, valor1,parametro2,valor2);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return new DataSet();
            }
        }


        public static void RegistrarLog(string usuario, ExcepcionControlada excepcion)
        {
            try
            {
                if (!string.IsNullOrEmpty(excepcion.Message))
                {
                    string cadena = string.Empty;
                    StreamWriter errorLog = null;
                    string rutaLog = ConfigurationManager.AppSettings["rutaLog"];

                    //Registra el usuario, método donde ocurrió la excepción, mensaje, inner 
                    cadena = string.Format("----------------------------------------------------------------------\n");
                    cadena += string.Format("Fecha\\hora: {0}\n", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    string servidor = ConfigurationManager.AppSettings["servidorWeb"];
                    if (servidor != null)
                    {
                        cadena += string.Format("Servidor: {0}\n", servidor);
                    }
                    cadena += string.Format("Usuario: {0}\n", usuario);
                    cadena += string.Format("Metodo: {0}\n", excepcion.MetodoError);
                    cadena += string.Format("Mensaje: {0}\n", excepcion.Message);
                    if (excepcion.InnerException != null)
                    {
                        cadena += string.Format("\t\t-----------------Exception Interna-----------------\n");
                        cadena += string.Format("\t\tMensaje: {0}\n", excepcion.InnerException.Message);
                        cadena += string.Format("\t\t-----------------Fin Exception Interna-----------------\n");
                    }
                    
                    cadena += string.Format("StackTrace : {0}\n", excepcion.StackTrace);
                    if (excepcion.Data != null && excepcion.Data.Count > 0)
                    {
                        cadena += "-----------------Datos-----------------\n";
                        foreach (System.Collections.DictionaryEntry item in excepcion.Data)
                        {
                            cadena += string.Format("{0} : {1}\n", item.Key, item.Value);
                        }
                        cadena += "----------------- Fin Datos-----------------\n";
                    }

                    cadena += string.Format("----------------------------------------------------------------------\n");
                    if (!Directory.Exists(rutaLog)) Directory.CreateDirectory(rutaLog);

                    string direcciontxt = rutaLog + Constante.NombreLog;

                    errorLog = new StreamWriter(direcciontxt, true);
                    errorLog.WriteLine(cadena);
                    errorLog.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
