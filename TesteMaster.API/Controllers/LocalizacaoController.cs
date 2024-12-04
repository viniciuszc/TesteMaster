using Microsoft.AspNetCore.Mvc;
using TesteMaster.Domain.Services;
using TesteMaster.Domain.Entities;

namespace TesteMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalizacaoController : ControllerBase
    {
        private readonly ILocalizacaoService _service;

        public LocalizacaoController(ILocalizacaoService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localizacao>>> GetAll()
        {
            var localizacoes = await _service.GetAllAsync();
            return Ok(localizacoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Localizacao>> GetById(int id)
        {
            var localizacao = await _service.GetByIdAsync(id);
            if (localizacao == null)
            {
                return NotFound();
            }
            return Ok(localizacao);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Localizacao localizacao)
        {
            await _service.AddAsync(localizacao);
            return CreatedAtAction(nameof(GetById), new { id = localizacao.Id }, localizacao);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Localizacao localizacao)
        {
            if (id != localizacao.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(localizacao);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
