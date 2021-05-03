using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.Hroads.WebApi.Domains
{
    public partial class TipoHabilidade
    {
        public TipoHabilidade()
        {
            Habilidades = new HashSet<Habilidade>();
        }

        public int IdTipoHabilidade { get; set; }
        public string Tipo { get; set; }

        public virtual ICollection<Habilidade> Habilidades { get; set; }
    }
}
