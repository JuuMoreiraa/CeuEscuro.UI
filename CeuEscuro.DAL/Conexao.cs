using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeuEscuro.DAL
{
    public class Conexao
    {
        //Campos de apoio
        protected SqlConnection conn; //Conectar
        protected SqlCommand cmd; //Mandar alguns comandos
        protected SqlDataReader dr; //Ler

        //Métodos
        protected void Conectar()
        {
            try
            {
                conn = new SqlConnection(@"Data source = (localdb)\MSSQLLocalDB; Initial Catalog = CeuEscuroDB; Integrated Security = true;");
                conn.Open();
            }
            catch (Exception ex)
            {

                throw new Exception($"Problema ao conectar {ex.Message}");
            }
        }

        protected void Desconectar()
        {
            try
            {
                conn.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
