using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Paciente
    {
        public Paciente()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdPaciente { get; set; }

        [Required(ErrorMessage = "Preencha este campo")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "O nome do paciente é obridatório")]
        public string NomePaciente { get; set; }

        [Required(ErrorMessage = "O campo RG deve ser preenchido")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "O RG deve conter 9 digítos")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "O CPF deve ser preenchido")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "O CPF deve conter 11 digítos")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "A data de nascimento deve ser preenchida")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Um número de telefone deve ser fornecido para contato")]
        [StringLength(10, MinimumLength = 8, ErrorMessage = "O número deve conter no minimo 8 digítos")]
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
