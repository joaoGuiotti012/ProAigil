using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;
using ProAgil.Repository;

namespace ProAgil.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }

        public EventoController(IProAgilRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var results = await _repo.GetAllEventoAsync(true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou!!");
            }
        }


        [HttpGet("{EventoId}")]
        public async Task<ActionResult<Evento>> getEventByID(int EventoId)
        {
            try
            {
                var results = await _repo.GetAllEventoAsyncById(EventoId, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou!!");
            }
        }

        [HttpGet("getByTema/{Tema}")]
        public async Task<ActionResult<Evento>> GetByTema(String tema)
        {
            try
            {
                var results = await _repo.GetAllEventoAsyncByTema(tema, true);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou!!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Evento model) {
            try
            {
                _repo.Add(model);
                if( await _repo.SaveChangesAsync()) {
                   return Created($"/Evento/{model.Id}", model); 
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou!!");
            }

            return BadRequest();
        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, Evento model) {
            try
            {
                var evento =  await _repo.GetAllEventoAsyncById(EventoId, false);
                
                if( evento == null ) return NotFound();

                _repo.Update(model);
                
                if( await _repo.SaveChangesAsync()) {
                   return Created($"/Evento/{model.Id}", model); 
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou!!");
            }

            return BadRequest();
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId) {
            try
            {
                var evento =  await _repo.GetAllEventoAsyncById(EventoId, false);
                
                if( evento == null ) return NotFound();

                _repo.Delete(evento);

                if( await _repo.SaveChangesAsync()) {
                   return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou!!");
            }

            return BadRequest();
        }

    }
}
