using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade usuario
    /// </summary>
    public class usuariosDomain
    {
        public int idUsuario { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public int idTipoUsuario { get; set; }
    }
}
