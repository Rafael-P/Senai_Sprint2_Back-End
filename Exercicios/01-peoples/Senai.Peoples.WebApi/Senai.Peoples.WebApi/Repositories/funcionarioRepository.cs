using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repositories
{
    /// <summary>
    /// classe responsavel pelo repositorio dos generos
    /// </summary>
    public class funcionarioRepository : IFuncionarioRepository
    {
        /// <summary>
        /// Uma string que faz a conexao com o banco de dados 
        /// Data source = nome do servidor 
        /// initial catalog = nome do banco de dados 
        /// user id = sa; pwd = senha do banco de dados; -> faz a autenticação com usuario do SQL Server, passando o logon e a senha
        /// OU integrated security = true; -> faz a autenticação com o usuario do sistema (Windows nesse caso)
        /// </summary>
        private string stringConexao = "Data Source=RAFAEL; initial catalog=M_Peoples; user id=sa; pwd=1199700265Ra";
        //private string stringConexao = "Data Source=RAFAEL; initial catalog=M_Peoples; integrated security=true";

        /// <summary>
        /// Atualiza um funcionario passando seu id na URL
        /// </summary>
        /// <param name="id">id do funcionario que sera atualizado</param>
        /// <param name="funcionario">Objeto funcionario com as novas informações</param>
        public void AtualizarIdUrl(int id, funcionarioDomain funcionario)
        {
            //DECLARA a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //DECLARA a query a ser executada
                string queryUpdateUrl = "UPDATE Funcionarios SET nome = @Nome, sobrenome = @Sobrenome WHERE idFuncionario = @ID";

                //DECLARA o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    //passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", funcionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", funcionario.sobrenome);

                    //ABRE a conexao com o banco de dados 
                    con.Open();

                    //EXECUTA o comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um funcionario atraves de um id
        /// </summary>
        /// <param name="id">id do funcionario que sera buscado</param>
        /// <returns>Retorna um funcionario ou null caso não seja encontrado</returns>
        public funcionarioDomain BuscarPorId(int id)
        {
            //declara a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //DECLARA a query que sera executada
                string querySelect = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios WHERE idFuncionario = @ID";

                //abre a conexao com o banco de dados 
                con.Open();

                //DECLARA o SqlDataReader rdr para receber os valores do banco de dados 
                SqlDataReader rdr;

                //DECLARA o SqlCommand passando a query que sera executada e os parametros
                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    //passa o valor para o parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //EXECUTA a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //verifica se o resultado da query retornou algum registro
                    if (rdr.Read())
                    {
                        //se sim, instancia um novo objeto funcionarioBuscado do tipo funcionarioDomain
                        funcionarioDomain funcionarioBuscado = new funcionarioDomain
                        {
                            //atribui a propriedade idFuncionario o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr["idFuncionario"]),

                            //atribui a propriedade nome o valor da coluna "nome" da tabela do banco de dados 
                            nome = rdr["Nome"].ToString(),

                            //atribui a propriedade sobrenome o valor da coluna "sobrenome" da tabela do banco de dados 
                            sobrenome = rdr["Sobrenome"].ToString()
                        };

                        //retorna o funcionarioBuscado com os dados obtidos
                        return funcionarioBuscado;
                    }

                    //se não encontrar retorna null
                    return null;
                }
            }
        }

        /// <summary>
        /// Deleta um funcionario atraves do seu id
        /// </summary>
        /// <param name="id">id do funcionario</param>
        public void Deletar(int id)
        {
            //DECLARA a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //DECLARA a query a ser executada passando o valor como parametro
                string queryDelete = "DELETE FROM Funcionarios WHERE idFuncionario = @ID";

                //DECLARA o SqlCommand cmd passando a query que sera executada e a conexao como parametros 
                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    //Define o valor recebido no metodo como o valor do parametro @ID
                    cmd.Parameters.AddWithValue("@ID", id);

                    //Abre a conexao com o banco de dados
                    con.Open();

                    //EXECUTA a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Insere um novo funcionario no banco de dados
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario com as informações que serão inseridas</param>
        public void Inserir(funcionarioDomain novoFuncionario)
        {
            //DECLARA a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //usar @parametros em vez de concatenação para evitar efeito Joana D'Arc ou SQL Injection
                //DECLARA a query que sera executada
                string queryInsert = "INSERT INTO Funcionarios(nome, sobrenome) VALUES(@Nome, @Sobrenome)";

                //DECLARA o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    //Passa os valores para os parametros
                    cmd.Parameters.AddWithValue("@Nome", novoFuncionario.nome);
                    cmd.Parameters.AddWithValue("@Sobrenome", novoFuncionario.sobrenome);

                    //Abre a conexao com o banco de dados 
                    con.Open();

                    //EXECUTA a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os funcionarios
        /// </summary>
        /// <returns>Uma lista de funcionarios</returns>
        public List<funcionarioDomain> ListarTodos()
        {
            //Cria uma lista chamada listaFuncionario onde serao armazenados os dados
            List<funcionarioDomain> listaFuncionario = new List<funcionarioDomain>();

            //DECLARA a SqlConnection con passando a string de conexao como parametro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                //DECLARA a instrução a ser executada
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome FROM Funcionarios";

                //abre a conexao com o banco de dados 
                con.Open();

                //DECLARA o SqlDataReader rdr para percorrer a tabela do banco de dados 
                SqlDataReader rdr;

                //DECLARA o SqlCommand cmd passando a query que sera executada e a conexao como parametros
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //EXECUTA a query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    //Enquanto tem linha para ser lida no rdr o laço se repete
                    while (rdr.Read())
                    {
                        //Instancia um objeto funcionario do tipo funcionarioDomain
                        funcionarioDomain funcionario = new funcionarioDomain()
                        {
                            //Atribui a propriedade idFuncionario o valor da primeira coluna da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(rdr[0]),

                            //Atribui a propriedade nome o valor da segunda coluna da tabela do banco de dados
                            nome = rdr[1].ToString(),

                            //Atribui a propriedade sobrenome o valor da terceira coluna da tabela do banco de dados
                            sobrenome = rdr[2].ToString()
                        };

                        //ADICIONA o objeto funcionario na listaFuncionarios
                        listaFuncionario.Add(funcionario);
                    }
                }
            }

            //retorna a lista de funcionarios
            return listaFuncionario;
        }

    }
}
