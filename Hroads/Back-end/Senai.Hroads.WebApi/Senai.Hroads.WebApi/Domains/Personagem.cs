using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.Hroads.WebApi.Domains
{
    public partial class Personagem
    {
        public int IdPersonagem { get; set; }
        public string Nome { get; set; }
        public string Classe { get; set; }
        public int? IdClasse { get; set; }
        public byte? VidaMax { get; set; }
        public byte? ManaMax { get; set; }
        public string DataDeAtualizacao { get; set; }
        public string DataDeCriacao { get; set; }

        public virtual Classe IdClasseNavigation { get; set; }
    }
}
