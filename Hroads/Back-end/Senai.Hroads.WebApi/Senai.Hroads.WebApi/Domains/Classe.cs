using System;
using System.Collections.Generic;

#nullable disable

namespace Senai.Hroads.WebApi.Domains
{
    public partial class Classe
    {
        public Classe()
        {
            Personagems = new HashSet<Personagem>();
        }

        public int IdClasse { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Personagem> Personagems { get; set; }
    }
}
