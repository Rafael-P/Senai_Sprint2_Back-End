using Senai_SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio TiposUsuarioRepository
    /// </summary>
    interface ITiposUsuarioRepository
    {
        // Definição de metodos, seguem essa estrutura:
        // tipoRetorno nomeMetodo(tipoParametro nomeParametro); um metodo não precisa de um parametro para funcionar

        /// <summary>
        /// Lista todos os tipos de usuarios
        /// </summary>
        /// <returns>Retorna uma lista de tipos de usuarios</returns>
        List<TiposUsuario> ListarTodos();

        /// <summary>
        /// Buscar um usuario pelo id
        /// </summary>
        /// <param name="id">id do tipo usuario</param>
        /// <returns>retorna um objeto do tipo TiposUsuario</returns>
        TiposUsuario BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="novoTipoUsuario">Objeto novoTiposUsuario que será cadastrado</param>
        void Cadastrar(TiposUsuario novoTipoUsuario);

        /// <summary>
        /// Atualiza um tipo de usuario existente
        /// </summary>
        /// <param name="id">id do tipo de usuario</param>
        /// <param name="tipoUsuarioAtualizado">objeto atualizado</param>
        void Atualizar(int id, TiposUsuario tipoUsuarioAtualizado);

        /// <summary>
        /// Deleta um tipo de usuario existente
        /// </summary>
        /// <param name="id">id do tipo usuario</param>
        void Deletar(int id);
    }
}
