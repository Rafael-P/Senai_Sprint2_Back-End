using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade jogos
    /// </summary>
    public class jogosDomain
    {
        public int idJogos { get; set; }
        public string nome { get; set; }
        public string descricao { get; set; }
        public string dataLancamento { get; set; }
        public int valor { get; set; }
        public int idEstudio { get; set; }
    }
}
