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
    public partial class WebForm1 : System.Web.UI.Page
    {
        UsuarioDTO usuario = new UsuarioDTO();
        UsuarioBLL usuarioBLL = new UsuarioBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            //Trim tira os espaços antes e depois do dado a ser pego
            string nome = txtNomeUsuario.Text.Trim();
            string senha = txtSenhaUsuario.Text.Trim();

            usuario = usuarioBLL.AutenticarUsuario(nome, senha);

            if (usuario != null) 
            {
                lblMessage.Text = $"Usuário {usuario.NomeUsuario} seu acesso foi liberado!!";

            }
            else 
            {
                lblMessage.Text = $"Usuário {nome} não cadastrado";
            }
        }
    }
}