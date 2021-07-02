using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Medicos = new HashSet<Medico>();
            Pacientes = new HashSet<Paciente>();
        }

        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "O tipo de usuario é obrigatório")]
        public int? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo email deve ser preenchido")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Você precisa cadastrar a senha")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve conter no minimo 3 caracteres")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Medico> Medicos { get; set; }
        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
