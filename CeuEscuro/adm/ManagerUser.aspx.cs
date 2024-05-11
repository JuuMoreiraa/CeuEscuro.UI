using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro.adm
{
    public partial class ManageUser : System.Web.UI.Page
    {
        UsuarioBLL objBLL = new UsuarioBLL();
        UsuarioDTO objDTO = new UsuarioDTO();

        //pageLoad
        protected void Page_Load(object sender, EventArgs e)
        {
            txtIdUsuario.Enabled = false;
            //Encapsulamento
            Populargv1();
            PopularDDL1();
        } 

        //popular gv1
        public void Populargv1()
        {
            gv1.DataSource = objBLL.GetUsersAll();
            //imprime os dados na tela
            gv1.DataBind();
        }

        public void PopularDDL1()
        {
            ddl1.DataSource = objBLL.LoadDropListUs();
            ddl1.DataBind();
        }
    }
}