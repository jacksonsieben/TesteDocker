using Microsoft.AspNetCore.Mvc;
using teste.API.Data;
using teste.API.Models;
using Microsoft.Extensions.Logging;

namespace teste.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
       [HttpGet]
       [Route("/Pessoa")]
       public IActionResult Get(
            [FromServices] AppDbContext context) =>
                Ok(context.Pessoas!.ToList());
        
        [HttpGet("/Pessoa/Details/{id:int}")]
        public IActionResult GetById([FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var pessoaModel = context.Pessoas!.FirstOrDefault(x => x.Id == id);
            if(pessoaModel == null){
                return NotFound();
            }
            return Ok(pessoaModel);
        }

        [HttpPost("/Pessoa/Create")]
        public IActionResult Post([FromBody] PessoaModel pessoaModel,
            [FromServices] AppDbContext context)
        {
            context.Pessoas!.Add(pessoaModel);
            context.SaveChanges();
            return Created($"/{pessoaModel.Id}", pessoaModel);
        }

        [HttpPut("/Pessoa/Edit/{id:int}")]
        public IActionResult Put([FromRoute] int id,
            [FromBody] PessoaModel pessoaModel,
            [FromServices] AppDbContext context)
        {
            var model = context.Pessoas!.FirstOrDefault(x => x.Id == id);
            if(model == null){
                return NotFound();
            }

            model.Nome = pessoaModel.Nome;
            model.Sobrenome = pessoaModel.Sobrenome;

            
            context.Pessoas!.Update(model);
            context.SaveChanges();
            return Ok(model);
        }

        [HttpDelete("/Pessoa/Delete/{id:int}")]
        public IActionResult Delete([FromRoute] int id,
            [FromServices] AppDbContext context)
        {
            var model = context.Pessoas!.FirstOrDefault(x => x.Id == id);
            if(model == null){
                return NotFound();
            }

            context.Pessoas!.Remove(model);
            context.SaveChanges();
            return Ok(model);
        }
    }
}