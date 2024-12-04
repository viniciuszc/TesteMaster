using Microsoft.AspNetCore.Mvc;
using TesteMaster.Domain.Services;
using TesteMaster.Domain.Entities;

namespace TesteMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViagemController : ControllerBase
    {
        private readonly IViagemService _service;

        public ViagemController(IViagemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Viagem>>> GetAll()
        {
            var viagens = await _service.GetAllAsync();
            return Ok(viagens);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Viagem>> GetById(int id)
        {
            var viagem = await _service.GetByIdAsync(id);
            if (viagem == null)
            {
                return NotFound();
            }
            return Ok(viagem);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Viagem viagem)
        {
            viagem.Id = 0;

            await _service.AddAsync(viagem);
            return CreatedAtAction(nameof(GetById), new { id = viagem.Id }, viagem);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Viagem viagem)
        {
            if (id != viagem.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(viagem);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("ListarViagensPossiveis")]
        public async Task<ActionResult<IEnumerable<Viagem>>> ListarViagensPossiveis(string origem, string destino)
        {
            var result = await _service.GetListarViagensPossiveisAsync(origem, destino);
            return Ok(result);
        }

        [HttpGet("ListarViagensMenorValor")]
        public async Task<ActionResult<Viagem>> ListarViagensMenorValor(string origem, string destino)
        {
            var result = await _service.GetViagemMenorValorAsync(origem, destino);
            return Ok(result);
        }

    }
}
