using EFcore.Dominio;
using EFcore.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;  

        public ValuesController(HeroiContext context)
        {
            _context = context; 
        }
        // GET: api/<ValuesController>
        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            /* outras formas
             * visualizar a lista 
             * 
             * var listHeroi = (from heroi in _context.Herois
                                   select heroi).ToList();
             *var listHeroi = (from Heroi in _context.Herois
                             where Heroi.Nome.Contains(nome)
                             select Heroi).ToList();

            */
            var listHeroi = _context.Herois
                            .Where(h => h.Nome.Contains(nome))
                            .ToList();


            return Ok(listHeroi);
        }

        // GET api/<ValuesController>/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //_context.Add(heroi);
            //  _context.Herois.Add(heroi);
           //var heroi = new Heroi { Nome = nameHero };

            var heroi = _context.Herois
                            .Where(h => h.Id == 3)
                            .FirstOrDefault();
            heroi.Nome = "Homem Aranha";

            _context.SaveChanges();
            
            return Ok(heroi);
        }


        // GET api/<ValuesController>/5
        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {

            _context.AddRange(
                new Heroi { Nome ="Capitão America"},
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viuva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gavião Aqueiro" },
                new Heroi { Nome = "Capitã Marvel" }
            );

            _context.SaveChanges();

            return Ok();
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpGet("Delete/{id}")]
        public ActionResult Delete(int id)
        {
            var heroi = _context.Herois
                                 .Where(x => x.Id == id)
                                 .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
            return Ok(heroi);
        }
    }
}
