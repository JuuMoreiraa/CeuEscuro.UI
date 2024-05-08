using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class UsuarioBLL
    {
        //Objeto para acesso geral aos recursos da DAL
        UsuarioDAL objBLL = new UsuarioDAL();

        //AutenticarUsuario
        public UsuarioDTO AutenticarUsuario(string nome, string senha)
        {
            return objBLL.Autenticar(nome, senha);
        }
    }
}
