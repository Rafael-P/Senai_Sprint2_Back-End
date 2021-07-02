using Microsoft.EntityFrameworkCore;
using Senai_SPMedicalGroup_webApi.Contexts;
using Senai_SPMedicalGroup_webApi.Domains;
using Senai_SPMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        MedicalContext ctx = new MedicalContext();

        /// <summary>
        /// Atualiza um usuario que já existe
        /// </summary>
        /// <param name="id">id do usuario</param>
        /// <param name="usuarioAtualizado">Objeto do tipo usuarioAtualizado com as novas informações</param>
        public void Atualizar(int id, Usuario usuarioAtualizado)
        {
            //Busca um usuario através do id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Verifica se o id do usuário foi informado
            if (usuarioBuscado.IdTipoUsuario != null)
            {
                //Atribui os novos valores ao campo existente
                usuarioBuscado.IdTipoUsuario = usuarioAtualizado.IdTipoUsuario;
            }

            //Atualiza o usuarioBuscado
            ctx.Usuarios.Update(usuarioBuscado);

            //Salva as informações no banco 
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um usuario pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario BuscarPorId(int id)
        {
            //Retorna o usuario que foi encontrado com esse id
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Cadastra um novo usuario
        /// </summary>
        /// <param name="novoUsuario">Objeto do tipo novoUsuario que sera cadastrado</param>
        public void Cadastrar(Usuario novoUsuario)
        {
            //Adiciona o novoUsuario
            ctx.Usuarios.Add(novoUsuario);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um usuario pelo seu id
        /// </summary>
        /// <param name="id">id do usuario</param>
        public void Deletar(int id)
        {
            //Busca um usuario pelo id
            Usuario usuarioBuscado = ctx.Usuarios.Find(id);

            //Remove o usuario que foi buscado
            ctx.Usuarios.Remove(usuarioBuscado);

            //Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os usuarios
        /// </summary>
        /// <returns>Uma lista de usuarios</returns>
        public List<Usuario> Listar()
        {
            return ctx.Usuarios.ToList();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="email">e-mail do usuário</param>
        /// <param name="senha">senha do usuário</param>
        /// <returns>Um objeto do tipo Usuario que foi buscado</returns>
        public Usuario Login(string email, string senha)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }
    }
}
