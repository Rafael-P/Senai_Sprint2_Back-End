using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade estudio
    /// </summary>
    public class estudiosDomain
    {
        public int idEstudio { get; set; }

        [Required(ErrorMessage = "O nome do estudio é obrigatório!")]
        public string nomeEstudio { get; set; }
    }
}
