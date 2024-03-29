﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProAgil.Domain;
using ProAgil.Repository;
using ProAgil.WebAPI.Dtos;

namespace ProAgil.WebAPI.Controllers
{
    [Route("/evento")]
    [ApiController]
    public class EventoController : ControllerBase
    {
        public IProAgilRepository _repo { get; }
        private readonly IMapper _mapper;

        public EventoController(IProAgilRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var eventos = await _repo.GetAllEventoAsync(true);
                var results = _mapper.Map<EventoDto[]>(eventos);
                return Ok(results);
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Banco de Dados falhou!! {ex}");
            }
        }

        [HttpPost("upload/{fileName}")]
        public async Task<IActionResult> Upload(String FileName)
        {
            try
            {
                var file = Request.Form.Files[0];
                var folderName = Path.Combine("Resources", "Img");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

                if (file.Length > 0)
                {
                    var fullPath = Path.Combine(pathToSave, FileName.Trim());

                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                return Ok();
            }
            catch (System.Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Erro ao tentar realizar upload {ex}");
            }
        }


        [HttpGet("{EventoId}")]
        public async Task<ActionResult<Evento>> getByID(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventosAsyncById(EventoId, true);
                var results = _mapper.Map<EventoDto>(evento);
                return Ok(results);
            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou!!" + e.Message);
            }
        }

        [HttpGet("getByTema/{Tema}")]
        public async Task<ActionResult<Evento>> GetByTema(String tema)
        {
            try
            {
                var evento = await _repo.GetAllEventoAsyncByTema(tema, true);
                var results = _mapper.Map<EventoDto>(evento);
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados falhou!!");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(EventoDto model)
        {

            try
            {
                _repo.Add(_mapper.Map<Evento>(model));
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/Evento/{model.Id}", _mapper.Map<EventoDto>(model));
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou!!");
            }

            return BadRequest();
        }

        [HttpPut("{EventoId}")]
        public async Task<IActionResult> Put(int EventoId, EventoDto model)
        {
            try
            {
                var evento = await _repo.GetEventosAsyncById(EventoId, false);

                if (evento == null) return NotFound();

                var idLotes = new List<int>();
                var idRedeSociais = new List<int>();

                model.Lotes.ForEach(item => idLotes.Add(item.Id));
                model.RedesSociais.ForEach(item => idRedeSociais.Add(item.Id));

                var lotes = evento.Lotes.Where(
                    lote => !idLotes.Contains(lote.Id)
                ).ToArray();

                var redeSociais = evento.RedesSociais.Where(
                    rede => !idRedeSociais.Contains(rede.Id)
                ).ToArray();

                if (lotes.Length > 0)
                    _repo.DeleteRange(lotes);

                if (redeSociais.Length > 0)
                    _repo.DeleteRange(redeSociais);

                _mapper.Map(model, evento);

                _repo.Update(evento); 

                if( await _repo.SaveChangesAsync())
                    return Created($"/Evento/{model.Id}", _mapper.Map<EventoDto>(evento));

            }
            catch (System.Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco falhou!!" + e.Message);
            }

            return BadRequest();
        }

        [HttpDelete("{EventoId}")]
        public async Task<IActionResult> Delete(int EventoId)
        {
            try
            {
                var evento = await _repo.GetEventosAsyncById(EventoId, false);

                if (evento == null) return NotFound();

                _repo.Delete(evento);

                if (await _repo.SaveChangesAsync())
                {
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
