using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Logica;
using System.Data;

namespace Dashboard_Bajas_Carrier.Cobros
{
    public partial class CuentasCobrar : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        Logica.LogicaCobros cc = new Logica.LogicaCobros();
        Entidades.EntidadesCobros CliSol = new Entidades.EntidadesCobros();
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        protected void Page_Load(object sender, EventArgs e)
        {
            CargarGridVacio();
        }

        protected void ObtenerCuentaCliente(string Identificacion, string FechaInicio, string FechaFin, string IdCredito)
        {
            try
            {
                //Tabla Cuentas

                DataTable dtCuentaCobro = new DataTable();
                DataRow dr = null;

                dtCuentaCobro.Columns.Add(new DataColumn("NumeroCredito", typeof(int)));
                dtCuentaCobro.Columns.Add(new DataColumn("Identificacion", typeof(string)));
                dtCuentaCobro.Columns.Add(new DataColumn("Nombre", typeof(string)));
                dtCuentaCobro.Columns.Add(new DataColumn("NombreProducto", typeof(string)));
                dtCuentaCobro.Columns.Add(new DataColumn("CantidadCuotas", typeof(int)));
                dtCuentaCobro.Columns.Add(new DataColumn("Cuota", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("Principal", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("Intereses", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("Tasa_Interes", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("Originacion", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("FechaPago", typeof(string)));
                dtCuentaCobro.Columns.Add(new DataColumn("TasaAnual", typeof(decimal)));
                dtCuentaCobro.Columns.Add(new DataColumn("Mes", typeof(int)));
                dtCuentaCobro.Columns.Add(new DataColumn("Semana", typeof(int)));
                dtCuentaCobro.Columns.Add(new DataColumn("Dias", typeof(int)));
                dtCuentaCobro.Columns.Add(new DataColumn("Estatus", typeof(string)));


                //Carga cuentas bancarias

                List<EntidadesCobros> _CuentaCobro = new List<EntidadesCobros>();
                _CuentaCobro = cc.ConsultarCobro(Identificacion, FechaInicio, FechaFin, IdCredito);
                //Si el cliente no posee cuentas carga grid vacio
                if (_CuentaCobro.Count == 0)
                {
                    CargarGridVacio();
                }
                else {
                    int i = 1;
                foreach (var CuentaCobro in _CuentaCobro)
                {
                    //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas por Cobrar
                    dr = dtCuentaCobro.NewRow();
                    dr["NumeroCredito"] = CuentaCobro.NumeroCredito;
                    dr["Identificacion"] = CuentaCobro.Identificacion;
                    dr["Nombre"] = CuentaCobro.Nombre;
                    dr["NombreProducto"] = CuentaCobro.NombreProducto;
                    dr["CantidadCuotas"] = CuentaCobro.CantidadCuotas;
                    dr["Cuota"] = CuentaCobro.Cuota;
                    dr["Principal"] = CuentaCobro.Principal;
                    dr["Intereses"] = CuentaCobro.Intereses;
                    dr["Tasa_Interes"] = CuentaCobro.Tasa_Interes;
                    dr["Originacion"] = CuentaCobro.Originacion;
                    dr["FechaPago"] = CuentaCobro.FechaPago;
                    dr["TasaAnual"] = CuentaCobro.TasaAnual;
                    dr["Mes"] = CuentaCobro.Mes;
                    dr["Semana"] = CuentaCobro.Semana;
                    dr["Dias"] = CuentaCobro.Dias;
                    dr["Estatus"] = CuentaCobro.Estatus;

                        dtCuentaCobro.Rows.Add(dr);

                }
                    //Muestro las Cuentas por Cobrar
                    ViewState["Virtual"] = dtCuentaCobro;
                    gv_CuentasCobrar.DataSource = dtCuentaCobro;
                    gv_CuentasCobrar.DataBind();
                }

            }
            catch (Exception ex)
            {
                
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));
            }
        }
    protected void CargarGridVacio()
        {
            DataTable dtCuentaCobroVacio = new DataTable();
            DataRow dr = null;

            dtCuentaCobroVacio.Columns.Add(new DataColumn("NumeroCredito", typeof(int)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Identificacion", typeof(string)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Nombre", typeof(string)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("NombreProducto", typeof(string)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("CantidadCuotas", typeof(int)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Cuota", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Principal", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Intereses", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Tasa_Interes", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Originacion", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("FechaPago", typeof(string)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("TasaAnual", typeof(decimal)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Mes", typeof(int)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Semana", typeof(int)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Dias", typeof(int)));
            dtCuentaCobroVacio.Columns.Add(new DataColumn("Estatus", typeof(string)));

            //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas Bancarias
            dr = dtCuentaCobroVacio.NewRow();
            dr["NumeroCredito"] = 0;
            dr["Identificacion"] = "";
            dr["Nombre"] = "";
            dr["NombreProducto"] = "";
            dr["CantidadCuotas"] = 0;
            dr["Cuota"] = 0;
            dr["Principal"] = 0;
            dr["Intereses"] = 0;
            dr["Tasa_Interes"] = 0;
            dr["Originacion"] = 0;
            dr["FechaPago"] = "";
            dr["TasaAnual"] = 0;
            dr["Mes"] = 0;
            dr["Semana"] = 0;
            dr["Dias"] = 0;
            dr["Estatus"] = "";
            dtCuentaCobroVacio.Rows.Add(dr);
            ViewState["Virtual"] = dtCuentaCobroVacio;
            gv_CuentasCobrar.DataSource = dtCuentaCobroVacio;
            gv_CuentasCobrar.DataBind();
            MostrarFilaVacia();

        }
        protected void MostrarFilaVacia()
        {
            int _totalColumnas = gv_CuentasCobrar.Rows[0].Cells.Count;
            gv_CuentasCobrar.Rows[0].Cells.Clear();
            gv_CuentasCobrar.Rows[0].Cells.Add(new TableCell());
            gv_CuentasCobrar.Rows[0].Cells[0].ColumnSpan = _totalColumnas;
            gv_CuentasCobrar.Rows[0].Cells[0].Text = "No se han encontrado registros con los datos de busqueda ingresados";
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            string Identificacion;
            string FechaInicio;
            string FechaFinal;
            string IdCredito;
            try
            {

                Identificacion = txtIdentificacion.Text.ToString().Trim();
                FechaInicio = dtFechaInicio.Value;
                FechaFinal = dtFechaFin.Value;
                IdCredito = txtIdCredito.Text.ToString();

                if((dtFechaInicio.Value == "" )&&(dtFechaFin.Value != "" ))
                {
                    lblMensajes.Visible = true;
                    lblMensajes.Text = "ERROR: Debe de cargar tanto la Fecha de inicio como la Fecha Fin!";
                }
                else if((dtFechaInicio.Value != "") && (dtFechaFin.Value == ""))
                {
                    lblMensajes.Visible = true;
                    lblMensajes.Text = "ERROR: Debe de cargar tanto la Fecha de inicio como la Fecha Fin!";
                }
                else if((((dtFechaInicio.Value == "")&&(dtFechaFin.Value == ""))&&(Identificacion == "")) && (((dtFechaInicio.Value == "") && (dtFechaFin.Value == "")) && (IdCredito == "")))
                {
                    lblMensajes.Visible = true;
                    lblMensajes.Text = "ERROR: Faltan campos por completar para realizar la consulta!";
                }
                else {
                    ObtenerCuentaCliente(Identificacion, FechaInicio, FechaFinal, IdCredito);
                    lblMensajes.Visible = false;
                }
                

            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnBuscar_Click1" + " " +
                                                                                     "@txtIdCredito" + " " + Convert.ToString(txtIdCredito.Text) + " " +
                                                                                     "@txtIdCredito" + " " + Convert.ToString(txtIdentificacion.Text) + " " +
                                                                                     "@txtIdCredito" + " " + dtFechaInicio.Value + " " +
                                                                                     "@txtFechaFin" + " " + dtFechaFin.Value
                                                                                           , Convert.ToString(ex));
            }
        }

    }
}