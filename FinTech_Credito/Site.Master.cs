using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using System.Web.UI.HtmlControls;

namespace Dashboard_Bajas_Carrier
{
    public partial class SiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;        

        protected void Page_Init(object sender, EventArgs e)
        {
            // El código siguiente ayuda a proteger frente a ataques XSRF
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // Utilizar el token Anti-XSRF de la cookie
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // Generar un nuevo token Anti-XSRF y guardarlo en la cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Establecer token Anti-XSRF
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // Validar el token Anti-XSRF
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Error de validación del token Anti-XSRF.");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string user = Global.user;
            int logueado = Global.logueado;
            int carrier = Global.carrier;
            int privilegio = Global.privilegio;       
            HtmlAnchor logout = (HtmlAnchor)this.FindControl("logout");
            HtmlAnchor CR_Solicitud = (HtmlAnchor)this.FindControl("CR_Solicitud");
            HtmlAnchor CR_SolicitudBuro = (HtmlAnchor)this.FindControl("CR_SolicitudBuro");
            HtmlAnchor CR_EstatusSolicitudes = (HtmlAnchor)this.FindControl("CR_EstatusSolicitudes");
            HtmlAnchor CR_AContabilidad = (HtmlAnchor)this.FindControl("CR_AContabilidad");
            HtmlAnchor CR_CuentasCobrar = (HtmlAnchor)this.FindControl("CR_CuentasCobrar");
            //HtmlAnchor CR_AsignarCuentas = (HtmlAnchor)this.FindControl("CR_AsignarSolicitudes");
            HtmlAnchor CR_MontoPagos = (HtmlAnchor)this.FindControl("CR_MontoPagos");



            if (!Page.IsPostBack)
            {
                if (user == null)
                {                    
                    login.Text = "";      
                    logout.Visible = false;
                    CR_Solicitud.Visible = false;
                    CR_SolicitudBuro.Visible = false;
                    CR_EstatusSolicitudes.Visible = false;
                    CR_AContabilidad.Visible = false;
                    CR_CuentasCobrar.Visible = false;
                    //CR_AsignarCuentas.Visible = false;
                    CR_MontoPagos.Visible = false;
                    if (logueado == 1)
                        Response.Redirect("~/Default.aspx");
                }
                else
                {
                    login.Text = "Hola " + user + "";
                    logout.Visible = true;

                    if (privilegio == 1)
                    {
                        CR_Solicitud.Visible = true;
                        CR_SolicitudBuro.Visible = true;
                        CR_EstatusSolicitudes.Visible = true;
                        CR_AContabilidad.Visible = true;
                        CR_CuentasCobrar.Visible = true;
                        ////CR_AsignarCuentas.Visible = true;
                        CR_MontoPagos.Visible = true;
                    }
                    //Asesor
                    else if (privilegio == 2)
                    {
                        CR_Solicitud.Visible = true;
                        CR_SolicitudBuro.Visible = false;
                        CR_EstatusSolicitudes.Visible = false;
                        CR_AContabilidad.Visible = false;
                        CR_CuentasCobrar.Visible = true;
                        ////CR_AsignarCuentas.Visible = true;
                        CR_MontoPagos.Visible = true;
                    }
                    //Contabilidad
                    else if (privilegio == 3)
                    {
                        //Aqui se debe de colocar el acceso de contabiliada
                        CR_AContabilidad.Visible = true;
                        CR_Solicitud.Visible = false;
                        CR_SolicitudBuro.Visible = false;
                        CR_EstatusSolicitudes.Visible = false;
                        CR_CuentasCobrar.Visible = true;
                        //CR_AsignarCuentas.Visible = false;
                        CR_MontoPagos.Visible = true;
                    }
                }              
            }
        }

        protected void Unnamed_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            Context.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }
    }

}