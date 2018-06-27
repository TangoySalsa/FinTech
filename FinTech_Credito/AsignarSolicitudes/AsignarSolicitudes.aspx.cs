using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Dashboard_Bajas_Carrier.AsignarSolicitudes
{
    public partial class AsignarSolicitudes : System.Web.UI.Page
    {
        Logica.LogicaAsignacionSolicitudes bd = new Logica.LogicaAsignacionSolicitudes();
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        Logica.Logica lg = new Logica.Logica();
        protected void Page_Load(object sender, EventArgs e)
        {
            ObtenerAsignaciones(1);
        }
        protected void llenaCombos()
        {
            cbUsuario.DataSource = ut.llenaComboAsesor();
            cbUsuario.DataTextField = "Descripcion";
            cbUsuario.DataValueField = "Id";
            cbUsuario.DataBind();
            cbUsuarioAsignar.DataTextField = "Descripcion";
            cbUsuarioAsignar.DataValueField = "Id";
            cbUsuarioAsignar.DataBind();
        }
        protected void ObtenerAsignaciones( Int32 Id)
        {
            try
            {
                //Tabla Cuentas

                DataTable ConsultaAsignacion = new DataTable();
                DataRow dr = null;

                ConsultaAsignacion.Columns.Add(new DataColumn("Id", typeof(int)));
                ConsultaAsignacion.Columns.Add(new DataColumn("IdSolicitud", typeof(int)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Status", typeof(string)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Cedula", typeof(int)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Nombre", typeof(string)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Producto", typeof(string)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Monto", typeof(string)));
                ConsultaAsignacion.Columns.Add(new DataColumn("Agente", typeof(string)));
             
                //Carga cuentas bancarias

                List<AsignacionSolicitudes> _ConsultaAsignaciones = new List<AsignacionSolicitudes>();
                _ConsultaAsignaciones = bd.ConsultarAsignaciones(Id);

                int i = 1;
                foreach (var ConsultaAsignaciones in _ConsultaAsignaciones)
                {
                    //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas Bancarias
                    dr = ConsultaAsignacion.NewRow();
                    dr["Id"] = ConsultaAsignaciones.Id;
                    dr["IdSolicitud"] = ConsultaAsignaciones.IdSolicitud;
                    dr["Status"] = ConsultaAsignaciones.Status;
                    dr["Cedula"] = ConsultaAsignaciones.Cedula;
                    dr["Nombre"] = ConsultaAsignaciones.Nombre;
                    dr["Producto"] = ConsultaAsignaciones.Producto;
                    dr["Monto"] = ConsultaAsignaciones.Monto;
                    dr["Agente"] = ConsultaAsignaciones.Agente;
                 

                    ConsultaAsignacion.Rows.Add(dr);

                }
                //Si el cliente no posee cuentas carga grid vacio
                if (ConsultaAsignacion.Rows.Count == 0)
                {
                    CargarGridVacio();
                }
                else {
                    //Muestro Cuentas de la solicitud en base de datos
                    ViewState["VSConsultaAsignacion"] = ConsultaAsignacion;
                    gvSolicitudesaAsignar.DataSource = ConsultaAsignacion;
                    gvSolicitudesaAsignar.DataBind();
                }

            }
            catch (Exception ex)
            {
                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                lg.GuardarErrores("AsignacionSolicitudes.aspx", "btnLimpiar_Click", Convert.ToString(ex));
            }
        }

        protected void CargarGridVacio()
        {
            DataTable ConsultaAsignacion = new DataTable();
            DataRow dr = null;

            ConsultaAsignacion.Columns.Add(new DataColumn("Id", typeof(int)));
            ConsultaAsignacion.Columns.Add(new DataColumn("IdSolicitud", typeof(int)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Status", typeof(string)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Cedula", typeof(int)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Nombre", typeof(string)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Producto", typeof(string)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Monto", typeof(string)));
            ConsultaAsignacion.Columns.Add(new DataColumn("Agente", typeof(string)));

            //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas Bancarias
            dr = ConsultaAsignacion.NewRow();
            dr["Id"] = 0;
            dr["IdSolicitud"] = 0;
            dr["Status"] = "";
            dr["Cedula"] = 0;
            dr["Nombre"] = "";
            dr["Producto"] = "";
            dr["Monto"] = "";
            dr["Agente"] = "";
            ConsultaAsignacion.Rows.Add(dr);
            ViewState["VSConsultaAsignacion"] = ConsultaAsignacion;
            gvSolicitudesaAsignar.DataSource = ConsultaAsignacion;
            gvSolicitudesaAsignar.DataBind();
            MostrarFilaVacia();

        }
        protected void MostrarFilaVacia()
        {
            int _totalColumnas = gvSolicitudesaAsignar.Rows[0].Cells.Count;
            gvSolicitudesaAsignar.Rows[0].Cells.Clear();
            gvSolicitudesaAsignar.Rows[0].Cells.Add(new TableCell());
            gvSolicitudesaAsignar.Rows[0].Cells[0].ColumnSpan = _totalColumnas;
            gvSolicitudesaAsignar.Rows[0].Cells[0].Text = "NoHayRegistros";
        }
        protected void gvSolicitudesaAsignar_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            DataTable dtGVirtualR = ViewState["VirtualEstatusR"] as DataTable;

            //  DataTable dtG = bd.ConsultaSolicitudRechazados();
            if (dtGVirtualR.Rows.Count >= 1)
            {
                gvSolicitudesaAsignar.PageIndex = e.NewPageIndex;
                gvSolicitudesaAsignar.DataSource = dtGVirtualR;
                gvSolicitudesaAsignar.DataBind();
            }
        }
    }
}