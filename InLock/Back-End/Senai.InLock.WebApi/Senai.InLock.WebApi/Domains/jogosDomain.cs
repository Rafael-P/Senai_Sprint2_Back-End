using System;
using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade jogos
    /// </summary>
    public class jogosDomain 
    {
        public int idJogos { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatório")]
        public string nome { get; set; }

        public string descricao { get; set; }

        [DataType(DataType.Date)]
        public DateTime dataLancamento { get; set; }

        [Required(ErrorMessage = "O valor do jogo deve ser preenchido")]
        public int valor { get; set; }

        public int idEstudio { get; set; }
    }
}
