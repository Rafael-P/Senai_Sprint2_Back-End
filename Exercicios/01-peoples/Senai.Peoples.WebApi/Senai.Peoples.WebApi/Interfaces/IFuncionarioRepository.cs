using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio FuncionarioRepository
    /// </summary>
    interface IFuncionarioRepository
    {
        //estrutura de metodo -> TipoDoRetorno NomeMetodo(TipoParametro NomeParametro);

        /// <summary>
        /// Procura e exibe todos os funcionarios
        /// </summary>
        /// <returns>Retorna uma lista de funcionarios</returns>
        List<funcionarioDomain> ListarTodos();

        /// <summary>
        /// Busca um genero pelo id e mostra
        /// </summary>
        /// <param name="id">id do funcionario buscado</param>
        /// <returns>Retorna um objeto do tipo funcionarioDomain que foi buscado</returns>
        funcionarioDomain BuscarPorId(int id);

        /// <summary>
        /// Deleta um funcionario pelo seu id
        /// </summary>
        /// <param name="id">id do funcionario</param>
        void Deletar(int id);

        /// <summary>
        /// Atualiza um funcionario existente passando o seu id pela url
        /// </summary>
        /// <param name="id">id do funcionario que sera atualizado</param>
        /// <param name="funcionario">Objeto funcionario que vai receber as novas informações</param>
        void AtualizarIdUrl(int id, funcionarioDomain funcionario);

        /// <summary>
        /// Insere um novo funcionario
        /// </summary>
        /// <param name="novoFuncionario">Objeto novoFuncionario que vai ser inserido</param>
        void Inserir(funcionarioDomain novoFuncionario);
    }
}
