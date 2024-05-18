using CeuEscuro.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CeuEscuro.DAL
{
    public class FilmDAL : Conexao
    {
        //    CRUD    //
        //    Create
        public void Create(FilmDTO filme)
        {
            try
            {
                Conectar();
                // CTRL + W + E = Quebra de linha
                //Query para adicionar novos usuários. Comando feito para executar no BD via C#
                cmd = new SqlCommand("INSERT INTO Film(TituloFilm,ProdutoraFilm,UrlImgFilm, Classifcacao_Id,Genero_Id) VALUES (@TituloFilm,@ProdutoraFilm,@UrlImgFilm,@Classifcacao_Id,@Genero_Id);", conn);
                //Preenche os campos do banco de dados com os respectivos dados
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classifcacao_Id", filme.Classifcacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                //Comando para executar a query
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //    Read
        public List<FilmDTO> GetFilm()
        {
            try
            {
                Conectar();
                //Inner Join = Trazer dados em comum entre tabelas interligadas
                cmd = new SqlCommand("SELECT IdFilm, TituloFilm, ProdutoraFilm, UrlImgFilm, DescricaoClassificacao, DescricaoGenero FROM Film INNER JOIN Classificacao ON Classifcacao_Id = IdCLassificacao INNER JOIN Genero ON Genero_Id = IdGenero;", conn);
                //dr = Lê os dados que o cmd pegou e armazena
                dr = cmd.ExecuteReader();
                List<FilmDTO> Lista = new List<FilmDTO>(); //Lista Vazia para receber os dados
                while (dr.Read())
                {
                    FilmDTO film = new FilmDTO();
                    film.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                    film.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    film.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    film.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    film.Classifcacao_Id = Convert.ToString(dr["DescricaoClassificacao"]);
                    film.Genero_Id = Convert.ToString(dr["DescricaoGenero"]);
                    Lista.Add(film);
                }
                return Lista;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //    Update
        public void Update(FilmDTO filme)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Film SET TituloFilm = @TituloFilm, ProdutoraFilm = @ProdutoraFilm, UrlImgFilm = @UrlImgFilm, Classifcacao_Id = @Classifcacao_Id, Genero_Id = @Genero_Id WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", filme.TituloFilm);
                cmd.Parameters.AddWithValue("@ProdutoraFilm", filme.ProdutoraFilm);
                cmd.Parameters.AddWithValue("@UrlImgFilm", filme.UrlImgFilm);
                cmd.Parameters.AddWithValue("@Classifcacao_Id", filme.Classifcacao_Id);
                cmd.Parameters.AddWithValue("@Genero_Id", filme.Genero_Id);
                cmd.Parameters.AddWithValue("@IdFilm", filme.IdFilm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //    Delete
        public void Delete(int IdFilm)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", IdFilm);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }


        //    Search by Id
        public FilmDTO Search(int IdFilm)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE IdFilm = @IdFilm;", conn);
                cmd.Parameters.AddWithValue("@IdFilm", IdFilm);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO(); //Cria um obj vazio
                if (dr.Read()) //Sempre quando for select tem que verificar se o comando leu
                {
                    filme = new FilmDTO();
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classifcacao_Id = Convert.ToString(dr["Classifcacao_Id"]);
                    filme.Genero_Id = Convert.ToString(dr["Genero_Id"]);
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                }
                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }

        //    Search by Name
        public FilmDTO Search(string TituloFilm)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Film WHERE TituloFilm LIKE '%@TituloFilm%';", conn);
                cmd.Parameters.AddWithValue("@TituloFilm", TituloFilm);
                dr = cmd.ExecuteReader();
                FilmDTO filme = new FilmDTO(); //Cria um obj vazio
                if (dr.Read()) //Sempre quando for select tem que verificar se o comando leu
                {
                    filme = new FilmDTO();
                    filme.TituloFilm = Convert.ToString(dr["TituloFilm"]);
                    filme.ProdutoraFilm = Convert.ToString(dr["ProdutoraFilm"]);
                    filme.UrlImgFilm = Convert.ToString(dr["UrlImgFilm"]);
                    filme.Classifcacao_Id = Convert.ToString(dr["Classifcacao_Id"]);
                    filme.Genero_Id = Convert.ToString(dr["Genero_Id"]);
                    filme.IdFilm = Convert.ToInt32(dr["IdFilm"]);
                }
                return filme;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}
