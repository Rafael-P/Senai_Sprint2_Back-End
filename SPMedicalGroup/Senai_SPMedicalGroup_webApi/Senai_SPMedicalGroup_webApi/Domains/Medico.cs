using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class Medico
    {
        public Medico()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdMedico { get; set; }

        [Required(ErrorMessage = "O ID de usuario deve ser fornecido")]
        public int? IdUsuario { get; set; }

        [Required(ErrorMessage = "O ID da clinica deve ser fornecido")]
        public int? IdClinica { get; set; }

        [Required(ErrorMessage = "O ID da especialidade deve ser fornecido")]
        public int? IdEspecialidade { get; set; }

        [Required(ErrorMessage = "O nome deve ser preenchido")]
        public string NomeMedico { get; set; }

        [Required(ErrorMessage = "O CRM deve ser fornecido")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "O CRM deve conter 6 digitos")]
        public string Crm { get; set; }

        public virtual Clinica IdClinicaNavigation { get; set; }
        public virtual Especialidade IdEspecialidadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
