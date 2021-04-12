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
        
        /// <summary>
        /// atualiza um genero passando o id pelo corpo
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informações</param>
        public void AtualizarIdCorpo(generoDomain genero)
        {
            //declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query a ser executada
                string queryUpdateIdBody = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryUpdateIdBody, con))
                {
                    //passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);
                    cmd.Parameters.AddWithValue("@ID", genero.idGenero);

                    //abre a conexao com o banco de dados 
                    con.Open();

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        } 

        /// <summary>
        /// atualiza um genero passando o id pelo recurso (URL)
        /// </summary>
        /// <param name="id">id do genero que sera atualizado</param>
        /// <param name="genero">objeto genero com as novas informaçoes</param>
        public void AtualizarIdUrl(int id, generoDomain genero)
        {
            //declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query a ser executada
                string queryUpdateUrl = "UPDATE Generos SET Nome = @Nome WHERE idGenero = @ID";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", genero.nome);

                    //abre a conexao com o banco de dados 
                    con.Open();

                    //executa o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um genero atraves de um id
        /// </summary>
        /// <param name="id">id do genero que sera listado</param>
        /// <returns>o genero buscado ou null caso nao seja encontrado</returns>
        public generoDomain BuscarPorId(int id)
        {
            //declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query a ser executada
                string querySelectById = "SELECT idGenero, Nome FROM Generos WHERE idGnero = @ID";

                //abre conexao com o banco de dados 
                con.Open();

                //declara o SqlDataReader rdr para receber os valores do banco de dados 
                SqlDataReader rdr;

                //declara o SqlCommand passando a query que sera executada e os parametros 
                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    //passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //executa a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto generoBuscado do tipo generoDomain
                        generoDomain generoBuscado = new generoDomain
                        {
                            //atribui à propriedade idGenero o valor da coluna "idGenero" da tabela do banco de dados
                            idGenero = Convert.ToInt32(rdr["idGenero"]),

                            //atribui a propriedade nome o valor da coluna "Nome" da tabela do banco de dados 
                            nome = rdr["Nome"].ToString()
                        };

                        //retorna o generoBuscado com os dados obtidos
                        return generoBuscado;
                    }

                    //se nao encontrar retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">objeto novoGenero com as informações que serao cadastradas</param>
        public void Cadastrar(generoDomain novoGenero)
        {
            //declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //Declara a query que sera executada
                                  //EX: INSERT INTO Generos(Nome) VALUES('Aventura')
                                  //EX: INSERT INTO Generos(Nome) VALUES('Joana D'Arc'); daria errado
                                  //EX: INSERT INTO Generos(Nome) VALUES('')DROP TABLE Filmes--'); *SQL Injection*
                //string queryInsert = "INSERT INTO Generos(Nome) VALUES('" + novoGenero.nome + "')";
                //Não usar dessa forma pois pode causar o efeito Joana D'Arc
                //Alem de permitir SQL Injection
                //Por exemplo
                //"nome" : "')DROP TABLE Filmes--"
                //Ao tentar cadastrar o comando acima, irá deletar a tabela Filmes do banco de dados

                //Declara a query que sera executada
                string queryInsert = "INSERT INTO Generos(Nome) VALUES(@Nome)";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //passa o valor para o parametro @Nome
                    cmd.Parameters.AddWithValue("@Nome", novoGenero.nome);

                    //abre a conexao com o banco de dados
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um genero atraves do seu id
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        public void Deletar(int id)
        {
            //declara a SqlConnection con passando a string de conexao como parametro 
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //declara a query a ser executa passando o valor commo parametro
                string queryDelete = "DELETE FROM Generos WHERE idGenero = @ID";

                //declara o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //define o valor recebido no metodo como o valor do parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //abre a conexao com o banco de dados 
                    con.Open();

                    //executa a query
                    cmd.ExecuteNonQuery();
                }
            }
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
