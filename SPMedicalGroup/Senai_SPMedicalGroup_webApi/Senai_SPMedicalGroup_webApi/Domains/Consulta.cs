using System;
using System.Collections.Generic;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdMedico { get; set; }
        public int? IdStatusConsulta { get; set; }
        public DateTime DataConsulta { get; set; }
        public TimeSpan HorarioConsulta { get; set; }
        public string DescricaoAtendimento { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual StatusConsulta IdStatusConsultaNavigation { get; set; }
    }
}
