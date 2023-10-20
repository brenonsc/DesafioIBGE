using DesafioIBGE.Model;
using DesafioIBGE.Security;
using DesafioIBGE.Service;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioIBGE.Controllers;

[Route("~/usuarios")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IValidator<User> _userValidator;
    private readonly IAuthService _authService;
    
    public UserController(IUserService userService, IValidator<User> userValidator, IAuthService authService)
    {
        _userService = userService;
        _userValidator = userValidator;
        _authService = authService;
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(long id)
    {
        var user = await _userService.GetById(id);
            
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }

    [AllowAnonymous]
    [HttpPost("signup")]
    public async Task<ActionResult> Create([FromBody] User user)
    {
        var validationResult = await _userValidator.ValidateAsync(user);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var resposta = await _userService.Create(user);

        if (resposta is null)
            return BadRequest("Usuário já cadastrado!");
        
        return CreatedAtAction(nameof(GetById), new {id = user.Id}, user);
    }

    [AllowAnonymous]
    [HttpPost("signin")]
    public async Task<ActionResult> Autenticar([FromBody] UserLogin userLogin)
    {
        var resposta = await _authService.Autenticar(userLogin);
        
        if (resposta is null)
            return Unauthorized("Usuário e/ou senha inválidos!");
        
        return Ok(resposta);
    }
}