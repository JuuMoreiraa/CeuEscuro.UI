using CeuEscuro.BLL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CeuEscuro
{
    public partial class Login : System.Web.UI.Page
    {
        UsuarioDTO usuario = new UsuarioDTO();
        UsuarioBLL usuarioBLL = new UsuarioBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //entrar
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtNomeUsuario.Text.Trim();
            string senha = txtSenhaUsuario.Text.Trim();

            usuario = usuarioBLL.AutenticarUsuario(nome, senha);

            if (usuario != null)
            {
                switch (usuario.TipoUsuario_Id)
                {
                    case "1":
                        Session["Usuario"] = usuario.NomeUsuario.Trim();
                        Response.Redirect("adm/ManagerUser.aspx");
                        break;
                    case "2":
                        Session["Usuario"] = usuario.NomeUsuario.Trim();
                        Response.Redirect("user/ConsultaUser.aspx");
                        break;
                }
            }
            else
            {
                lblMessagem.Text = $"Usuário {txtNomeUsuario.Text.Trim()} não cadastrado";
                txtNomeUsuario.Text = string.Empty;
            }

        }
    }
}