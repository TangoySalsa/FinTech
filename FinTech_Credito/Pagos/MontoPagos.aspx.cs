using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;

namespace Dashboard_Bajas_Carrier.Pagos
{
    public partial class MontoPagos : System.Web.UI.Page
    {
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        Logica.LogicaPagos bd = new Logica.LogicaPagos();
        Logica.Logica lg = new Logica.Logica();
        Entidades.Pagos pa = new Entidades.Pagos();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ObtenerCobro( string Identificacion, Int32 IdCredito, int Cuota)
        {
            decimal TotalPagar = 0;
            PagosCP _PagosCP = new PagosCP();
            _PagosCP = bd.ObtenerCobro(Identificacion, IdCredito, Cuota);
            if (_PagosCP.Pagos.Count >= 1)
            {
                txtNombreCliente.Text = _PagosCP._ClienteSolicitud[0].Nombre;
                txtProducto.Text = _PagosCP.Pagos[0].NombreProducto;
                txtCredito.Text = Convert.ToString(_PagosCP.Pagos[0].IdCredito);
                txtSaldoCorte.Text = Convert.ToString(_PagosCP.Pagos[0].SaldoActual);
                txtSaldoPendiente.Text = Convert.ToString(_PagosCP.Pagos[0].Diferencia);
                txtStatus.Text = Convert.ToString(_PagosCP.Pagos[0].Status);
                txtInteresMora.Text = Convert.ToString(_PagosCP.Pagos[0].InteresMora);
                llenaComboCuota(txtIdentificación.Text, _PagosCP.Pagos[0].IdCredito);
                cb_NumCuota.SelectedValue = Convert.ToString(_PagosCP.Pagos[0].Cuota);
                txtMontoCuota.Text = Convert.ToString(_PagosCP.Pagos[0].Capital);
                txtInteresCuota.Text = Convert.ToString(_PagosCP.Pagos[0].Interes);
                txtTotalPagar.Text = Convert.ToString(_PagosCP.Pagos[0].MontoCuota + _PagosCP.Pagos[0].Diferencia);
                
            }
            else
            {
                Response.Write("<script>alert('No se ha encontrado pagos pendientes para este Cliente');</script>");
                VaciarCampos();
            }
        }
        protected void llenaComboCuota(string Identificacion , Int32 Id)
        {
            cb_NumCuota.DataSource = bd.llenaComboCuota(Identificacion,Id);
            cb_NumCuota.DataTextField = "Cuota";
            cb_NumCuota.DataValueField = "Cuota";
            cb_NumCuota.DataBind();
        }
        protected void VaciarCampos()
        {
            txtIdCredito.Text = "";
            txtIdentificación.Text = "";
            txtNombreCliente.Text = "";
            txtStatus.Text = "";
            txtProducto.Text = "";
            txtCredito.Text = "";
            txtSaldoCorte.Text = "";
            txtSaldoPendiente.Text = "";
            txtStatus.Text = "";
            txtInteresMora.Text = "";
            cb_NumCuota.SelectedValue = "1";
            txtMontoCuota.Text = "";
            txtMontoPagar.Text = "";
            txtInteresCuota.Text = "";
            txtTotalPagar.Text = "";

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                int var = 0;
                if (txtIdCredito.Text != "")
                {
                    var = Convert.ToInt32(txtIdCredito.Text);
                }
                else {
                    var = 0;
                }
                ObtenerCobro(txtIdentificación.Text, var, 1);
                lblMensajes.Visible = false;
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                lg.GuardarErrores("MontoPagos.aspx", "btnBuscar_Click1" + " " +
                                                                                     "@txtIdCredito.Text " + " " + Convert.ToString(txtIdCredito.Text) + " " +
                                                                                     "@txtIdentificación.Text" + " " + Convert.ToString(txtIdentificación.Text) + " " +
                                                                                     "@txtNombreCliente.Text" + " " + Convert.ToString(txtNombreCliente.Text) + " " +
                                                                                     "@txtStatus.Text" + " " + Convert.ToString(txtStatus.Text) + " " +
                                                                                     "@txtProducto.Text" + " " + Convert.ToString(txtProducto.Text) + " " +
                                                                                     "@txtCredito.Text" + " " + Convert.ToString(txtCredito.Text) + " " +
                                                                                     "@txtSaldoCorte.Text" + " " + Convert.ToString(txtSaldoCorte.Text) + " " +
                                                                                     "@txtSaldoPendiente.Text" + " " + Convert.ToString(txtSaldoPendiente.Text) + " " +
                                                                                     "@txtInteresMora.Text" + " " + Convert.ToString(txtInteresMora.Text)
                                                                                                                   , Convert.ToString(ex));
            }
        }

