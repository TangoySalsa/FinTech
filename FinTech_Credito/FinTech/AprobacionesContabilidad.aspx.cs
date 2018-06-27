using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;

namespace Dashboard_Bajas_Carrier.FinTech
{
    public partial class AprobacionesContabilidad : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        Entidades.Buro bu = new Entidades.Buro();
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        Entidades.Credito cre = new Entidades.Credito();
        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;

            if (!Page.IsPostBack)
            {
                CargarGrid();
            }
        }

        protected void CargarGrid()
        {
            DataTable dtC = bd.ConsultaSolicitudesStatus(38);
            ViewState["VirtualAprobacion"] = dtC;
            if (dtC.Rows.Count >= 1)
            {
                gvPendientesTransferencia.DataSource = dtC;
                gvPendientesTransferencia.DataBind();
            }
            else {
                Response.Write("<script>alert('No se encuentran solicitudes para transferencias.');</script>");

                gvPendientesTransferencia.Visible = false;
            }
            OcultarCampos();
        }
        //protected void llenaGrid()
        //{
        //    //DataTable dtGVirtualAprobaciones = ViewState["VirtualAprobacion"] as DataTable;
        //    ////DataTable dtG = bd.ConsultaSolicitudAprobaciones();
        //    //if (dtGVirtualAprobaciones.Rows.Count >= 1)
        //    //{
        //    //    gvPendientesTransferencia.DataSource = dtGVirtualAprobaciones;
        //    //    gvPendientesTransferencia.DataBind();
        //    //}
        //    DataTable dtGVirtualAprobaciones = ViewState["VirtualAprobacion"] as DataTable;
        //    //DataTable dtG = bd.ConsultaSolicitudAprobaciones();
        //    if (dtGVirtualAprobaciones.Rows.Count >= 1)
        //    {
        //        gvPendientesTransferencia.DataSource = dtGVirtualAprobaciones;
        //        gvPendientesTransferencia.DataBind();


        //        DataTable dtC = bd.ConsultaSolicitudAprobaciones();
        //        ViewState["VirtualAprobacion"] = dtC;
        //        if (dtC.Rows.Count >= 1)
        //        {
        //            gvPendientesTransferencia.DataSource = dtC;
        //            gvPendientesTransferencia.DataBind();
        //        }
        //        else
        //            Response.Write("<script>alert('No se encuentran solicitudes para transferencias.');</script>");
        //        OcultarCampos();

        //    }
        //}
        private void OcultarCampos()
        {
            lblComentarios.Visible = false;
            //lblMensajes.Visible = false;
            txtComentarios.Visible = false;
            btnAceptar.Visible = false;
            btnCancelar.Visible = false;
        }
        private void MostarCampos()
        {
            lblComentarios.Visible = true;
            lblMensajes.Visible = true;
            txtComentarios.Visible = true;
            btnAceptar.Visible = true;
            btnCancelar.Visible = true;

        }
        protected void limpiaCampos()
        {
            txtComentarios.Text = "";
            OcultarCampos();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                if (gvPendientesTransferencia.Rows.Count > 0)
                {

                    GridViewRow row = gvPendientesTransferencia.SelectedRow;

                    cre.Id = Convert.ToInt32(row.Cells[1].Text);
                    cre.IdSolicitud = Convert.ToInt32(row.Cells[2].Text);
                }
                else
                {
                    gvPendientesTransferencia.Visible = false;
                }
                bd.GuardarCredito(cre.IdSolicitud, txtComentarios.Text.ToString());
                CargarGrid();
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
            }
            lblMensajes.Visible = true;
            lblMensajes.Text = "INFORMACIÓN: La solicitud fue aprobada y se crea el crédito";
            //Response.Write("<script>alert('INFORMACIÓN: La solicitud fue aprobada y se crea el crédito');</script>");
            CargarGrid();
            limpiaCampos();
            OcultarCampos();           
        }
        protected void gvPendientesTransferencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostarCampos();
            lblMensajes.Visible = false;
        }
        protected void gvPendientesTransferencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //DataTable dtG = bd.ConsultaSolicitudAprobaciones();
            DataTable dtGVirtualAprobaciones = ViewState["VirtualAprobacion"] as DataTable;
            if (dtGVirtualAprobaciones.Rows.Count >= 1)
            {
                gvPendientesTransferencia.PageIndex = e.NewPageIndex;
                gvPendientesTransferencia.DataSource = dtGVirtualAprobaciones;
                gvPendientesTransferencia.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            OcultarCampos();
        }
    }


}