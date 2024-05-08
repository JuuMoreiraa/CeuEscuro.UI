using CeuEscuro.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CeuEscuro.DAL
{
    public class UsuarioDAL : Conexao
    {
        //    Autenticar
        public UsuarioDTO Autenticar(string nome, string senha)
        {
            //Estrutura de tratamento de erros 
            //Tentar fazer alguma coisa "no BD"
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario AND SenhaUsuario = @SenhaUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", nome);
                cmd.Parameters.AddWithValue("@SenhaUsuario", senha);
                //  Datareader guarda o retorno do banco
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = null;
                if (dr.Read()) 
                {
                    usuario = new UsuarioDTO();
                    usuario.NomeUsuario = dr["NomeUsuario"].ToString();
                    usuario.SenhaUsuario = dr["SenhaUsuario"].ToString();
                    usuario.TipoUsuario_Id = dr["TipoUsuario_Id"].ToString();
                }
                return usuario;
            }
            //Trás a exceção caso não dê certo (erro)
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //Sempre vai ser executado mesmo se der certo ou errado
            finally 
            {
                Desconectar();
            }
            
        }

        //    CRUD    //
        //    Create
        public void Create(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                // CTRL + W + E = Quebra de linha
                //Query para adicionar novos usuários. Comando feito para executar no BD via C#
                cmd = new SqlCommand("INSERT INTO Usuario (NomeUsuario,EmailUsuario,SenhaUsuario,DtNascUsuario,TipoUsuario_Id) VALUES (@NomeUsuario,@EmailUsuario,@SenhaUsuario,@DtNascUsuario,@TipoUsuario_Id);", conn);
                //Preenche os campos do banco de dados com os respectivos dados
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
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
        public List<UsuarioDTO> GetUsers()
        {
            try
            {
                Conectar();
                //Inner Join = Trazer dados em comum entre tabelas interligadas
                cmd = new SqlCommand("SELECT IdUsuario, NomeUsuario, EmailUsuario, SenhaUsuario, DtNascUsuario, DescricaoTipoUsuario FROM Usuario INNER JOIN TipoUsuario ON TipoUsuario_Id = IdTipoUsuario;", conn);
                //dr = Lê os dados que o cmd pegou e armazena
                dr = cmd.ExecuteReader();
                List<UsuarioDTO> Lista = new List<UsuarioDTO>(); //Lista Vazia para receber os dados
                while (dr.Read()) 
                {
                    UsuarioDTO usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["DescricaoTipoUsuario"]);
                    Lista.Add(usuario);
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
        //Atualiza um usuário que já existe
        public void Update(UsuarioDTO usuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("UPDATE Usuario SET NomeUsuario = @NomeUsuario, EmailUsuario = @EmailUsuario, SenhaUsuario = @SenhaUsuario, DtNascUsuario = @DtNascUsuario, TipoUsuario_Id = @TipoUsuario_Id WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuario.NomeUsuario);
                cmd.Parameters.AddWithValue("@EmailUsuario", usuario.EmailUsuario);
                cmd.Parameters.AddWithValue("@SenhaUsuario", usuario.SenhaUsuario);
                cmd.Parameters.AddWithValue("@DtNascUsuario", usuario.DtNascUsuario);
                cmd.Parameters.AddWithValue("@TipoUsuario_Id", usuario.TipoUsuario_Id);
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
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
        public void Delete(int idUsuario)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
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
        public UsuarioDTO Search(int usuarioId) 
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE IdUsuario = @IdUsuario;", conn);
                cmd.Parameters.AddWithValue("@IdUsuario", usuarioId);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO(); //Cria um obj vazio
                if (dr.Read()) //Sempre quando for select tem que verificar se o comando leu
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["DescricaoTipoUsuario"]);
                }
                return usuario;
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
        public UsuarioDTO Search(string usuarioName)
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM Usuario WHERE NomeUsuario = @NomeUsuario;", conn);
                cmd.Parameters.AddWithValue("@NomeUsuario", usuarioName);
                dr = cmd.ExecuteReader();
                UsuarioDTO usuario = new UsuarioDTO(); //Cria um obj vazio
                if (dr.Read()) //Sempre quando for select tem que verificar se o comando leu
                {
                    usuario = new UsuarioDTO();
                    usuario.IdUsuario = Convert.ToInt32(dr["IdUsuario"]);
                    usuario.NomeUsuario = Convert.ToString(dr["NomeUsuario"]);
                    usuario.EmailUsuario = Convert.ToString(dr["EmailUsuario"]);
                    usuario.SenhaUsuario = Convert.ToString(dr["SenhaUsuario"]);
                    usuario.DtNascUsuario = Convert.ToDateTime(dr["DtNascUsuario"]);
                    usuario.TipoUsuario_Id = Convert.ToString(dr["DescricaoTipoUsuario"]);
                }
                return usuario;
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

        //    Load DropdownList
        public List<TipoUsuarioDTO> LoadDropList()  
        {
            try
            {
                Conectar();
                cmd = new SqlCommand("SELECT * FROM TipoUsuario;", conn);
                dr = cmd.ExecuteReader();
                List<TipoUsuarioDTO> Lista = new List<TipoUsuarioDTO>(); //Lista Vazia para receber os dados
                while (dr.Read())
                {
                    TipoUsuarioDTO tipoUsuario = new TipoUsuarioDTO();
                    tipoUsuario.IdTipoUsuario = Convert.ToInt32(dr["IdTipoUsuario"]);
                    tipoUsuario.DescricaoTipoUsuario = Convert.ToString(dr["DescricaoTipoUsuario"]);
                    Lista.Add(tipoUsuario);
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
    }
}
