using senai_filmes_webApi.Domains;
using senai_filmes_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webApi.Repositories
{
    /// <summary>
    /// Classe responsavel pelo repositorio dos generos 
    /// </summary>
    public class generoRepository : IGeneroRepository
    {
        /// <summary>
        /// String de conexao com o banco de dados que recebe os parametros
        /// Data source = nome do servidor 
        /// initial catalog = nome do banco de dados 
        /// user id=sa; pwd=1199700265Ra;  =  faz a autenticaçao com o usuario do SQL Server, passando o logon e a senha
        /// OU integrated security=true;  =  faz a autenticaçao com o usuario do sistema (Windows)
        /// </summary>
        private string stringConexao = "Data Source=RAFAEL; initial catalog=Filmes; user id=sa; pwd=1199700265Ra";
        //private string stringConexao = "Data Source=RAFAEL; initial catalog=Filmes; integrated security=true";
        public void AtualizarIdCorpo(generoDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, generoDomain genero)
        {
            throw new NotImplementedException();
        }

        public generoDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(generoDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todos os generos 
        /// </summary>
        /// <returns>uma lista de generos</returns>
        public List<generoDomain> ListarTodos()
        {
            //cria uma lista chamada listaGeneros onde serao armazenados os dados
            List<generoDomain> listaGeneros = new List<generoDomain>();

            // declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a instrucçao a ser executada
                string querySelectAll = "SELECT idGenero, Nome FROM Generos";

                //abre a conexao com o banco de dados 
                con.Open();

                //declara o SqlDataReader rdr para percorrer a tabela do banco de dados
                SqlDataReader rdr;

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //enquanto houver registros para serem lidos no rdr, o laço se repete
                    while (rdr.Read())
                    {
                        //instancia um objeto genero do tipo generoDomain
                        generoDomain genero = new generoDomain()
                        {
                            //atribui a propriedade idGenero o valor da primeira coluna da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr[0]),
                            //atribui a propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString()
                        };

                        //adiciona o objeto genero a lista listaGeneros
                        listaGeneros.Add(genero);
                    }
                }
            }

            //retorna a lista de generos 
            return listaGeneros;
        } 
    }
}
