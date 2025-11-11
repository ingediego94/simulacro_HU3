using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using catalogoProductos.Application.Auth;
using catalogoProductos.Application.Dto;
using catalogoProductos.Application.Interfaces;
using catalogoProductos.Application.Services;
using catalogoProductos.Domain.Entities;

namespace catalogoProductos.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly LoginService _loginService;
    private readonly IAdminService _adminService;
    private readonly IRegisterPersonService _registerPersonService;

    public AuthController(LoginService loginService, IAdminService adminService, IRegisterPersonService registerPersonService)
    {
        _loginService = loginService;
        _adminService =  adminService;
        _registerPersonService = registerPersonService;
    }

    
    // Testing
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok("pong");
    }
    
    
    // Login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var token = await _loginService.Login(request.Email, request.Password);
        if (token == null) return Unauthorized("Invalid credentials.");
        return Ok(new { token });
    }

    
    //Register/admin
    [HttpPost("register/admin")]
    public async Task<IActionResult> RegisterAdmin([FromBody] RegisterAdminRequest request, [FromServices] IAdminService service)
    {
        var created = await service.RegisterAdmin(request.Email, request.Password);
        if (!created) return Conflict("Ya existe un admin con ese email");
        return Ok("Admin creado con éxito");
    }

    
    //Register/client
    [HttpPost("register/client")]
    public async Task<IActionResult> RegisterClient([FromBody] RegisterPersonRequest request)
    {
        var result = await _registerPersonService.RegisterClientAsync(request);
        return Ok(result);
    } 
    
    
    //Register/seller
    [HttpPost("register/seller")]
    public async Task<IActionResult> RegisterSeller([FromBody] RegisterPersonRequest request)
    {
        var result = await _registerPersonService.RegisterSellerAsync(request);
        return Ok(result);
    }
}

public record LoginRequest(string Email, string Password);
public record RegisterAdminRequest(string Email, string Password);
