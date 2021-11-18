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
        private readonly IEFCoreRepository _repo;

        public BatalhaController(IEFCoreRepository repo)
        {
            _repo = repo;   
        }

        // GET: api/Batalha
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var batalha = await _repo.GetAllBatalhas(true);
                return Ok(batalha);
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }

        // GET: api/Batalha/5
        [HttpGet("{id}", Name = "GetBatalha")]
        public async Task<IActionResult> Get(int id)
        {

            try
            {
                var batalha = await _repo.GetBatalhaById(id, true);
                return Ok(batalha);
            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
        }
        //POST: api/Batalha
        [HttpPost]
        public  async Task <IActionResult> Post(Batalha model)
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

        //PUT: api/Batalha/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id , Batalha model)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if (batalha != null)
                {
                    _repo.Update(model);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Tudo certo! " + batalha.Nome + " Atualizada! ");
                    }
                }


            }
            catch (Exception ex)
            {

                return BadRequest($"Deu Ruim: {ex}");
            }
            return BadRequest("Não Atualizada!!!");
        }

        //DELETE: api/batalha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var batalha = await _repo.GetBatalhaById(id);
                if ( batalha != null )
                {
                   _repo.Delete(batalha);
                    if (await _repo.SaveChangeAsync())
                    {
                        return Ok("Tudo certo! " + batalha.Nome +" Deletado! ");
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
