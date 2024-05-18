using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.user
{
    public partial class ConsultaUser : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            PopularGv1();
        }
        public void PopularGv1()
        {
            gv1.DataSource = objBLL.GetUsersAll();
            gv1.DataBind();
        }
    }
}