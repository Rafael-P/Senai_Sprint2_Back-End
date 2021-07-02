using Senai_SPMedicalGroup_webApi.Contexts;
using Senai_SPMedicalGroup_webApi.Domains;
using Senai_SPMedicalGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Repositories
{
    public class StatusConsultaRepository : IStatusConsultaRepository
    {
        MedicalContext ctx = new MedicalContext();

        public void Atualizar(int id, StatusConsulta consultaAtualizada)
        {
            StatusConsulta consultaBuscada = ctx.StatusConsultas.Find(id);

            if (consultaAtualizada.StatusConsulta1 != null)
            {
                consultaBuscada.StatusConsulta1 = consultaAtualizada.StatusConsulta1;
            }

            ctx.StatusConsultas.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public StatusConsulta BuscarPorId(int id)
        {
            return ctx.StatusConsultas.FirstOrDefault(sc => sc.IdStatusConsulta == id);
        }

        public void Cadastrar(StatusConsulta novoStatusConsulta)
        {
            ctx.StatusConsultas.Add(novoStatusConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            StatusConsulta statusConsultaBuscado = ctx.StatusConsultas.Find(id);

            ctx.StatusConsultas.Remove(statusConsultaBuscado);

            ctx.SaveChanges();
        }

        public List<StatusConsulta> Listar()
        {
            return ctx.StatusConsultas.ToList();
        }
    }
}
