using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Api.Controllers;
[Authorize]
[ApiController]
[Route("api/product")]
public class ProductController : ControllerBase
{

    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    // ---------------------------------------------
    
    // GET BY ID
    [HttpGet("getById/{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var product = await _productService.GetByIdAsync_(id);

        if (product == null)
            return NotFound(new { message = $"Product with ID {id} not found." });

        return Ok(product);
    }
    
    
    // GET ALL:
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var products = await _productService.GetAllAsync_();

        return Ok(products);
    }

    
    // CREATE:
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] ProductCreateUpdateDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = new Product
        {
            ProductName = productDto.ProductName,
            Code = productDto.Code,
            SellerId = productDto.SellerId,
            Stock = productDto.Stock,
            Price = productDto.Price
        };

        var createdProduct = await _productService.CreateAsync_(product);

        return CreatedAtAction(nameof(GetById), new { id = createdProduct.Id }, createdProduct);
    }
    
    
    
    
    // UPDATE:
    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] ProductCreateUpdateDto productDto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var existing = await _productService.GetByIdAsync_(id);

        if (existing == null)
            return NotFound(new { message = $"Register with ID {id} not found." });

        existing.ProductName = productDto.ProductName;
        existing.Code = productDto.Code;
        existing.SellerId = productDto.SellerId;
        existing.Stock = productDto.Stock;
        existing.Price = productDto.Price;

        var updated = await _productService.UpdateAsync_(existing);

        if (!updated)
            return StatusCode(500, new { message = "Error updating." });

        return NoContent();

    }
    
    
    
    // DELETE:
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var productToDelete = await _productService.DeleteAsync_(id);

        if (!productToDelete)
            return NotFound(new { message = $"Register with ID {id} not founded." });

        return NoContent();
    }
}