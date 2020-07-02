using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globaltec.Models;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Globaltec.Services;
using Globaltec.Repositories;
using Globaltec.Data;
using Microsoft.EntityFrameworkCore;

namespace Globaltec.Controllers
{
    [ApiController]
    [Route("v1/globaltec/auth")]
    public class AuthController : ControllerBase
    {
        //Recebe token mediante validação de usuário e senha
        //Usuário cadastrado em UserRepository.cs
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]User model)
        {
            var user = UserRepository.Get(model.Username, model.Password);
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos"});

            var token = TokenService.GenerateToken(user);
            user.Password = "";
            return new
            {
                user = user,
                token = token
            };
        }

        //Retorna para o usuário se ele está autenticado ou não
        //Token expira com 2h
        [HttpGet]
        [Route("login")]
        [Authorize]
        public string Authenticated() => String.Format("Autenticado - Usuário: {0} ", User.Identity.Name);

    }
}