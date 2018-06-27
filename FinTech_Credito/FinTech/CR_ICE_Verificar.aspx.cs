using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dashboard_Bajas_Carrier.CR_ICE
{
    public partial class CR_ICE_Verificar : System.Web.UI.Page
    {
        Logica.Logica bd = new Logica.Logica();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = bd.Verificar(txtNumero.Text.Trim());

                GridView1.DataSource = dt;
                GridView1.AutoGenerateColumns = true;                
                GridView1.DataBind();
            }
            catch
            {
                Response.Write("<script>alert('ERROR: favor comunicarse con el administrador !');</script>");
            }
        }
    }
}