using ClientCRUD.DTOS;
using ClientCRUD.Models;
using ClientCRUD.Repositories.interfaces;
using ClientCRUD.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClientCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientsController(IClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateClientDto clientDto)
        {
            if (clientDto == null) return BadRequest("Dados do cliente invalido");

            var newClientDto = await _clientService.CreateAsync(clientDto);

            return CreatedAtAction(null, newClientDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync([FromQuery] string? name, [FromQuery] string? city, [FromQuery] string? contact)
        {
            if (!string.IsNullOrEmpty(name))
            {
                return Ok(await _clientService.GetByName(name));
            }

            if (!string.IsNullOrEmpty(city))
            {
                return Ok(await _clientService.GetByCity(city));
            }

            if (!string.IsNullOrEmpty(contact))
            {
                return Ok(await _clientService.GetByContact(contact));
            }

            return Ok(await _clientService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var clientDto = await _clientService.GetByIdAsync(id);

            return Ok(clientDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateClientDto updateClientDto)
        {
            var updatedClient = await _clientService.UpdateAsync(id, updateClientDto);

            if (!updatedClient) return NotFound($"Cliente com ID {id} não encontrado.");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteAsync(int id)
        {
            var deletedClient = await _clientService.DeleteAsync(id);

            if (!deletedClient) return NotFound($"Cliente com ID {id} não encontrado.");

            return NoContent(); 
        }
    }
}