        protected void cb_NumCuota_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ObtenerCobro(txtIdentificación.Text, Convert.ToInt32(txtCredito.Text), Convert.ToInt32(cb_NumCuota.SelectedValue));
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                lg.GuardarErrores("MontoPagos.aspx", "btnBuscar_Click1" + " " +
                                                                                     "@txtIdCredito.Text " + " " + Convert.ToString(txtIdCredito.Text) + " " +
                                                                                     "@txtIdentificación.Text" + " " + Convert.ToString(txtIdentificación.Text) + " " +
                                                                                     "@txtNombreCliente.Text" + " " + Convert.ToString(txtNombreCliente.Text) + " " +
                                                                                     "@txtStatus.Text" + " " + Convert.ToString(txtStatus.Text) + " " +
                                                                                     "@txtProducto.Text" + " " + Convert.ToString(txtProducto.Text) + " " +
                                                                                     "@txtCredito.Text" + " " + Convert.ToString(txtCredito.Text) + " " +
                                                                                     "@txtSaldoCorte.Text" + " " + Convert.ToString(txtSaldoCorte.Text) + " " +
                                                                                     "@txtSaldoPendiente.Text" + " " + Convert.ToString(txtSaldoPendiente.Text) + " " +
                                                                                     "@txtInteresMora.Text" + " " + Convert.ToString(txtInteresMora.Text)
                                                                                                                   , Convert.ToString(ex));
            }
        }

        protected void btnPagar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtCredito.Text)  | (string.IsNullOrEmpty(txtMontoPagar.Text)))
                {
                    lblMensajes.Visible = true;                 
                    lblMensajes.Text = "ERROR: Todos los campos son requeridos";
                }
                else {
                    Entidades.Pagos _RealizaPago = new Entidades.Pagos();

                    _RealizaPago.IdCredito = Convert.ToInt32(txtIdCredito.Text.ToString());
                    _RealizaPago.Cuota = Convert.ToInt32(cb_NumCuota.SelectedValue);
                    _RealizaPago.MontoPagoCuota = Convert.ToDecimal(txtMontoPagar.Text.ToString());

                    bd.RealizarPago(_RealizaPago);

                    VaciarCampos();
                    lblMensajes.Visible = true;
                    lblMensajes.Text = "El pago se a realizado con exito ";
                }
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                lg.GuardarErrores("MontoPagos.aspx", "btnPagar_Click1" + " " +
                                                                                     "@txtIdCredito.Text " + " " + Convert.ToString(txtIdCredito.Text) + " " +
                                                                                     "@txtIdentificación.Text" + " " + Convert.ToString(txtIdentificación.Text) + " " +
                                                                                     "@txtNombreCliente.Text" + " " + Convert.ToString(txtNombreCliente.Text) + " " +
                                                                                     "@txtStatus.Text" + " " + Convert.ToString(txtStatus.Text) + " " +
                                                                                     "@txtProducto.Text" + " " + Convert.ToString(txtProducto.Text) + " " +
                                                                                     "@txtCredito.Text" + " " + Convert.ToString(txtCredito.Text) + " " +
                                                                                     "@txtSaldoCorte.Text" + " " + Convert.ToString(txtSaldoCorte.Text) + " " +
                                                                                     "@txtSaldoPendiente.Text" + " " + Convert.ToString(txtSaldoPendiente.Text) + " " +
                                                                                     "@txtInteresMora.Text" + " " + Convert.ToString(txtInteresMora.Text)
                                                                                                                   , Convert.ToString(ex));
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            VaciarCampos();
        }

    }
}