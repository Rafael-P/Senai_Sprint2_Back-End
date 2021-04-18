using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.InLock.WebApi.Interfaces;
using Senai.InLock.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.InLock.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class jogosController : ControllerBase
    {
        private IJogosRepositories _jogosRepository { get; set; }

        public jogosController()
        {
            _jogosRepository = new jogosRepository();
        }



    }
}
