using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;

namespace catalogoProductos.Api.Controllers;

[Authorize]
[ApiController]
[Route("api/seller")]
public class SellerController : ControllerBase
{
    private readonly ISellerService _service;

    public SellerController(ISellerService service)
    {
        _service = service;
    }
    //--------------------------------------------------

    // GET /api/seller
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var sellers = await _service.GetAllAsync();
        return Ok(sellers);
    }

    // GET /api/seller/{id}
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var seller = await _service.GetByIdAsync(id);
        if (seller == null) return NotFound();
        return Ok(seller);
    }

    // POST /api/seller
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] SellerCreateDto dto)
    {
        return Ok();
    }

    // PUT /api/seller/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] SellerUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);
        if (!updated) return NotFound();

        return Ok(new { message = "Seller updated successfully." });
    }

    // DELETE /api/seller/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);
        if (!deleted) return NotFound();

        return NoContent();
    }
}