using Microsoft.AspNetCore.Mvc;
using TesteMaster.Domain.Services;
using TesteMaster.Domain.Entities;

namespace TesteMaster.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotaController : ControllerBase
    {
        private readonly IRotaService _service;

        public RotaController(IRotaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rota>>> GetAll()
        {
            var rotas = await _service.GetAllAsync();
            return Ok(rotas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rota>> GetById(int id)
        {
            var rota = await _service.GetByIdAsync(id);
            if (rota == null)
            {
                return NotFound();
            }
            return Ok(rota);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Rota rota)
        {
            await _service.AddAsync(rota);
            return CreatedAtAction(nameof(GetById), new { id = rota.Id }, rota);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Rota rota)
        {
            if (id != rota.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(rota);
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
