using DesafioIBGE.Model;
using DesafioIBGE.Security;
using DesafioIBGE.Service;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DesafioIBGE.Controllers;

[Authorize]
[Route("~/locations")]
[ApiController]
public class LocationController : ControllerBase
{
    private readonly ILocationService _locationService;
    private readonly IValidator<Location> _locationValidator;
    
    public LocationController(ILocationService locationService, IValidator<Location> locationValidator)
    {
        _locationService = locationService;
        _locationValidator = locationValidator;
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _locationService.GetAllLocations());
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var user = await _locationService.GetLocationById(id);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }
    
    [HttpGet("city/{city}")]
    public async Task<ActionResult> GetLocationsByCity(string city)
    {
        return Ok(await _locationService.GetLocationsByCity(city));
    }
    
    [HttpGet("state/{state}")]
    public async Task<ActionResult> GetLocationsByState(string state)
    {
        return Ok(await _locationService.GetLocationsByState(state));
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Location location)
    {
        var validationResult = await _locationValidator.ValidateAsync(location);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var repost = await _locationService.CreateLocation(location);

        if (repost is null)
            return BadRequest($"Localidade com Codigo {location.Id} já cadastrada!");
        
        return CreatedAtAction(nameof(GetById), new {id = location.Id}, location);
    }
    
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Location location)
    {
        if (location.Id.Length != 7)
            return BadRequest("Codigo do IBGE é Invalido");

        var validationResult = await _locationValidator.ValidateAsync(location);

        if (!validationResult.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, validationResult);

        var updateLocation = await _locationService.UpdateLocation(location);

        if (updateLocation is null)
            return NotFound("Localizacao nao encontrada");

        return Ok(updateLocation);

    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var deletedLocation = await _locationService.DeleteLocation(id);
        
        if (deletedLocation is null)
            return NotFound();
        
        return NoContent();
        
    }
}