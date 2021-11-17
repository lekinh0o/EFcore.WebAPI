using EFcore.Dominio;
using EFcore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        //GET: api/Heroi
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {

                return BadRequest($"Tudo errado: {ex}");
            }

        }

        //GET: api/Heroi/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
           
            return Ok("tudo certo");

        }
        // POST:/api/Heroi
        [HttpPost]  
        public ActionResult Post(Heroi model)
        {
            try
            {
                
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok($"tudo certo NO POST: {model.Nome}");
            }
            catch (Exception ex)
            {

                return BadRequest($"Tudo errado: {ex}");
            }



        }
        [HttpPut("{id}")] 
        public ActionResult Put(int id, Heroi model)
        {
            try
            {
                if(_context.Herois.AsNoTracking().FirstOrDefault(h=> h.Id == id ) != null)
                {
                    _context.Herois.Update(model);
                    _context.SaveChanges();

                    return Ok("tudo certo NO PUT: " + model.Nome );
                }
                return Ok("Não Encontrado!");


            }
            catch (Exception ex)
            {

                return BadRequest($"Tudo errado: {ex}");
            }




        }
        //Delete: api/batalha/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }
}
