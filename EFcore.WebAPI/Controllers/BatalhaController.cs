using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EFcore.Dominio;
using EFcore.Repo;

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    public class BatalhaController : ControllerBase
    {
        private readonly HeroiContext _context;

        public BatalhaController(HeroiContext context)
        {
            _context = context;
        }

        // GET: api/Batalha
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Batalha());
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }

        // GET: api/Batalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public string Get(int id)
        {
           

            return "Value";
        }
        //POST: api/Batalha
        [HttpPost]
        public ActionResult Post(Batalha model)
        {
            try
            {
               
                _context.Batalhas.Add(model);
                _context.SaveChanges();
                return Ok("Tudo certo! " + model.Nome); 
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }

        //PUT: api/Batalha/5
        [HttpPut("{id}")]
        public ActionResult Put(int id , Batalha model)
        {
            try
            {
                if (_context.Batalhas.AsNoTracking().FirstOrDefault(h => h.Id == id) != null)
                {
                    _context.Batalhas.Update(model);
                    _context.SaveChanges();
                    return Ok("Tudo certo! " + model.Nome);
                }
                return Ok("Não encontrado");

            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }

        //DELETE: api/batalha/5
        [HttpDelete("{id}")]
        public void delete(int id)
        {

        }
    }
}
