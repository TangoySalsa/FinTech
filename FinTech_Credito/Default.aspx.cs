using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Dashboard_Bajas_Carrier
{
    public partial class _Default : Page
    {        
        Logica.Logica bd = new Logica.Logica();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtUser.Attributes["placeholder"] = "usuario";
                txtPass.Attributes["placeholder"] = "contraseña";
                Global.user = null;
                Global.logueado = 0;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bd.Login(txtUser.Text.Trim(), txtPass.Text.Trim());

                if (dt.Rows.Count > 0)
                {                    
                    
                    Global.user = dt.Rows[0]["Usuario"].ToString();
                    Global.logueado = 1;

                    Global.privilegio = int.Parse(dt.Rows[0]["Rol"].ToString());

                    //if (idCarrier == 1)
                    Response.Redirect("Inicio.aspx");                    
                }
                else
                    Response.Write("<script>alert('Usuario o Contraseña INCORRECTO !');</script>");
            }
            catch 
            {
                
            }
        }
    }
}