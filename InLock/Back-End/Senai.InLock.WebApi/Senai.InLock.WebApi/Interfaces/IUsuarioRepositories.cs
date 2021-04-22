using Senai.InLock.WebApi.Domains;

namespace Senai.InLock.WebApi.Interfaces
{
    interface IUsuarioRepositories
    {
        usuariosDomain BuscarPorEmailSenha(string email, string senha);
    }
}