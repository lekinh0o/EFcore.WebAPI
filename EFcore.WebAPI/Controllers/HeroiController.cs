using EFcore.Dominio;
using EFcore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFcore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly IEFCoreRepository _repo;
        public HeroiController(IEFCoreRepository repo)
        {
            _repo = repo;
        }

       
        //GET: api/Heroi
        [HttpGet]
        public async Task <IActionResult> Get()
        {
           
            try
            {
                var herois = await _repo.GetAllHerois(true);
                return Ok(herois);
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }

        //GET: api/Heroi/5
        [HttpGet("{id}", Name = "GetHeroi")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var heroi = await _repo.GetBatalhaById(id, true);
                return Ok(heroi);
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }
        // POST:/api/Heroi
        [HttpPost]
        public async Task<IActionResult> Post(Heroi model)
        {
            try
            {

                _repo.Add(model);
                if (await _repo.SaveChangeAsync())
                {
                    return Ok("Tudo certo! " + model.Nome);
                }



            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
            return BadRequest("Não salvou");
        }
        [HttpPut("{id}")] 
        public async Task <IActionResult> Put(int id, Heroi model)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Tudo certo! " + heroi.Nome + " Atualizada! ");
                    }
                }


            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
            return BadRequest("Não Atualizada!!!");




        }
        //Delete: api/batalha/5
        [HttpDelete("{id}")]
        public async Task <IActionResult>Delete(int id)
        {
            try
            {
                var heroi = await _repo.GetBatalhaById(id);
                if (heroi != null)
                {
                    _repo.Delete(heroi);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Tudo certo! " + heroi.Nome + " Deletado! ");
                    }
                }


            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
            return BadRequest("Não Deletado!!!");
        }

    }
}
