using Senai_SPMedicalGroup_webApi.Contexts;
using Senai_SPMedicalGroup_webApi.Domains;
using Senai_SPMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, Consulta consultaAtualizada)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            if (consultaAtualizada.DescricaoAtendimento != null)
            {
                consultaBuscada.DescricaoAtendimento = consultaAtualizada.DescricaoAtendimento;
            }

            ctx.Consultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consultas.FirstOrDefault(c => c.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {
            ctx.Consultas.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consultas.Find(id);

            ctx.Consultas.Remove(consultaBuscada);
        }

        public List<Consulta> Listar()
        {
            return ctx.Consultas.ToList();
        }
    }
}
