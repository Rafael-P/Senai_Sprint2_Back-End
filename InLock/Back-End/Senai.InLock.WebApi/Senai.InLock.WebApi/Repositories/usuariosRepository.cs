using Senai.InLock.WebApi.Domains;
using Senai.InLock.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Senai.InLock.WebApi.Repositories
{
    public class usuariosRepository : IUsuarioRepositories
    {
        private string stringConexao = "Data Source=RAFAEL; initial catalog=inlock_games_manha; user id=sa; pwd=1199700265Ra";

        public usuariosDomain BuscarPorEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = "SELECT idUsuario, email, senha, idTipoUsuario FROM Usuarios WHERE email = @email AND senha = @senha;";

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        usuariosDomain usuarioBuscado = new usuariosDomain
                        {
                            idUsuario       = Convert.ToInt32(rdr["idUsuario"]),
                            email           = rdr["email"].ToString(),
                            senha           = rdr["senha"].ToString(),
                            idTipoUsuario   = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }


    }
}
