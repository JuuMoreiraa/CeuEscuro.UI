using CeuEscuro.DAL;
using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.BLL
{
    public class FilmBLL
    {
        FilmDAL objBLL = new FilmDAL();

        public void CriaFilme(FilmDTO filme)
        {
            objBLL.Create(filme);
        }

        public List<FilmDTO> BuscaFilme()
        {
            return objBLL.GetFilm();
        }

        public void UpdateFilme(FilmDTO filme) 
        { 
            objBLL.Update(filme);
        }

        public void DeletaFilme(int IdFilm)
        {
            objBLL.Delete(IdFilm);
        }

        public FilmDTO BuscaId(int IdFilm)
        {
            return objBLL.Search(IdFilm);
        }

        public FilmDTO BuscaTitulo(string TituloFilm)
        {
            return objBLL.Search(TituloFilm);
        }

        public List<ClassificacaoDTO> DDLClassifica()
        {
            return objBLL.LoadDDLClassif();
        }

        public List<GeneroDTO> DDLGenero()
        {
            return objBLL.LoadDDLGenero();
        }

        public List<FilmDTO> FiltroGenero(string generoFilme)
        {
            return objBLL.Filter(generoFilme);
        }
    }
}
