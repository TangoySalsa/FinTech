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
    public partial class EstatusSolicitudes : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        Entidades.Buro bu = new Entidades.Buro();
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        Entidades.Credito cre = new Entidades.Credito();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                DataTable dtC = bd.ConsultaSolicitudesStatus(13);
                DataTable dtR = bd.ConsultaSolicitudRechazados();

                ViewState["VirtualEstatusC"] = dtC;
                ViewState["VirtualEstatusR"] = dtR;

                if (dtC.Rows.Count >= 1)
                {


                    gvPreAprobadas.DataSource = dtC;
                    gvPreAprobadas.DataBind();

                    gvRechazadas.DataSource = dtR;
                    gvRechazadas.DataBind();
                }
                else
                    Response.Write("<script>alert('No se encuentran solicitudes pre-aprobadas.');</script>");
            }
        }

        protected void gvRechazadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            DataTable dtGVirtualR = ViewState["VirtualEstatusR"] as DataTable;

          //  DataTable dtG = bd.ConsultaSolicitudRechazados();
            if (dtGVirtualR.Rows.Count >= 1)
            {
                gvRechazadas.PageIndex = e.NewPageIndex;
                gvRechazadas.DataSource = dtGVirtualR;
                gvRechazadas.DataBind();
            }
        }

        protected void gvPreAprobadas_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           // DataTable dtG = bd.ConsultaSolicitudAprobaciones();

            DataTable dtGVirtualC = ViewState["VirtualEstatusC"] as DataTable;

            if (dtGVirtualC.Rows.Count >= 1)
            {
                gvPreAprobadas.PageIndex = e.NewPageIndex;
                gvPreAprobadas.DataSource = dtGVirtualC;
                gvPreAprobadas.DataBind();
            }
        }

        protected void gvPreAprobadas_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMensajes.Visible = false;
            btnAprobar.Visible = true;
            btnCancelar.Visible = true;
        }

        protected void btnAprobar_Click(object sender, EventArgs e)
        {
            try
            {
                lblMensajes.Visible = false;
                if (gvPreAprobadas.Rows.Count > 0)
                {

                    GridViewRow row = gvPreAprobadas.SelectedRow;

                    cre.Id = Convert.ToInt32(row.Cells[1].Text);
                    cre.IdSolicitud = Convert.ToInt32(row.Cells[2].Text);
                }

                bd.ApruebaSolicitud(cre.Id, cre.IdSolicitud);

                DataTable dtC = bd.ConsultaSolicitudesStatus(13);

                ViewState["VirtualEstatusC"] = dtC;
                if (dtC.Rows.Count >= 1)
                {


                    gvPreAprobadas.DataSource = dtC;
                    gvPreAprobadas.DataBind();
                    
                }
                else
                    Response.Write("<script>alert('No se encuentran solicitudes pre-aprobadas.');</script>");
            
                lblMensajes.Visible = true;
                lblMensajes.Text = "INFORMACIÓN: La solicitud fue aprobada ";
                //Response.Write("<script>alert('INFORMACIÓN: La solicitud fue aprobada y se crea el crédito');</script>");
                btnAprobar.Visible = false;
                btnCancelar.Visible = false;
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
            }
            lblMensajes.Visible = true;
            lblMensajes.Text = "INFORMACIÓN: La solicitud fue aprobada ";
            //Response.Write("<script>alert('INFORMACIÓN: La solicitud fue aprobada y se crea el crédito');</script>");
           
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            btnCancelar.Visible = false;
            btnAprobar.Visible = false;

        }
    }
}