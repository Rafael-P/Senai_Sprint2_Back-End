using Senai_SPMedicalGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_SPMedicalGroup_webApi.Interfaces
{
    interface IStatusConsultaRepository
    {
        List<StatusConsulta> Listar();

        StatusConsulta BuscarPorId(int id);

        void Cadastrar(StatusConsulta novoStatusConsulta);

        void Atualizar(int id, StatusConsulta consultaAtualizada);

        void Deletar(int id);
    }
}
