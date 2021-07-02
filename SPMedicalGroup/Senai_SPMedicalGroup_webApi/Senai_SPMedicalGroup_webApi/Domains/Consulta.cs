using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Consulta
    {
        public int IdConsulta { get; set; }

        [Required(ErrorMessage = "O ID do paciente deve ser informado")]
        public int? IdPaciente { get; set; }

        [Required(ErrorMessage = "O ID do medico deve ser informado")]
        public int? IdMedico { get; set; }

        [Required(ErrorMessage = "O ID dos status da consulta deve ser informado")]
        public int? IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "A data da consulta deve ser informada")]
        [DataType(DataType.Date)]
        public DateTime DataConsulta { get; set; }

        [Required(ErrorMessage = "O horario da consulta deve ser informado")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioConsulta { get; set; }

        public string DescricaoAtendimento { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual StatusConsulta IdStatusConsultaNavigation { get; set; }
    }
}
