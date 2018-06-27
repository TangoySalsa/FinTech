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
    public partial class SolicitudBuro : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        Entidades.Buro bu = new Entidades.Buro();
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        int IdSolicitud;

        protected void Page_Load(object sender, EventArgs e)
        {
            MaintainScrollPositionOnPostBack = true;

            if (!Page.IsPostBack)
            {
                string var = txtFiltro.Text.ToString();
                llenaGrid(var);
                OcultarCampos();
                //Llena los combos del formulario
                llenaProvincias();
                llenaCantones();
                llenaDistritos();
                llenaEstadosPersonas();
                llenaRangoSalarial();
                llenaTipoAsalaria();
            }

            //if (Page.IsPostBack)
            //{
            //    llenaGrid();
            //    llenaGrid();
            //}


        }
        protected void llenaProvincias()
        {
            cbProvincia.DataSource = ut.LlenaComboBox("Provincia", "IdProvincia", "Nombre");
            cbProvincia.DataTextField = "Nombre";
            cbProvincia.DataValueField = "IdProvincia";
            cbProvincia.DataBind();
        }
        protected void llenaCantones()
        {
            cbCanton.DataSource = ut.LlenaComboBox1Parametro("Canton", "IdCanton", "Nombre", "IdProvincia", cbProvincia.SelectedItem.Value);
            cbCanton.DataTextField = "Nombre";
            cbCanton.DataValueField = "IdCanton";
            cbCanton.DataBind();
        }
        protected void llenaDistritos()
        {
            cbDistrito.DataSource = ut.LlenaComboBox2Parametros("Distrito", "IdDistrito", "Nombre", "IdCanton", cbCanton.SelectedItem.Value, "IdProvincia", cbProvincia.SelectedItem.Value);
            cbDistrito.DataTextField = "Nombre";
            cbDistrito.DataValueField = "IdDistrito";
            cbDistrito.DataBind();
        }
        protected void llenaEstadosPersonas()
        {
            cbEstatusPersona.DataSource = ut.LlenaComboBox1Parametro("tipos", "Id", "Descripcion", "IdTipo", "6");
            cbEstatusPersona.DataTextField = "Descripcion";
            cbEstatusPersona.DataValueField = "Id";
            cbEstatusPersona.DataBind();
        }
        protected void llenaRangoSalarial()
        {
            cbSalario.DataSource = ut.LlenaComboBox("RangoSalarial", "Id", "CONVERT(VARCHAR,SalarioInicial)  +' a '+CONVERT(VARCHAR,SalarioFinal) [Rango]");
            cbSalario.DataTextField = "Rango";
            cbSalario.DataValueField = "Id";
            cbSalario.DataBind();
        }
        protected void llenaTipoAsalaria()
        {
            cbTipoAsegurado.DataSource = ut.LlenaComboBox1Parametro("tipos", "Id", "Descripcion", "IdTipo", "9");
            cbTipoAsegurado.DataTextField = "Descripcion";
            cbTipoAsegurado.DataValueField = "Id";
            cbTipoAsegurado.DataBind();
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                if (GridView1.Rows.Count > 0)
                {

                    GridViewRow row = GridView1.SelectedRow;

                    bu.IdSolicitud = Convert.ToInt32(row.Cells[1].Text);
                    IdSolicitud = bu.IdSolicitud;
                }

                DataTable dtcb = bd.ConsultaSolicitudBuro(bu.IdSolicitud);

                txtEdad.Text = dtcb.Rows[0][2].ToString();
                //cbBienMueble.SelectedValue = dtcb.Rows[0][3].ToString() == "" ? "0" : dtcb.Rows[0][3].ToString();
                txtBienMueble.Text = dtcb.Rows[0][3].ToString() == "" ? "0" : dtcb.Rows[0][3].ToString();
                //cbBienesInmuebles.SelectedValue = dtcb.Rows[0][4].ToString() == "" ? "0" : dtcb.Rows[0][4].ToString();
                txtBienesInmuebles.Text = dtcb.Rows[0][4].ToString() == "" ? "0" : dtcb.Rows[0][4].ToString();
                cbEstatusPersona.SelectedValue = dtcb.Rows[0][5].ToString() == "0" ? "16" : dtcb.Rows[0][5].ToString();
                //cbReportesComerciales.SelectedValue = dtcb.Rows[0][6].ToString() == "" ? "0" : dtcb.Rows[0][6].ToString();
                txtReportesComerciales.Text= dtcb.Rows[0][6].ToString() == "" ? "0" : dtcb.Rows[0][6].ToString();
                txtJuicios.Text= dtcb.Rows[0][7].ToString() == "" ? "0" : dtcb.Rows[0][7].ToString();
                txtPrendas.Text = dtcb.Rows[0][8].ToString() == "" ? "0" : dtcb.Rows[0][8].ToString();
                txtHipotecas.Text = dtcb.Rows[0][9].ToString() == "" ? "0" : dtcb.Rows[0][9].ToString();
                //cbJuicios.SelectedValue = dtcb.Rows[0][7].ToString() == "" ? "0" : dtcb.Rows[0][7].ToString();
                //cbPrendas.SelectedValue = dtcb.Rows[0][8].ToString() == "" ? "0" : dtcb.Rows[0][8].ToString();
                //cbHipotecas.SelectedValue = dtcb.Rows[0][9].ToString() == "" ? "0" : dtcb.Rows[0][9].ToString();
                cbSalario.SelectedValue = dtcb.Rows[0][10].ToString() == "" ? "1" : dtcb.Rows[0][10].ToString();
                cbProvincia.SelectedValue = dtcb.Rows[0][11].ToString() == "" ? "1" : dtcb.Rows[0][11].ToString();
                cbCanton.SelectedValue = dtcb.Rows[0][12].ToString() == "" ? "1" : dtcb.Rows[0][12].ToString();
                cbDistrito.SelectedValue = dtcb.Rows[0][13].ToString() == "" ? "1" : dtcb.Rows[0][13].ToString();
                txtDireccion.Text = dtcb.Rows[0][14].ToString() == "" ? "1" : dtcb.Rows[0][14].ToString();
                txtComentarios.Text = dtcb.Rows[0][15].ToString();
                cbTipoAsegurado.SelectedValue = dtcb.Rows[0][16].ToString() == "" ? "22" : dtcb.Rows[0][16].ToString();
                txtNumeroAsegurado.Text = dtcb.Rows[0][17].ToString();

                MostarCampos();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                bd.GuardarErrores("SolicitudBuro.aspx", "GridView1_SelectedIndexChanged" + " " + "@IdSolicitud" + " " + Convert.ToString(IdSolicitud)
                                                                                               , Convert.ToString(ex));
            }
        }
        protected void cbProvincia_SelectedIndexChanged1(object sender, EventArgs e)
        {
            llenaCantones();
            llenaDistritos();
        }
        protected void cbCanton_SelectedIndexChanged1(object sender, EventArgs e)
        {
            llenaDistritos();
        }
        private void OcultarCampos()
        {
            txtEdad.Visible = false;
            lblEdad.Visible = false;
            //cbBienMueble.Visible = false;
            txtBienMueble.Visible = false;
            lblBienMueble.Visible = false;
            //cbBienesInmuebles.Visible = false;
            txtBienesInmuebles.Visible = false;
            lblBienesInmuebles.Visible = false;
            cbEstatusPersona.Visible = false;
            lblEstatusPersona.Visible = false;
            //cbReportesComerciales.Visible = false;
            txtReportesComerciales.Visible = false;
            lblReportesComerciales.Visible = false;
            //cbJuicios.Visible = false;
            txtJuicios.Visible = false;
            lblJuicios.Visible = false;
            //cbPrendas.Visible = false;
            txtPrendas.Visible = false;
            lblPrendas.Visible = false;
            //cbHipotecas.Visible = false;
            txtHipotecas.Visible = false;
            lblHipotecas.Visible = false;
            cbSalario.Visible = false;
            lblSalario.Visible = false;
            cbProvincia.Visible = false;
            lblProvincia.Visible = false;
            cbCanton.Visible = false;
            lblCanton.Visible = false;
            cbDistrito.Visible = false;
            lblDistrito.Visible = false;
            txtDireccion.Visible = false;
            lblDireccion.Visible = false;
            txtComentarios.Visible = false;
            lblComentarios.Visible = false;
            cbTipoAsegurado.Visible = false;
            lblTipoAsegurado.Visible = false;
            txtNumeroAsegurado.Visible = false;
            lblNumeroAsegurado.Visible = false;
            btnAceptar.Visible = false;
            btnRechazar.Visible = false;
            btnCancelar.Visible = false;
        }
        private void MostarCampos()
        {
            txtEdad.Visible = true;
            lblEdad.Visible = true;
            //cbBienMueble.Visible = true;
            txtBienMueble.Visible = true;
            lblBienMueble.Visible = true;
            //cbBienesInmuebles.Visible = true;
            txtBienesInmuebles.Visible = true;
            lblBienesInmuebles.Visible = true;
            cbEstatusPersona.Visible = true;
            lblEstatusPersona.Visible = true;
            //cbReportesComerciales.Visible = true;
            txtReportesComerciales.Visible = true;
            lblReportesComerciales.Visible = true;
            //cbJuicios.Visible = true;
            txtJuicios.Visible = true;
            lblJuicios.Visible = true;
            //cbPrendas.Visible = true;
            txtPrendas.Visible = true;
            lblPrendas.Visible = true;
            //cbHipotecas.Visible = true;
            txtHipotecas.Visible = true;
            lblHipotecas.Visible = true;
            cbSalario.Visible = true;
            lblSalario.Visible = true;
            cbProvincia.Visible = true;
            lblProvincia.Visible = true;
            cbCanton.Visible = true;
            lblCanton.Visible = true;
            cbDistrito.Visible = true;
            lblDistrito.Visible = true;
            txtDireccion.Visible = true;
            lblDireccion.Visible = true;
            txtComentarios.Visible = true;
            lblComentarios.Visible = true;
            cbTipoAsegurado.Visible = true;
            lblTipoAsegurado.Visible = true;
            txtNumeroAsegurado.Visible = true;
            lblNumeroAsegurado.Visible = true;
            btnAceptar.Visible = true;
            btnRechazar.Visible = true;
            btnCancelar.Visible = true;

        }
        protected void llenaGrid(string Identificacion)
        {
            DataTable dtG = bd.ConsultaSolicitud(Identificacion);
            ViewState["VirtualBuro"] = dtG;
            if (dtG.Rows.Count >= 1)
            {
                GridView1.DataSource = dtG;
                GridView1.DataBind();
            }
            else
                Response.Write("<script>alert('No existen solicitudes para aprobar');</script>");
        }
        protected void limpiaCampos()
        {
           
            txtBienesInmuebles.Text = "";
            txtBienMueble.Text = "";
            txtComentarios.Text = "";
            txtDireccion.Text = "";
            txtEdad.Text = "";
            txtHipotecas.Text = "";
            txtJuicios.Text = "";
            txtNumeroAsegurado.Text = "";
            txtPrendas.Text = "";
            txtReportesComerciales.Text = "";            
            llenaGrid("");
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiaCampos();

        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = GridView1.SelectedRow;
                bu.IdSolicitud = Convert.ToInt32(row.Cells[1].Text);
                bu.Edad = Convert.ToInt32(txtEdad.Text);
                bu.EstatusPersona = Convert.ToInt32(cbEstatusPersona.SelectedValue);
                bu.NumeroAsegurado = txtNumeroAsegurado.Text;
                bu.TipoAsegurado = Convert.ToInt32(cbTipoAsegurado.SelectedValue);
                //bu.BienesInmuebles = Convert.ToInt32(cbBienesInmuebles.SelectedValue);
                bu.BienesInmuebles = Convert.ToInt32(txtBienesInmuebles.Text);
                //bu.BienMueble = Convert.ToInt32(cbBienMueble.SelectedValue);
                bu.BienMueble = Convert.ToInt32(txtBienMueble.Text);
                //bu.Prendas = Convert.ToInt32(cbPrendas.SelectedValue);
                bu.Prendas = Convert.ToInt32(txtPrendas.Text);
                //bu.Hipotecas = Convert.ToInt32(cbHipotecas.SelectedValue);
                bu.Hipotecas = Convert.ToInt32(txtHipotecas.Text);
                //bu.ReportesComerciales = Convert.ToInt32(cbReportesComerciales.SelectedValue);
                bu.ReportesComerciales = Convert.ToInt32(txtReportesComerciales.Text);
                //bu.Juicios = Convert.ToInt32(cbJuicios.SelectedValue);
                bu.Juicios = Convert.ToInt32(txtJuicios.Text);
                bu.Salario = Convert.ToInt32(cbSalario.SelectedValue);
                bu.Provincia = Convert.ToInt32(cbProvincia.SelectedValue);
                bu.Canton = Convert.ToInt32(cbCanton.SelectedValue);
                bu.Distrito = Convert.ToInt32(cbDistrito.SelectedValue);
                bu.Comentarios = txtComentarios.Text;
                bu.Direccion = txtDireccion.Text;
                bu.Estado = 13;

                bd.GuardarSolicitudBuro(bu.IdSolicitud, bu.Edad, bu.EstatusPersona, bu.NumeroAsegurado, bu.TipoAsegurado, bu.BienesInmuebles, bu.BienMueble,
                    bu.Prendas, bu.Hipotecas, bu.ReportesComerciales, bu.Juicios, bu.Salario, bu.Provincia, bu.Canton, bu.Distrito, bu.Comentarios, bu.Direccion, bu.Estado);

                string var = "";
                llenaGrid(var);
                OcultarCampos();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                bd.GuardarErrores("SolicitudBuro.aspx", "btnAceptar_Click" + " " + "@IdSolicitud" + " " + Convert.ToString(bu.IdSolicitud) + " " +
                                                                                     "@Edad" + " " + Convert.ToString(bu.Edad) + " " +
                                                                                     "@EstatusPersona" + " " + Convert.ToString(bu.EstatusPersona) + " " +
                                                                                     "@NumeroAsegurado" + " " + Convert.ToString(bu.NumeroAsegurado) + " " +
                                                                                     "@TipoAsegurado" + " " + Convert.ToString(bu.TipoAsegurado) + " " +
                                                                                     "@BienesInmuebles" + " " + Convert.ToString(bu.BienesInmuebles) + " " +
                                                                                     "@BienMueble" + " " + Convert.ToString(bu.BienMueble) + " " +
                                                                                     "@Prendas" + " " + Convert.ToString(bu.Prendas) + " " +
                                                                                     "@Hipotecas" + " " + Convert.ToString(bu.Hipotecas) + " " +
                                                                                     "@Salario" + " " + Convert.ToString(bu.Salario) + " " +
                                                                                     "@Provincia" + " " + Convert.ToString(bu.Provincia) + " " +
                                                                                     "@Canton" + " " + Convert.ToString(bu.Canton) + " " +
                                                                                     "@Distrito" + " " + Convert.ToString(bu.Distrito) + " " +
                                                                                     "@Comentarios" + " " + bu.Comentarios + " " +
                                                                                     "@Direccion" + " " + bu.Direccion + " " +
                                                                                     "@Estado" + " " + Convert.ToString(bu.Estado)
                                                                                      , Convert.ToString(ex));
            }

        }
        protected void btnRechazar_Click(object sender, EventArgs e)
        {

            try
            {
                GridViewRow row = GridView1.SelectedRow;
                bu.IdSolicitud = Convert.ToInt32(row.Cells[1].Text);
                bu.Edad = Convert.ToInt32(txtEdad.Text);
                bu.EstatusPersona = Convert.ToInt32(cbEstatusPersona.SelectedValue);
                bu.NumeroAsegurado = txtNumeroAsegurado.Text;
                bu.TipoAsegurado = Convert.ToInt32(cbTipoAsegurado.SelectedValue);
                //bu.BienesInmuebles = Convert.ToInt32(cbBienesInmuebles.SelectedValue);
                bu.BienesInmuebles = Convert.ToInt32(txtBienesInmuebles.Text);
                //bu.BienMueble = Convert.ToInt32(cbBienMueble.SelectedValue);
                bu.BienMueble = Convert.ToInt32(txtBienMueble.Text);
                //bu.Prendas = Convert.ToInt32(cbPrendas.SelectedValue);
                bu.Prendas = Convert.ToInt32(txtPrendas.Text);
                //bu.Hipotecas = Convert.ToInt32(cbHipotecas.SelectedValue);
                bu.Hipotecas = Convert.ToInt32(txtHipotecas.Text);
                //bu.ReportesComerciales = Convert.ToInt32(cbReportesComerciales.SelectedValue);
                bu.ReportesComerciales = Convert.ToInt32(txtReportesComerciales.Text);
                //bu.Juicios = Convert.ToInt32(cbJuicios.SelectedValue);
                bu.Juicios = Convert.ToInt32(txtJuicios.Text);
                bu.Salario = Convert.ToInt32(cbSalario.SelectedValue);
                bu.Provincia = Convert.ToInt32(cbProvincia.SelectedValue);
                bu.Canton = Convert.ToInt32(cbCanton.SelectedValue);
                bu.Distrito = Convert.ToInt32(cbDistrito.SelectedValue);
                bu.Comentarios = txtComentarios.Text;
                bu.Direccion = txtDireccion.Text;
                bu.Estado = 15;

                bd.GuardarSolicitudBuro(bu.IdSolicitud, bu.Edad, bu.EstatusPersona, bu.NumeroAsegurado, bu.TipoAsegurado, bu.BienesInmuebles, bu.BienMueble,
                    bu.Prendas, bu.Hipotecas, bu.ReportesComerciales, bu.Juicios, bu.Salario, bu.Provincia, bu.Canton, bu.Distrito, bu.Comentarios, bu.Direccion, bu.Estado);

                llenaGrid(txtFiltro.Text.ToString());
                OcultarCampos();

            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                bd.GuardarErrores("SolicitudBuro.aspx", "btnAceptar_Click" + " " + "@IdSolicitud" + " " + Convert.ToString(bu.IdSolicitud) + " " +
                                                                                    "@Edad" + " " + Convert.ToString(bu.Edad) + " " +
                                                                                    "@EstatusPersona" + " " + Convert.ToString(bu.EstatusPersona) + " " +
                                                                                    "@NumeroAsegurado" + " " + Convert.ToString(bu.NumeroAsegurado) + " " +
                                                                                    "@TipoAsegurado" + " " + Convert.ToString(bu.TipoAsegurado) + " " +
                                                                                    "@BienesInmuebles" + " " + Convert.ToString(bu.BienesInmuebles) + " " +
                                                                                    "@BienMueble" + " " + Convert.ToString(bu.BienMueble) + " " +
                                                                                    "@Prendas" + " " + Convert.ToString(bu.Prendas) + " " +
                                                                                    "@Hipotecas" + " " + Convert.ToString(bu.Hipotecas) + " " +
                                                                                    "@Salario" + " " + Convert.ToString(bu.Salario) + " " +
                                                                                    "@Provincia" + " " + Convert.ToString(bu.Provincia) + " " +
                                                                                    "@Canton" + " " + Convert.ToString(bu.Canton) + " " +
                                                                                    "@Distrito" + " " + Convert.ToString(bu.Distrito) + " " +
                                                                                    "@Comentarios" + " " + bu.Comentarios + " " +
                                                                                    "@Direccion" + " " + bu.Direccion + " " +
                                                                                    "@Estado" + " " + Convert.ToString(bu.Estado)
                                                                                     , Convert.ToString(ex));
            }

        }
        protected void GridView1_PageIndexChanging(Object sender, GridViewPageEventArgs e)
        {
            DataTable dtGBuro = ViewState["VirtualBuro"] as DataTable;

            if (dtGBuro.Rows.Count >= 1)
            {
                GridView1.PageIndex = e.NewPageIndex;
                GridView1.DataSource = dtGBuro;
                GridView1.DataBind();
            }
        }
        private string ConvertSortDirectionToSql(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = " ASC ";
                    break;

                case SortDirection.Descending:
                    newSortDirection = " DESC ";
                    break;
            }

            return newSortDirection;
        }
        protected void gridView1_Sorting(object sender, GridViewSortEventArgs e)
        {

            DataTable dtG = bd.ConsultaSolicitud(txtFiltro.Text.ToString());

            DataTable dataTable = dtG;// GridView1.DataSource as DataTable;

            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + "" + ConvertSortDirectionToSql(e.SortDirection);

                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            llenaGrid(txtFiltro.Text.ToString());
        }
    }
}