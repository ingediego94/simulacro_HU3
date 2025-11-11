using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace catalogoProductos.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientService _service;

    public ClientController(IClientService service)
    {
        _service = service;
    }
    
    // ----------------------------------------------------
    
    // Get /api/clients
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var clients = await _service.GetAllAsync();
        return Ok(clients);
    }
    
    
    // Get/api/clients/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var client = await _service.GetByIdAsync(id);
        if (client == null)
            return NotFound();

        return Ok(client);
    }

    
    // POST /api/clients
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] ClientCreateDto dto)
    {
        return Ok();
    }
    
    
    // PUT /api/clients/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ClientUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return Ok(new { message = "Client has been updated." });
    }

    // DELETE /api/students/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}