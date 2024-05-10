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

        //CRUD
        //Create
        public void CreateUser(UsuarioDTO usuario)
        {
            objBLL.Create(usuario);
        }
        //Read
        public List<UsuarioDTO> GetUsersAll()
        {
            return objBLL.GetUsers();
        }
        //Update
        public void UpdateUser(UsuarioDTO usuario)
        {
            objBLL.Update(usuario);
        }
        //Delete
        public void DeleteUser(int idUsuario)
        {
            objBLL.Delete(idUsuario);
        }

        //SearchById
        public UsuarioDTO GetById(int usuarioId)
        {
             return objBLL.Search(usuarioId);
        }
        //SearchByName
        public UsuarioDTO GetByName(string usuarioName)
        {
            return objBLL.Search(usuarioName);
        }

        //Droplist
        public List<TipoUsuarioDTO> LoadDropListUs()
        {
            return objBLL.LoadDropList();
        }
        //CTRL + K + D = Identa
    }
}
