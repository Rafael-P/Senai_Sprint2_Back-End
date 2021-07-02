using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Senai_SPMedicalGroup_webApi.Domains
{
    public partial class StatusConsulta
    {
        public StatusConsulta()
        {
            Consulta = new HashSet<Consulta>();
        }

        public int IdStatusConsulta { get; set; }

        [Required(ErrorMessage = "Os status da consulta devem ser preenchidos")]
        public string StatusConsulta1 { get; set; }

        public virtual ICollection<Consulta> Consulta { get; set; }
    }
}
