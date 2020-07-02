using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globaltec.Models;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using Globaltec.Data;
using Microsoft.EntityFrameworkCore;

namespace Globaltec.Controllers
{
    [ApiController]
    [Route("v1/globaltec/pessoa")]
    public class PessoaController : ControllerBase
    {
        
        //Cadastro de novo usuário
        //Tanto Jedi quanto Padawan podem realizar, desde que autenticados
        [HttpPost]
        [Route ("")]
        [Authorize(Roles = "Jedi,Padawan")]
        public async Task<ActionResult<Pessoa>> Post([FromServices] DataContext context,
                                                     [FromBody] Pessoa model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            context.Pessoas.Add(model);
            await context.SaveChangesAsync();
            return model;
            
        }

        //Consulta geral pessoas
        [HttpGet]
        [Route("")]
        [Authorize(Roles = "Jedi,Padawan")]
        public async Task<ActionResult<List<Pessoa>>> Get([FromServices] DataContext context)
        {
            var pessoas = await context.Pessoas.ToListAsync();
            return pessoas;
        }

        //Consulta pelo codigo
        [HttpGet]
        [Route("codigo/{codigo:int}")]
        [Authorize(Roles = "Jedi,Padawan")]
        public async Task<ActionResult<List<Pessoa>>> GetByCodigo([FromServices] DataContext context, int codigo)
        {
            var pessoas = await context.Pessoas
                .AsNoTracking()
                .Where(x => x.Codigo == codigo)
                .ToListAsync();

            return pessoas;
        }

        //Consulta pelo codigo
        [HttpGet]
        [Route("uf/{uf}")]
        [Authorize(Roles = "Jedi,Padawan")]
        public async Task<ActionResult<List<Pessoa>>> GetByCodigo([FromServices] DataContext context, string uf)
        {
            var pessoas = await context.Pessoas
                .AsNoTracking()
                .Where(x => x.UF == uf)
                .ToListAsync();

            return pessoas;
        }

        //Exige atualizar todos os campos, com exceção do codigo
        [HttpPost]
        [Route("update/{codigo:int}")]
        [Authorize(Roles = "Jedi,Padawan")]
        public async Task<ActionResult<Pessoa>> Update(
            [FromServices] DataContext context,
            [FromBody]Pessoa model,
            int codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var cUpdate = context.Pessoas.First(a => a.Codigo == codigo);
                cUpdate.Nome = model.Nome;
                cUpdate.CPF = model.CPF;
                cUpdate.UF = model.UF;
                cUpdate.DataNascimento = model.DataNascimento;
                await context.SaveChangesAsync();
                return cUpdate;
            
        }

        //Apaga registro pelo codigo
        //Somente user Jedi pode apagar
        [HttpPost]
        [ProducesDefaultResponseType]
        [Route("delete/{codigo:int}")]
        [Authorize(Roles = "Jedi")]
        public async Task<ActionResult<Pessoa>> Delete(
            [FromServices] DataContext context,
            int codigo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            context.Remove(context.Pessoas.First(a => a.Codigo == codigo));
            await context.SaveChangesAsync();
            return Ok("{'status':200, 'message': 'Registro apagado com sucesso'}");
        }
    }
}