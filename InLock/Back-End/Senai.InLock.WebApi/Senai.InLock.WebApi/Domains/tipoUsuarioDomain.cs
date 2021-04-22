using System.ComponentModel.DataAnnotations;

namespace Senai.InLock.WebApi.Domains
{
    public class tipoUsuarioDomain
    {
        public int idTipoUsuario { get; set; }

        [Required(ErrorMessage = "Preencha o campo titulo")]
        public string titulo { get; set; }
    }
}
