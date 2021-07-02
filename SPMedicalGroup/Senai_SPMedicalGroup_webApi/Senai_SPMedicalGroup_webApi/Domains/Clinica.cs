using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Clinica
    {
        public Clinica()
        {
            Medicos = new HashSet<Medico>();
        }

        public int IdClinica { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioAbertura { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        [DataType(DataType.Time)]
        public TimeSpan HorarioFechamento { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string Site { get; set; }

        [Required(ErrorMessage = "Este campo deve ser preenchido")]
        public string Cnpj { get; set; }

        public virtual ICollection<Medico> Medicos { get; set; }
    }
}
