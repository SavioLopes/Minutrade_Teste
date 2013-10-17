using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClientIntegrationApp.IntegrationServiceReference;

namespace ClientIntegrationApp
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            IntegrationClient servico = new IntegrationClient();
            foreach (Cliente c in servico.retornaClientes())
            {
                Label1.Text = Label1.Text + c.Nome + " ";
            }
        }
    }
}
