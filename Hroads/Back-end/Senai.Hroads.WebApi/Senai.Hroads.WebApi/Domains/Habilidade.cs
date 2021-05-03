using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.Hroads.WebApi.Domains
{
    public partial class Habilidade
    {
        public int IdHabilidade { get; set; }
        public string Nome { get; set; }
        public int? IdTipoHabilidade { get; set; }

        public virtual TipoHabilidade IdTipoHabilidadeNavigation { get; set; }
    }
}
