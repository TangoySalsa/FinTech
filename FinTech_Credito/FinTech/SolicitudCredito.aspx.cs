using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using System.Text.RegularExpressions;




namespace FinTech
{
    public partial class SolicitudCredito : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        Entidades.Solicitudes so = new Entidades.Solicitudes();
        Entidades.ClienteSolicitud CliSol = new Entidades.ClienteSolicitud();      
        Logica.Utilitarios.Utilitarios ut = new Logica.Utilitarios.Utilitarios();
        int IdCliente = 0;
        int IdSolicitud;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                MaintainScrollPositionOnPostBack = true;
            
            if (!Page.IsPostBack)
            {
                lblMensajes.Visible = false;
                lblMensaje2.Visible = false;
                dtFechaNacimiento.Attributes["placeholder"] = "Fech.Nacimiento";
                dtFechaVencimientoCedula.Attributes["placeholder"] = "Fech.Ven Céd";
                lblFechaI.Text = DateTime.Today.ToShortDateString();
                txtIdentificacion.Attributes["placeholder"] = "Identificación";
                txtNombre1.Attributes["placeholder"] = "1er Nombre";
                txtNombre2.Attributes["placeholder"] = "2do Nombre";
                txtApellido1.Attributes["placeholder"] = "1er Apellido";
                txtApellido2.Attributes["placeholder"] = "2do Apellido";
                txtTelefonoFijo.Attributes["placeholder"] = "Casa";
                txtTelefonoCel.Attributes["placeholder"] = "Celular";
                txtTelefonoLaboral.Attributes["placeholder"] = "Laboral";
                //txtCuentaBco1.Attributes["placeholder"] = "Cta Banco";
                //txtCuentaSinpeBco1.Attributes["placeholder"] = "Cta Banco Sinpe";
                //txtCuentaBco2.Attributes["placeholder"] = "Cta Banco";
                //txtCuentaSinpeBco2.Attributes["placeholder"] = "Cta Banco Sinpe";
                txtEmail1.Attributes["placeholder"] = "Email 1";
                txtEmail2.Attributes["placeholder"] = "Email 2";
                DataTable dt = ut.ExtraeSolicitudMax();
                LblSolicitud.Text = dt.Rows[0][0].ToString();

                //Llena los combos del formulario
                llenaProvincias();
                llenaCantones();
                llenaDistritos();
                llenaProductos();
                //llenaBancos();
                llenaSexo();
                llenaEstadoCivil();
                    
                CargarGridVacio();
                llenaGridSolicitudes(12,"");
                    llenaFiltro(5);
                    OcultarDatosAsesor();
                GridSolicitudes.Visible = true;
                btnCargar.Visible = false;
                }
           
            }
            catch (Exception ex)
            {
                bd.GuardarErrores("SolicitudCredito.aspx", "Page_Load" + " " + "@IdSolicitud" + " " + Convert.ToString(LblSolicitud.Text)
                                                                                       , Convert.ToString(ex));
            }
        }

        private void OcultarDatosAsesor()
        {
            hdfIdPersona.Visible = false;
            dtFechaVencimientoCedula.Visible = false;
            txtNombre1.Visible = false;
            txtNombre2.Visible = false;
            txtApellido1.Visible = false;
            txtApellido2.Visible = false;
            txtTelefonoCel.Visible = false;
            txtTelefonoFijo.Visible = false;
            txtTelefonoLaboral.Visible = false;
            txtEmail1.Visible = false;
            cbEstadoCivil.Visible = false;
            cbSexo.Visible = false;
            dtFechaNacimiento.Visible = false;
            cbProvincia.Visible = false;
            cbCanton.Visible = false;
            cbDistrito.Visible = false;
            txtDireccion.Visible = false;
            
            lblMensajes.Visible = false;
            lblMensaje2.Visible = false;
            txtIdentificacion.Visible = false;
            lblIdentificacion.Visible = false;
            btnBuscar.Visible = false;
            lblNombre.Visible = false;
            lblVencimiento.Visible = false;
            lblEstadoCivil0.Visible = false;
            lblTitulo1.Visible = false;
            lblFechaNacimiento.Visible = false;
            lblTitulo2.Visible = false;
            //txtTelefonos.Visible = false;
            lblEmail1.Visible = false;
            txtEmail2.Visible = false;
            txtEmail2.Visible = false;
            Label2.Visible = false;
            lblProducto.Visible = false;
            cbProducto.Visible = false;
            lblUsoCredito.Visible = false;
            txtUsoCredito.Visible = false;
            Label4.Visible = false;
            GridView1.Visible = false;
            Label5.Visible = false;
            lblDomicilio.Visible = false;
            cbProvincia.Visible = false;
            cbDistrito.Visible = false;
            cbCanton.Visible = false;
            lblOtrasSenas.Visible = false;
            txtDireccion.Visible = false;
            lblSexo.Visible = false;
            lblEmail3.Visible = false;
            lblEmail1.Visible = false;
            lblCanton.Visible = false;
            lblProvincia.Visible = false;
            lblDistrito.Visible = false;
            btnGuardar.Visible = false;
            btnLimpiar.Visible = false;
            Label1.Visible = false;
            LblSolicitud.Visible = false;
            Label3.Visible = false;
            lblFechaI.Visible = false;
            lblStatusOrdenPatronal.Visible = false;
            cbOrdenPatronal.Visible = false;
            lblTelefonoFijo.Visible = false;
            lbltelefonoCel.Visible = false;
            LblTelefonoLaboral.Visible = false;
        }

        private void MostrarDatosAsesor()
        {
            hdfIdPersona.Visible = true;
            dtFechaVencimientoCedula.Visible = true;
            txtNombre1.Visible = true;
            txtNombre2.Visible = true;
            txtApellido1.Visible = true;
            txtApellido2.Visible = true;
            txtTelefonoCel.Visible = true;
            txtTelefonoFijo.Visible = true;
            txtTelefonoLaboral.Visible = true;
            txtEmail1.Visible = true;
            cbEstadoCivil.Visible = true;
            cbSexo.Visible = true;
            dtFechaNacimiento.Visible = true;
            cbProvincia.Visible = true;
            cbCanton.Visible = true;
            cbDistrito.Visible = true;
            txtDireccion.Visible = true;

            lblMensajes.Visible = true;
            lblMensaje2.Visible = true;
            txtIdentificacion.Visible = true;
            lblIdentificacion.Visible = true;
            btnBuscar.Visible = true;
            lblNombre.Visible = true;
            lblVencimiento.Visible = true;
            lblEstadoCivil0.Visible = true;
            lblTitulo1.Visible = true;
            lblFechaNacimiento.Visible = true;
            lblTitulo2.Visible = true;
           // txtTelefonos.Visible = true;
            lblEmail1.Visible = true;
            txtEmail2.Visible = true;
            txtEmail2.Visible = true;
            Label2.Visible = true;
            lblProducto.Visible = true;
            cbProducto.Visible = true;
            lblUsoCredito.Visible = true;
            txtUsoCredito.Visible = true;
            Label4.Visible = true;
            GridView1.Visible = true;
            Label5.Visible = true;
            lblDomicilio.Visible = true;
            cbProvincia.Visible = true;
            cbDistrito.Visible = true;
            cbCanton.Visible = true;
            lblOtrasSenas.Visible = true;
            txtDireccion.Visible = true;
            lblSexo.Visible = true;
            lblEmail3.Visible = true;
            lblEmail1.Visible = true;
            lblCanton.Visible = true;
            lblProvincia.Visible = true;
            lblDistrito.Visible = true;
            btnGuardar.Visible = true;
            btnLimpiar.Visible = true;
            Label1.Visible = true;
            LblSolicitud.Visible = true;
            Label3.Visible = true;
            lblFechaI.Visible = true;
            lblStatusOrdenPatronal.Visible = true;
            cbOrdenPatronal.Visible = true;
            lblTelefonoFijo.Visible = true;
            lbltelefonoCel.Visible = true;
            LblTelefonoLaboral.Visible = true;

        }


        protected void llenaGridSolicitudes(Int32 Id, string Identificacion)
        {
            DataTable dtG = bd.ConsultaSolicitudPendientes(Id, Identificacion);
            ViewState["Virtual"] = dtG;

            if (dtG.Rows.Count >= 1)
            {
                GridSolicitudes.DataSource = dtG;
                GridSolicitudes.DataBind();
            }
            else
                Response.Write("<script>alert('No existen solicitudes para aprobar');</script>");
        }

        protected void GridSolicitudes_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (GridSolicitudes.Rows.Count > 0)
                {
                    GridViewRow row = GridSolicitudes.SelectedRow;
                    LblSolicitud.Text = row.Cells[1].Text;
                    so.Identificacion = row.Cells[2].Text;
                    
                }

                //so.Identificacion = txtIdentificacion.Text;
                //DataTable dt =  bd.ServiciosSolicitud(so.Identificacion);
                List<Solicitudes> _Solicitudes = new List<Solicitudes>();
                _Solicitudes = bd.ServiciosSolicitud(so.Identificacion);
                if (_Solicitudes.Count >= 1)
                {
                    foreach (var row in _Solicitudes)
                    {
                        //hdfIdPersona.Value = dt.Rows[0][0].ToString();
                        hdfIdPersona.Value = Convert.ToString(row.Id);
                        //dtFechaNacimientoCedula.Value = Convert.ToDateTime(dt.Rows[0][3]).ToString("yyyy-MM-dd");
                        dtFechaVencimientoCedula.Value = Convert.ToDateTime(row.VencimientoIdentificacion).ToString("yyyy-MM-dd");
                        //txtIdentificacion.Text = dt.Rows[0][2].ToString();
                        txtIdentificacion.Text = row.Identificacion;
                        //txtNombre1.Text = dt.Rows[0][4].ToString();
                        txtNombre1.Text = row.PrimerNombre;
                        //txtNombre2.Text = dt.Rows[0][5].ToString();
                        txtNombre2.Text = row.SegundoNombre;
                        //txtApellido1.Text = dt.Rows[0][6].ToString();
                        txtApellido1.Text = row.PrimerApellido;
                        //txtApellido2.Text = dt.Rows[0][7].ToString();
                        txtApellido2.Text = row.SegundoApellido;
                        //txtTelefonoCel.Text = dt.Rows[0][8].ToString();
                        txtTelefonoCel.Text = Convert.ToString(row.TelefonoCel);
                        //txtTelefonoFijo.Text = dt.Rows[0][9].ToString();
                        txtTelefonoFijo.Text = Convert.ToString(row.TelefonoFijo);
                        //txtTelefonoLaboral.Text = dt.Rows[0][10].ToString();
                        txtTelefonoLaboral.Text = Convert.ToString(row.TelefonoLaboral);
                        //txtEmail1.Text = dt.Rows[0][11].ToString();
                        txtEmail1.Text = row.Correo;
                        //cbEstadoCivil.SelectedValue = dt.Rows[0][13].ToString();
                        cbEstadoCivil.SelectedValue = Convert.ToString(row.EstadoCivil);
                        //cbSexo.SelectedValue = dt.Rows[0][14].ToString();
                        cbSexo.SelectedValue = Convert.ToString(row.Sexo);
                        //dtFechaNacimiento.Value = Convert.ToDateTime(dt.Rows[0][15]).ToString("yyyy-MM-dd");
                        dtFechaNacimiento.Value = Convert.ToDateTime(row.FechaNacimiento).ToString("yyyy-MM-dd");
                        //cbProvincia.SelectedValue = dt.Rows[0][16].ToString();
                        cbProvincia.SelectedValue = Convert.ToString(row.Provincia);
                        //cbCanton.SelectedValue = dt.Rows[0][17].ToString();
                        cbCanton.SelectedValue = Convert.ToString(row.Canton);
                        //cbDistrito.SelectedValue = dt.Rows[0][18].ToString();
                        cbDistrito.SelectedValue = Convert.ToString(row.Distrito);
                        //txtDireccion.Text = dt.Rows[0][19].ToString();
                        txtDireccion.Text = row.DetalleDireccion;
                        //IdCliente = Convert.ToInt32(dt.Rows[0][0].ToString());
                        IdCliente = row.Id;
                        //cbOrdenPatronal = Convert.ToBoolean(dt.Rows[0][0].ToString());
                        cbOrdenPatronal.Checked = row.OrdenPatronal;
                        cbProducto.SelectedValue = Convert.ToString(row.IdProducto);
                    }
                    lblMensajes.Visible = false;
                    lblMensaje2.Visible = false;

                    ObtenerCuentaCliente(so.Identificacion, so.Id);
                    MostrarDatosAsesor();
                    GridSolicitudes.Visible = false;
                    lblFiltrar.Visible = false;
                    lblBuscar.Visible = false;
                    txtBuscarporIdentificacion.Visible = false;
                    btnFiltro.Visible = false;
                    cbFiltro.Visible = false;
                    btnCargar.Visible = true;
                    lblError.Visible = false;
                }
                else
                {
                    limpiaCampos();
                    lblError.Visible = true;
                    lblError.Text = "Error al cargar el registro con el numero de cedula " + so.Identificacion;
                }
                   
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                //bd.GuardarErrores("SolicitudBuro.aspx", "GridView1_SelectedIndexChanged" + " " + "@IdSolicitud" + " " + Convert.ToString(IdSolicitud)
                //                                                                               , Convert.ToString(ex));
            }
        }

        


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Cargar Cuenta de la Solicitud
            DataTable GuarCuentaSol = ViewState["VSCuentaBanco"] as DataTable;
            try
            {
                string aux = "";
                string aux2 = "";
                String ID = GuarCuentaSol.Rows[GuarCuentaSol.Rows.Count - 1]["ID_gv"].ToString();
                //Valida Cuenta predeterminada
                foreach (DataRow row in GuarCuentaSol.Rows)
                {
                    Boolean var = Convert.ToBoolean(row["Predeterminado"].ToString());
                    string NumCuenta = row["Cuenta"].ToString();
                    string IDv = Convert.ToString(row["ID_gv"].ToString());
                    if (var == true)
                    {
                        aux = null;
                    }
                    if (NumCuenta == "")
                    {
                        aux2 = "";
                    }
                        
                }
                
                if (string.IsNullOrEmpty(txtNombre1.Text) | (txtTelefonoCel.Text == "0")|
               (string.IsNullOrEmpty(txtApellido1.Text)) | /*(string.IsNullOrEmpty(txtApellido2.Text)) |*/
               (string.IsNullOrEmpty(txtTelefonoCel.Text)) | (string.IsNullOrEmpty(dtFechaNacimiento.Value)) |
               (string.IsNullOrEmpty(txtDireccion.Text)) | ((aux != null))|((ID == "0")) |/* | (string.IsNullOrEmpty(txtCuentaSinpeBco1.Text)))*/
               (aux2 == "")
               )
            {

                    //Response.Write("<script>alert('ERROR: Todos los campos son requeridos');</script>");
                    lblMensajes.Visible = true;
                    lblMensaje2.Visible = true;
                lblMensaje2.Text = "ERROR: Todos los campos son requeridos";
                LblValidaCuentaPred.Visible = true;
                    if (aux != null)
                    {
                        LblValidaCuentaPred.Text = "Debe de agregar una cuenta a la solicitud o seleccionar una como predeterminada";
                        return;
                    }
                    else if(aux2 == "")
                    {
                        LblValidaCuentaPred.Text = "Debe de ingresar el número de cuenta para todos los bancos ";
                        return;
                    }
            }         

            so.IdProducto = Convert.ToInt32(cbProducto.SelectedValue);
            so.UsrModifica = "Pruebas";
            so.Identificacion = txtIdentificacion.Text;
            so.IdTipoIdentificacion = IdCliente;
            so.VencimientoIdentificacion = dtFechaVencimientoCedula.Value;
            so.PrimerNombre = txtNombre1.Text;
            so.SegundoNombre = txtNombre2.Text;
            so.PrimerApellido = txtApellido1.Text;
            so.SegundoApellido = txtApellido2.Text;
            so.TelefonoCel = Convert.ToInt32(txtTelefonoCel.Text);
            so.TelefonoFijo = Convert.ToInt32(txtTelefonoFijo.Text == "" ? 0 : Convert.ToInt32(txtTelefonoFijo.Text));
            so.TelefonoLaboral = Convert.ToInt32(txtTelefonoLaboral.Text == "" ? 0 : Convert.ToInt32(txtTelefonoLaboral.Text));
            so.Correo = txtEmail1.Text;
            so.CorreoOpcional = "";
            so.EstadoCivil = Convert.ToInt32(cbEstadoCivil.Text == "" ? 0 : Convert.ToInt32(cbEstadoCivil.Text));
            so.Sexo = Convert.ToInt32(cbSexo.SelectedValue == "" ? 0 : Convert.ToInt32(cbSexo.SelectedValue));
            so.FechaNacimiento = dtFechaNacimiento.Value;
            so.Provincia = Convert.ToInt32(cbProvincia.Text == "" ? 0 : Convert.ToInt32(cbProvincia.SelectedValue));
            so.Canton = Convert.ToInt32(cbCanton.SelectedValue == "" ? 0 : Convert.ToInt32(cbCanton.SelectedValue));
            so.Distrito = Convert.ToInt32(cbDistrito.SelectedValue == "" ? 0 : Convert.ToInt32(cbDistrito.SelectedValue));
            so.DetalleDireccion = txtDireccion.Text;
            //so.Cuenta = txtCuentaBco1.Text == "" ? "0" : txtCuentaBco1.Text;
            //so.Cuentasinpe = txtCuentaSinpeBco1.Text == "" ? "0" : txtCuentaSinpeBco1.Text;
            //so.Banco = Convert.ToInt32(cbBancos1.SelectedValue == "" ? 0 : Convert.ToInt32(cbBancos1.SelectedValue));
            so.UsoCredito = txtUsoCredito.Text;



            DataTable dt = bd.ServiciosGuardar(so.IdTipoIdentificacion, so.Identificacion, so.VencimientoIdentificacion,
                                                so.PrimerNombre, so.SegundoNombre, so.PrimerApellido, so.SegundoApellido, so.TelefonoCel,
                so.TelefonoFijo, so.TelefonoLaboral, so.Correo, so.CorreoOpcional, so.EstadoCivil, so.Sexo, so.FechaNacimiento,
                so.Provincia, so.Canton, so.Distrito, so.DetalleDireccion, so.UsrModifica, so.IdProducto, /*so.Cuenta, so.Cuentasinpe, so.Banco,*/
                so.UsoCredito);
                
                List<ClienteSolicitud> _ClienteSoliGuardar = new List<ClienteSolicitud>();
                //_ClienteSoli = bd.ObtenerClientesSol(so.Identificacion);
                //Recorre Cuentas para ser insertadar o actualizadas
                foreach (DataRow row in GuarCuentaSol.Rows)
                {

                    if (((row["Operacion"].ToString()) == "U")||((row["Operacion"].ToString()) == "I")) 
                    {
                        //Condicionado para Guardar un nuevo Detalle de la Solicitud a base de datos cuando se envia el ID y la fecha de atención 
                        //if ((row["ID"].ToString())!= "")
                        //{
                        //    CliSol.Id = Convert.ToInt32(row["Id"].ToString());
                        //}
                        Entidades.ClienteSolicitud ClientSol = new ClienteSolicitud();
                        ClientSol.Id = Convert.ToInt32(row["Id"].ToString());
                        ClientSol.IdBanco = Convert.ToInt32(row["IdBanco"].ToString());
                        ClientSol.IdPersona = Convert.ToInt32(row["IdPersona"].ToString());
                        ClientSol.Cuenta = row["Cuenta"].ToString();
                        ClientSol.CuentaSinpe = row["CuentaSinpe"].ToString();
                        ClientSol.CuentaIban = row["CuentaIban"].ToString();
                        ClientSol.Operacion = Convert.ToChar(row["Operacion"].ToString());
                        ClientSol.Predeterminado = Convert.ToBoolean(row["Predeterminado"].ToString());

                        _ClienteSoliGuardar.Add(ClientSol);
                    }
                }

                //Si existen archivos en base de datos que hay que eliminar antes de enviar la solicitud se recorre el view state 
                if ((ViewState["dtEliminadoTableCuentaBanco"] != null))
                {
                    DataTable dtDetalleSolEliminados = ViewState["dtEliminadoTableCuentaBanco"] as DataTable;
                    foreach (DataRow rowEliminados in dtDetalleSolEliminados.Rows)
                    {
                        if ((rowEliminados["Id"].ToString())!= "0")
                        {
                            Entidades.ClienteSolicitud ClientSol = new ClienteSolicitud();
                            ClientSol.Id = Convert.ToInt32(rowEliminados["Id"].ToString());
                            ClientSol.IdBanco = Convert.ToInt32(rowEliminados["IdBanco"].ToString());
                            ClientSol.IdPersona = Convert.ToInt32(rowEliminados["IdPersona"].ToString());
                            ClientSol.Cuenta = rowEliminados["Cuenta"].ToString();
                            ClientSol.CuentaSinpe = rowEliminados["CuentaSinpe"].ToString();
                            ClientSol.CuentaIban = rowEliminados["CuentaIban"].ToString();
                            ClientSol.Operacion = 'D';
                            ClientSol.Predeterminado = Convert.ToBoolean(rowEliminados["Predeterminado"].ToString());
                            _ClienteSoliGuardar.Add(ClientSol);
                        }
                    }
                }
                //Guarda cambios en las cuentas
                bd.GuardarClienteSolicitud(_ClienteSoliGuardar);
               CargarGridVacio();
                lblMensajes.Visible = false;
                lblMensaje2.Visible = false;
                LblValidaCuentaPred.Visible = false;
                lblMensaje2.Text = "INFORMACIÓN: La Solicitud fue almacenada de manera exitosa";
           
                limpiaCampos();
                llenaGridSolicitudes(12,"");
                OcultarDatosAsesor();
                GridSolicitudes.Visible = true;
                lblFiltrar.Visible = true;
                cbFiltro.Visible = true;
                btnCargar.Visible = false;
                lblMensajes.Text = "";
                lblMensaje2.Text = "";
                //Mantenemos la pagina al inicio cuando se genera el PostBack
                MaintainScrollPositionOnPostBack = false;


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                bd.GuardarErrores("SolicitudCredito.aspx", "btnGuardar_Click" + " " + "@IdProducto" + " " +         Convert.ToString(so.IdProducto) + " " +
                                                                                      "@UsrModifica" + " " +        Convert.ToString(so.UsrModifica) + " " +
                                                                                      "@Identificacion" + " " +     Convert.ToString(so.Identificacion) + " " +
                                                                                      "@IdTipoIdentificacion" + " " + Convert.ToString(so.IdTipoIdentificacion) + " " +
                                                                                      "@VencimientoIdentificacion" + " " + Convert.ToString(so.VencimientoIdentificacion) + " " +
                                                                                      "@PrimerNombre" + " " +       Convert.ToString(so.PrimerNombre) + " " +
                                                                                      "@SegundoNombre" + " " +      Convert.ToString(so.SegundoNombre) + " " +
                                                                                      "@PrimerApellido" + " " +     Convert.ToString(so.PrimerApellido) + " " +
                                                                                      "@SegundoApellido" + " " +    Convert.ToString(so.SegundoApellido) + " " +
                                                                                      "@TelefonoCel" + " " +        Convert.ToString(so.TelefonoCel) + " " +
                                                                                      "@TelefonoFijo" + " " +       Convert.ToString(so.TelefonoFijo) + " " +
                                                                                      "@TelefonoLaboral" + " " +    Convert.ToString(so.TelefonoLaboral) + " " +
                                                                                      "@Correo" + " " +             Convert.ToString(so.Correo) + " " +
                                                                                      "@CorreoOpcional" + " " +     Convert.ToString(so.CorreoOpcional) + " " +
                                                                                      "@EstadoCivil" + " " +        Convert.ToString(so.EstadoCivil) + " " +
                                                                                      "@Sexo" + " " +               Convert.ToString(so.Sexo) + " " +
                                                                                      "@FechaNacimiento" + " " +    Convert.ToString(so.FechaNacimiento) + " " +
                                                                                      "@Provincia" + " " +          Convert.ToString(so.Provincia) + " " +
                                                                                      "@Canton" + " " +             Convert.ToString(so.Canton) + " " +
                                                                                      "@Distrito" + " " +           Convert.ToString(so.Distrito) + " " +
                                                                                      "@DetalleDireccion" + " " +   Convert.ToString(so.DetalleDireccion) + " " +
                                                                                      "@IdProducto" + " " +         Convert.ToString(so.IdProducto) + " " +
                                                                                      "@Cuenta" + " " +             Convert.ToString(so.Cuenta) + " " +
                                                                                      "@Cuentasinpe" + " " +        Convert.ToString(so.Cuentasinpe) + " " +
                                                                                      "@Banco" + " " +              Convert.ToString(so.Banco) 
                                                                                                                    , Convert.ToString(ex));

            }



        }

        protected void llenaProvincias()
        {
            cbProvincia.DataSource= ut.LlenaComboBox("Provincia", "IdProvincia", "Nombre");
            cbProvincia.DataTextField = "Nombre";
            cbProvincia.DataValueField = "IdProvincia";
            cbProvincia.DataBind();
        }

        protected void llenaCantones()
        {
            cbCanton.DataSource = ut.LlenaComboBox1Parametro("Canton", "IdCanton", "Nombre","IdProvincia",cbProvincia.SelectedItem.Value);
            cbCanton.DataTextField = "Nombre";
            cbCanton.DataValueField = "IdCanton";
            cbCanton.DataBind();
        }

        protected void llenaDistritos()
        {
            cbDistrito.DataSource = ut.LlenaComboBox2Parametros("Distrito", "IdDistrito", "Nombre", "IdCanton", cbCanton.SelectedItem.Value,"IdProvincia",cbProvincia.SelectedItem.Value);
            cbDistrito.DataTextField = "Nombre";
            cbDistrito.DataValueField = "IdDistrito";
            cbDistrito.DataBind();
        } 

        protected void llenaProductos()
        {
            cbProducto.DataSource = ut.LlenaComboBox("Productos", "Id", "NombreProducto");
            cbProducto.DataTextField = "NombreProducto";
            cbProducto.DataValueField = "Id";
            cbProducto.DataBind();
        }

        protected void llenaFiltro(Int32 Id)
        {
            cbFiltro.DataSource = ut.llenaComboFiltro(Id);
            cbFiltro.DataTextField = "Descripcion";
            cbFiltro.DataValueField = "Id";
            cbFiltro.DataBind();
        }
        protected void llenaBancos()
        {
            DropDownList drp_NewIdBanco = (DropDownList)GridView1.FooterRow.FindControl("drp_NewBanco");
            drp_NewIdBanco.DataSource = ut.LlenaComboBox("Banco", "Id", "Descripcion");
            drp_NewIdBanco.DataTextField = "Descripcion";
            drp_NewIdBanco.DataValueField = "Id";
            drp_NewIdBanco.DataBind();

            ////drp_NewIdBanco.DataSource = ut.LlenaComboBox("Banco", "Id", "Descripcion");
            ///drp_NewIdBanco.DataTextField = "Descripcion";
            //drp_NewIdBanco.DataValueField = "Id";
            //drp_NewIdBanco.DataBind();
        }

        protected void llenaSexo()
        {
            cbSexo.DataSource = ut.LlenaComboBox1Parametro("Tipos", "Id", "Descripcion", "IdTipo", "4");
            cbSexo.DataTextField = "Descripcion";
            cbSexo.DataValueField = "Id";
            cbSexo.DataBind();
        }

        protected void llenaEstadoCivil()
        {
            cbEstadoCivil.DataSource = ut.LlenaComboBox1Parametro("Tipos", "Id", "Descripcion", "IdTipo", "3");
            cbEstadoCivil.DataTextField = "Descripcion";
            cbEstadoCivil.DataValueField = "Id";
            cbEstadoCivil.DataBind();
        }
        protected void CargarGridVacio()
        {
            DataTable CuentaBanco = new DataTable();
            DataRow dr = null;

            CuentaBanco.Columns.Add(new DataColumn("ID_gv", typeof(int)));
            CuentaBanco.Columns.Add(new DataColumn("Id", typeof(int)));
            CuentaBanco.Columns.Add(new DataColumn("IdBanco", typeof(int)));
            CuentaBanco.Columns.Add(new DataColumn("IdPersona", typeof(int)));
            CuentaBanco.Columns.Add(new DataColumn("Descripcion", typeof(string)));
            CuentaBanco.Columns.Add(new DataColumn("Cuenta", typeof(string)));
            CuentaBanco.Columns.Add(new DataColumn("CuentaSinpe", typeof(string)));
            CuentaBanco.Columns.Add(new DataColumn("CuentaIban", typeof(string)));
            CuentaBanco.Columns.Add(new DataColumn("Operacion", typeof(string)));
            CuentaBanco.Columns.Add(new DataColumn("Predeterminado", typeof(Boolean)));

            //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas Bancarias
            dr = CuentaBanco.NewRow();
            dr["ID_gv"] = 0;
            dr["Id"] = 0;
            dr["IdPersona"] = 0;
            dr["IdBanco"] = 0;
            dr["Descripcion"] = "";
            dr["Cuenta"] = "";
            dr["CuentaSinpe"] = "";
            dr["CuentaIban"] = "";
            dr["Operacion"] = "";
            dr["Predeterminado"] = true;
            CuentaBanco.Rows.Add(dr);
            GridView1.DataSource = CuentaBanco;
            ViewState["VSCuentaBanco"] = CuentaBanco;
            GridView1.DataBind();
            MostrarFilaVacia();

        }
        protected void limpiaCampos()
        {
            txtApellido1.Text = "";
            txtApellido2.Text = "";
            txtNombre1.Text = "";
            txtNombre2.Text = "";
            txtEmail1.Text = "";
            txtEmail2.Text = "";
            //txtCuentaBco1.Text = "";
            //txtCuentaBco2.Text = "";
            //txtCuentaSinpeBco1.Text = "";
            //txtCuentaSinpeBco2.Text = "";
            txtDireccion.Text = "";
            txtIdentificacion.Text = "";
            dtFechaNacimiento.Value = "";
            txtTelefonoCel.Text = "";
            txtTelefonoFijo.Text = "";
            txtTelefonoLaboral.Text = "";
            //txtTelefonos.Text = "";
            txtUsoCredito.Text = "";
            dtFechaVencimientoCedula.Value = "";
            GridView1.DataSource = null;
            lblFiltrar.Visible = false;
            cbFiltro.Visible = false;
            GridView1.DataBind();
            txtBuscarporIdentificacion.Text = "";

        }
        protected void MostrarFilaVacia()
        {
            int _totalColumnas = GridView1.Rows[0].Cells.Count;
            GridView1.Rows[0].Cells.Clear();
            GridView1.Rows[0].Cells.Add(new TableCell());
            GridView1.Rows[0].Cells[0].ColumnSpan = _totalColumnas;
            GridView1.Rows[0].Cells[0].Text = "NoHayRegistros";
        }
        protected void gv_CuentaBanco_BindGrid()
        {
            GridView1.DataSource = ViewState["VSCuentaBanco"] as DataTable;
            GridView1.DataBind();

        }
        protected void cbProvincia_SelectedIndexChanged(object sender, EventArgs e) 
        {
            llenaCantones();
            llenaDistritos();

        }
        protected void cbCanton_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaDistritos();
        }

        protected void ObtenerCuentaCliente(string Identificacion, Int32 Id)
        {
            try {
                //Tabla Cuentas

                DataTable CuentaBanco = new DataTable();
                DataRow dr = null;

                CuentaBanco.Columns.Add(new DataColumn("ID_gv", typeof(int)));
                CuentaBanco.Columns.Add(new DataColumn("Id", typeof(int)));
                CuentaBanco.Columns.Add(new DataColumn("IdBanco", typeof(int)));
                CuentaBanco.Columns.Add(new DataColumn("IdPersona", typeof(int)));
                CuentaBanco.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                CuentaBanco.Columns.Add(new DataColumn("Cuenta", typeof(string)));
                CuentaBanco.Columns.Add(new DataColumn("CuentaSinpe", typeof(string)));
                CuentaBanco.Columns.Add(new DataColumn("CuentaIban", typeof(string)));
                CuentaBanco.Columns.Add(new DataColumn("Operacion", typeof(string)));
                CuentaBanco.Columns.Add(new DataColumn("Predeterminado", typeof(Boolean)));
                //Carga cuentas bancarias

                List<ClienteSolicitud> _ClienteSoli = new List<ClienteSolicitud>();
                _ClienteSoli = bd.ObtenerCuentaSol(Identificacion);

                int i = 1;
                foreach (var ClienteSol in _ClienteSoli)
                {
                    //Ingreso los detalles de solucion en la tabla para mostrarlo en el gridview de Cuentas Bancarias
                    dr = CuentaBanco.NewRow();
                    dr["ID_gv"] = i++;
                    dr["Id"] = ClienteSol.Id;
                    dr["IdPersona"] = ClienteSol.IdPersona;
                    dr["IdBanco"] = ClienteSol.IdBanco;
                    dr["Descripcion"] = ClienteSol.DescBanco;
                    dr["Cuenta"] = ClienteSol.Cuenta;
                    dr["CuentaSinpe"] = ClienteSol.CuentaSinpe;
                    dr["CuentaIban"] = ClienteSol.CuentaIban;
                    dr["Operacion"] = "";
                    dr["Predeterminado"] = ClienteSol.Predeterminado;

                    CuentaBanco.Rows.Add(dr);

                }
                //Si el cliente no posee cuentas carga grid vacio
                if (CuentaBanco.Rows.Count == 0)
                {
                    CargarGridVacio();
                }
                else {
                    //Muestro Cuentas de la solicitud en base de datos
                    ViewState["VSCuentaBanco"] = CuentaBanco;
                    GridView1.DataSource = CuentaBanco;
                    GridView1.DataBind();
                }

            }
           catch (Exception ex)
            { 
                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));
            }
        }

        protected void btnBuscar_Click1(object sender, EventArgs e)
        {
            try
            {
                so.Identificacion = txtIdentificacion.Text;
                so.Id = Convert.ToInt32(hdfIdPersona.Value);
                DataTable dt = bd.Servicios(so.Identificacion);
                if (dt.Rows.Count >= 1)
                {
                    hdfIdPersona.Value = dt.Rows[0][0].ToString();
                    dtFechaVencimientoCedula.Value = Convert.ToDateTime(dt.Rows[0][3]).ToString("yyyy-MM-dd");
                    txtNombre1.Text = dt.Rows[0][4].ToString();
                    txtNombre2.Text = dt.Rows[0][5].ToString();
                    txtApellido1.Text = dt.Rows[0][6].ToString();
                    txtApellido2.Text = dt.Rows[0][7].ToString();
                    txtTelefonoCel.Text = dt.Rows[0][8].ToString();
                    txtTelefonoFijo.Text = dt.Rows[0][9].ToString();
                    txtTelefonoLaboral.Text = dt.Rows[0][10].ToString();
                    txtEmail1.Text = dt.Rows[0][11].ToString();
                    cbEstadoCivil.SelectedValue = dt.Rows[0][13].ToString();
                    cbSexo.SelectedValue = dt.Rows[0][14].ToString();
                    dtFechaNacimiento.Value = Convert.ToDateTime(dt.Rows[0][15]).ToString("yyyy-MM-dd");
                    cbProvincia.SelectedValue = dt.Rows[0][16].ToString();
                    cbCanton.SelectedValue = dt.Rows[0][17].ToString();
                    cbDistrito.SelectedValue = dt.Rows[0][18].ToString();
                    txtDireccion.Text = dt.Rows[0][19].ToString();


                    IdCliente = Convert.ToInt32(dt.Rows[0][0].ToString());
                    lblMensajes.Visible = false;
                    lblMensaje2.Visible = false;

                    ObtenerCuentaCliente(so.Identificacion, so.Id);
                }
                else
                    // Response.Write("<script>alert('La persona ya cuenta con una solicitud en estudio.');</script>");
                    
                    lblMensajes.Visible = true;
                    lblMensajes.Text = "El cliente no existe ";
                
            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnBuscar_Click1" + " " +
                                                                                     "@txtNombre1.Text" + " " + Convert.ToString(txtNombre1.Text) + " " +
                                                                                     "@txtNombre2.Text" + " " + Convert.ToString(txtNombre2.Text) + " " +
                                                                                     "@txtApellido1.Text" + " " + Convert.ToString(txtApellido1.Text) + " " +
                                                                                     "@txtApellido2.Text" + " " + Convert.ToString(txtApellido2.Text) + " " +
                                                                                     "@txtTelefonoCel.Text" + " " + Convert.ToString(txtTelefonoCel.Text) + " " +
                                                                                     "@txtTelefonoFijo.Text" + " " + Convert.ToString(txtTelefonoFijo.Text) + " " +
                                                                                     "@txtTelefonoLaboral.Text" + " " + Convert.ToString(txtTelefonoLaboral.Text) + " " +
                                                                                     "@txtEmail1.Text" + " " + Convert.ToString(txtEmail1.Text) + " " +
                                                                                     "@CorreoOpcional" + " " + Convert.ToString(so.CorreoOpcional) + " " +
                                                                                     "@cbEstadoCivil.SelectedValue" + " " + Convert.ToString(cbEstadoCivil.SelectedValue) + " " +
                                                                                     "@cbSexo.SelectedValue " + " " + Convert.ToString(cbSexo.SelectedValue) + " " +
                                                                                     "@txtNacimiento.Text" + " " + Convert.ToString(dtFechaNacimiento.Value) + " " +
                                                                                     "@cbProvincia.SelectedValue" + " " + Convert.ToString(cbProvincia.SelectedValue) + " " +
                                                                                     "@cbCanton.SelectedValue" + " " + Convert.ToString(cbCanton.SelectedValue) + " " +
                                                                                     "@cbDistrito.SelectedValue" + " " + Convert.ToString(cbDistrito.SelectedValue) + " " +
                                                                                     "@IdCliente" + " " + Convert.ToString(IdCliente)
                                                                                                                   , Convert.ToString(ex));
            }

        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            try
            {

            limpiaCampos();
                lblMensajes.Visible = false;
                lblMensajes.Visible = false;
            lblMensaje2.Visible = false;

            }
            catch (Exception ex)
            {

                //Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click" , Convert.ToString(ex));
            }

        }

        #region MetodoCliente solicitud

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            
{
                //Si se presiona el botón para crear un nuevo ítem
                if (e.CommandName.Equals("ShowNew"))
                {

                    //Se habilita el Validator de creación
                    RequiredFieldValidator rqNuevCuent = (RequiredFieldValidator)GridView1.FooterRow.FindControl("rqNewCuentaBanco");
                    rqNuevCuent.Enabled = true;
                    RequiredFieldValidator rqNewCuentaSinpe = (RequiredFieldValidator)GridView1.FooterRow.FindControl("rqNewCuentaSinpe");
                    rqNewCuentaSinpe.Enabled = true;
                   
                    llenaBancos();
                    //Se muestran los controles para escribir la nueva información
                    DropDownList dbr_NewIdBanco = (DropDownList)GridView1.FooterRow.FindControl("drp_NewBanco");
                    dbr_NewIdBanco.Visible = true;
                    TextBox txtNewCuentaBanco = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaBanco");
                    txtNewCuentaBanco.Visible = true;
                    txtNewCuentaBanco.Focus();
                    TextBox txt_NewCuentaSinpe = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaSinpe");
                    txt_NewCuentaSinpe.Visible = true;
                    CheckBox cbxNewPredeterminado = (CheckBox)GridView1.FooterRow.FindControl("cbxNewPredeterminado");
                    cbxNewPredeterminado.Visible = true;

                    ImageButton btnNuevo = (ImageButton)GridView1.FooterRow.FindControl("btnNuevo");
                    btnNuevo.Visible = false;
                    ImageButton btnGuardar = (ImageButton)GridView1.FooterRow.FindControl("btnGuardargv");
                    btnGuardar.Visible = true;
                    ImageButton btnCancelar = (ImageButton)GridView1.FooterRow.FindControl("btnCancelar");
                    btnCancelar.Visible = true;
                }

                    //Si se presiona el botón para guardar el nuevo ítem
                    if (e.CommandName.Equals("AddNew"))
                    {
                        
                        DataTable dtCuentaBanco = (DataTable)ViewState["VSCuentaBanco"];
                        DataRow drCuentaBanc = null;
       
                        String ID = dtCuentaBanco.Rows[dtCuentaBanco.Rows.Count - 1]["ID_gv"].ToString();
                        //String Id = dtCuentaBanco.Rows[dtCuentaBanco.Rows.Count - 1]["Id"].ToString();
                        //String IdPer = dtCuentaBanco.Rows[dtCuentaBanco.Rows.Count - 1]["IdPersona"].ToString();

                    //Extrae de los controles los valores

                    TextBox txtNewCuentaBanc = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaBanco");
                        TextBox txt_NewCuentaSinp = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaSinpe");
                        DropDownList drp_NewIdBanco = (DropDownList)GridView1.FooterRow.FindControl("drp_NewBanco");
                        CheckBox cbxNewPredetermina = (CheckBox)GridView1.FooterRow.FindControl("cbxNewPredeterminado");
                        drp_NewIdBanco.Visible = true;


                    foreach (DataRow row in dtCuentaBanco.Rows)
                    {
                        //Coloca en falso la columna predeterminado cuando se selecciona un predeterminado nuevo
                        if (row["Predeterminado"].ToString() == Convert.ToString(cbxNewPredetermina.Checked))
                            row.SetField("Predeterminado", false);
                        if (row["Id"].ToString() == "0")
                        {
                            row.SetField("Operacion", "I");
                        }
                        else
                        {
                            row.SetField("Operacion", "U");
                        }

                    }

                    drCuentaBanc = dtCuentaBanco.NewRow();
                        drCuentaBanc["ID_gv"] = Convert.ToInt32(ID) + 1;
                        drCuentaBanc["Id"] = 0;
                        drCuentaBanc["IdPersona"] = hdfIdPersona.Value;
                        drCuentaBanc["IdBanco"] = Convert.ToInt32(drp_NewIdBanco.SelectedValue);
                        drCuentaBanc["Descripcion"] = drp_NewIdBanco.SelectedItem.ToString();
                        drCuentaBanc["Cuenta"] = txtNewCuentaBanc.Text.ToString(); 
                        drCuentaBanc["CuentaSinpe"] = txt_NewCuentaSinp.Text.ToString();
                        drCuentaBanc["CuentaIban"] = "";
                        drCuentaBanc["Operacion"] = "I";
                        drCuentaBanc["Predeterminado"] = Convert.ToBoolean(cbxNewPredetermina.Checked);
                    dtCuentaBanco.Rows.Add(drCuentaBanc);
                        if (ID == "0")
                        {

                        int max = dtCuentaBanco.Rows.Count - 1;
                            for (int i = max; i >= 0; --i)
                            {
                            //Elimina la fila vacia del Grid
                                if (dtCuentaBanco.Rows[i]["ID_gv"].ToString() == "0")
                                {
                                    dtCuentaBanco.Rows[i].BeginEdit();
                                    dtCuentaBanco.Rows[i].Delete();
                                }
                            }
                        }
                  
                        ViewState["VSCuentaBanco"] = dtCuentaBanco;
                        GridView1.DataSource = dtCuentaBanco;
                        GridView1.DataBind();
                    }
                    //Si se presiona el botón para cancelar la creación del nuevo ítem
                    if (e.CommandName.Equals("CancelNew"))
                    {
                        //Se reestablecen los campos a como estaban antes del evento "ShowNew"
                     
                        DropDownList dbr_NewIdBan = (DropDownList)GridView1.FooterRow.FindControl("drp_NewBanco");
                        dbr_NewIdBan.Visible = false;
                        dbr_NewIdBan.Text = string.Empty;
                        TextBox txtNewCuentaBan = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaBanco");
                        txtNewCuentaBan.Visible = false;
                        txtNewCuentaBan.Text = string.Empty;
                        TextBox txt_NewCuentaSin = (TextBox)GridView1.FooterRow.FindControl("txt_NewCuentaSinpe");
                        txt_NewCuentaSin.Visible = false;
                        txt_NewCuentaSin.Text = string.Empty;

                        ImageButton btnNuev = (ImageButton)GridView1.FooterRow.FindControl("btnNuevo");
                        btnNuev.Visible = true;
                        ImageButton btnGuarda = (ImageButton)GridView1.FooterRow.FindControl("btnGuardargv");
                        btnGuardar.Visible = false;
                        ImageButton btnCancela = (ImageButton)GridView1.FooterRow.FindControl("btnCancelar");
                        btnCancela.Visible = false;
                       // ModoAgregar = false;
                    }
                
            }
            catch (Exception ex)
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //Se reestablecen las variables de edición
            GridView1.EditIndex = -1;
            //  ModoEdicion = false;
            gv_CuentaBanco_BindGrid();
        }
      
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {

                //Se reestablecen las variables de sesión en caso de que estuvieran activadas
                GridView1.EditIndex = -1;

                int index = Convert.ToInt32(e.RowIndex);
                DataTable dtCuentaTable = ViewState["VSCuentaBanco"] as DataTable;
                String rowIndex = dtCuentaTable.Rows[e.RowIndex]["ID"].ToString();

                if (rowIndex == "")
                {
                    // El registros no se ha guarado en la base de datos por ende solo se borra del grid
                    dtCuentaTable.Rows[index].Delete();
                    dtCuentaTable.AcceptChanges();
                    ViewState["VSCuentaBanco"] = dtCuentaTable;

                    gv_CuentaBanco_BindGrid();
                }
                else
                {
                    // El registros existe en la base de datos por ende se debe marcar como eliminado del grid
                    DataTable dtEliminadoTableCuenta = new DataTable();
                    DataRow drEliminadoTableCuenta = null;
                    if (ViewState["dtEliminadoTableCuentaBanco"] == null)
                    {

                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("ID_gv", typeof(int)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("Id", typeof(int)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("IdPersona", typeof(int)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("IdBanco", typeof(int)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("Descripcion", typeof(string)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("Cuenta", typeof(string)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("CuentaSinpe", typeof(string)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("CuentaIban", typeof(string)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("Operacion", typeof(string)));
                        dtEliminadoTableCuenta.Columns.Add(new DataColumn("Predeterminado", typeof(Boolean)));

                    }
                    else
                    {
                        dtEliminadoTableCuenta = ViewState["dtEliminadoTableCuentaBanco"] as DataTable;
                    }
                    drEliminadoTableCuenta = dtEliminadoTableCuenta.NewRow();
                    drEliminadoTableCuenta["ID_gv"] = Convert.ToInt32(dtCuentaTable.Rows[e.RowIndex][0].ToString());
                    drEliminadoTableCuenta["Id"] = Convert.ToInt32(dtCuentaTable.Rows[e.RowIndex][1].ToString());
                    drEliminadoTableCuenta["IdPersona"] = Convert.ToInt32(dtCuentaTable.Rows[e.RowIndex][3].ToString());
                    drEliminadoTableCuenta["Predeterminado"] = Convert.ToBoolean(dtCuentaTable.Rows[e.RowIndex][9].ToString());
                    drEliminadoTableCuenta["IdBanco"] = Convert.ToInt32(dtCuentaTable.Rows[e.RowIndex][2].ToString());
                    drEliminadoTableCuenta["Descripcion"] = dtCuentaTable.Rows[e.RowIndex][4].ToString();
                    drEliminadoTableCuenta["Cuenta"] = dtCuentaTable.Rows[e.RowIndex][5].ToString();
                    drEliminadoTableCuenta["CuentaSinpe"] = dtCuentaTable.Rows[e.RowIndex][6].ToString();
                    drEliminadoTableCuenta["CuentaIban"] = dtCuentaTable.Rows[e.RowIndex][7].ToString();
                    drEliminadoTableCuenta["Operacion"] = "D";
                  

                    dtCuentaTable.Rows[index].Delete();
                    ViewState["VSCuentaBanco"] = dtCuentaTable;


                    dtEliminadoTableCuenta.Rows.Add(drEliminadoTableCuenta);
                    ViewState["dtEliminadoTableCuentaBanco"] = dtEliminadoTableCuenta;
                }
                if (dtCuentaTable.Rows.Count == 0)
                {
                   //Carga grid vacio en caso de eliminar todos los registros
                    CargarGridVacio();
                }
                else {
                    gv_CuentaBanco_BindGrid();
                }
            }
            catch (Exception ex)
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));

            }
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridView1.EditIndex = e.NewEditIndex;
                gv_CuentaBanco_BindGrid();
            }
            catch (Exception ex)
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));

            }
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                //Se reestablecen las variables de edición
                GridView1.EditIndex = -1;

                TextBox txt_CuentaBanco = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txt_CuentaBanco");
                TextBox Txt_CuentaSinpe = (TextBox)GridView1.Rows[e.RowIndex].FindControl("Txt_CuentaSinpe");
                CheckBox cbxNewPredetermina = (CheckBox)GridView1.Rows[e.RowIndex].FindControl("cbxPredeterminado");

                DataTable dtCuentaTable = ViewState["VSCuentaBanco"] as DataTable;

                foreach (DataRow row in dtCuentaTable.Rows)
                {
                    if (row["Predeterminado"].ToString() == Convert.ToString(cbxNewPredetermina.Checked))
                        row.SetField("Predeterminado", false);
                }

                String ID = dtCuentaTable.Rows[e.RowIndex]["ID"].ToString();

                if (ID == "")
                {
                    //En caso de que se actualice un registro en el grid que no esta en base de datos se coloca estado "I"
                    dtCuentaTable.Rows[e.RowIndex]["Operacion"] = "I";
                    
                }
                else
                {
                    //Se coloca estado "U" en caso de que se actualice un registro de base de datos
                    dtCuentaTable.Rows[e.RowIndex]["Operacion"] = "U";

                }
                dtCuentaTable.Rows[e.RowIndex]["Predeterminado"] = Convert.ToBoolean(cbxNewPredetermina.Checked.ToString());
                dtCuentaTable.Rows[e.RowIndex]["Cuenta"] = txt_CuentaBanco.Text.ToString();
                dtCuentaTable.Rows[e.RowIndex]["CuentaSinpe"] = Txt_CuentaSinpe.Text.ToString();
                ViewState["VSCuentaBanco"] = dtCuentaTable;
                GridView1.EditIndex = -1;
                gv_CuentaBanco_BindGrid();
            }
            catch (Exception ex)
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnLimpiar_Click", Convert.ToString(ex));

            }
        }

        #endregion MetodoCliente solicitud

     
        /// <summary>
        /// Manejamos el paginado de las solicitudes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PageIndexChanged_GridSolicitud(object sender, GridViewPageEventArgs e)
        {
            DataTable dtGVirtual = ViewState["Virtual"] as DataTable;
            
            if (dtGVirtual.Rows.Count >= 1)
            {
                GridSolicitudes.PageIndex = e.NewPageIndex;
                GridSolicitudes.DataSource = dtGVirtual;
                GridSolicitudes.DataBind();
            }

        }

        /// <summary>
        /// Vuelve a cargar la lista de solicitudes que se encuentran en estudio
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSolicitudes_Click(object sender, EventArgs e)
        {
            try
            {
                llenaGridSolicitudes(12,"");
                OcultarDatosAsesor();
                GridSolicitudes.Visible = true;
                lblFiltrar.Visible = true;
                cbFiltro.Visible = true;
                btnCargar.Visible = false;
                lblBuscar.Visible = true;
                btnBuscar.Visible = true;
                lblMensajes.Text = "";
                lblMensaje2.Text = "";
                txtBuscarporIdentificacion.Visible = true;
                btnFiltro.Visible = true;
      
                //Mantenemos la pagina al inicio cuando se genera el PostBack
                MaintainScrollPositionOnPostBack = false;
            }

            catch (Exception ex)
            {
                lblMensajes.Visible = true;
                lblMensajes.Text = "ERROR: favor comunicarse con el administrador !";
                bd.GuardarErrores("SolicitudCredito.aspx", "btnSolicitudes_Click", Convert.ToString(ex));
            }
        }

        protected void cbFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            llenaGridSolicitudes(Convert.ToInt32(cbFiltro.SelectedValue),txtBuscarporIdentificacion.Text.ToString());
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            llenaGridSolicitudes(Convert.ToInt32(cbFiltro.SelectedValue), txtBuscarporIdentificacion.Text.ToString());
            lblError.Visible = false;
        }

    }
}
