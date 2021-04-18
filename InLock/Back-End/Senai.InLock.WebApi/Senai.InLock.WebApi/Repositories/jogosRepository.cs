using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Repositories
{
    public class jogosRepository : IJogosRepositories
    {
        private string stringConexao = "Data Source=RAFAEL; initial catalog=inlock_games_manha; user id=sa; pwd=1199700265Ra";

        public void AtualizarIdUrl(int id, jogosDomain jogos)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdate = "UPDATE Jogos SET nomeJogos = @Nome, descricao = @Desc, dataLancamento = @Data, valor = @Valor, idEstudio = @Estudio WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Nome", jogos.nome);
                    cmd.Parameters.AddWithValue("@Desc", jogos.descricao);
                    cmd.Parameters.AddWithValue("@Data", jogos.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", jogos.valor);
                    cmd.Parameters.AddWithValue("@Estudio", jogos.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public jogosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT * FROM Jogos WHERE idJogo = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        jogosDomain jogoBuscado = new jogosDomain
                        {
                            idJogos = Convert.ToInt32(rdr["idJogo"]),
                            nome = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = rdr["dataLancamento"].ToString(),
                            valor = Convert.ToInt32(rdr["dataLancamento"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        return jogoBuscado;
                    }

                    return null;
                }
            }
        }

        public void Cadastrar(jogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryCadastrar = "INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES(@Nome, @Desc, @Data, @Valor, @IdEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryCadastrar, con))
                {
                    cmd.Parameters.AddWithValue("@Nome", novoJogo.nome);
                    cmd.Parameters.AddWithValue("@Desc", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@Data", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@Valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Jogos WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryDelete))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<jogosDomain> ListarTodos()
        {
            List<jogosDomain> listaJogos = new List<jogosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        jogosDomain jogos = new jogosDomain()
                        {
                            idJogos = Convert.ToInt32(rdr["idJogo"]),
                            nome = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = rdr["dataLancamento"].ToString(),
                            valor = Convert.ToInt32(rdr["dataLancamento"]),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"])
                        };

                        listaJogos.Add(jogos);
                    }
                }
            }
            return listaJogos;
        }

    }
}
