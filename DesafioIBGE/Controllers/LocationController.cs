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
    
    /// <summary>
    /// Retorna todas as localidades cadastradas no sistema
    /// </summary>
    /// <returns>Retorna todas as localidades cadastradas no sistema</returns>
    /// <response code="200">Sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _locationService.GetAllLocations());
    }
    
    /// <summary>
    /// Retorna a localidade com o ID informado
    /// </summary>
    /// <returns>Retorna atributos da localidade</returns>
    /// <response code="200">Sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById(string id)
    {
        var user = await _locationService.GetLocationById(id);
        if (user == null)
            return NotFound();
        
        return Ok(user);
    }
    
    /// <summary>
    /// Retorna as cidades que contém o nome informado
    /// </summary>
    /// <returns>Retorna atributos da localidade informada</returns>
    /// <response code="200">Sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpGet("city/{city}")]
    public async Task<ActionResult> GetLocationsByCity(string city)
    {
        return Ok(await _locationService.GetLocationsByCity(city));
    }
    
    /// <summary>
    /// Retorna os estados que contém o nome informado
    /// </summary>
    /// <returns>Retorna atributos da localidade informada</returns>
    /// <response code="200">Sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpGet("state/{state}")]
    public async Task<ActionResult> GetLocationsByState(string state)
    {
        if (state.Length > 2)
        {
            return BadRequest("Estado Invalido, Informe a Sigla do Estado Ex: SP");
        }
        return Ok(await _locationService.GetLocationsByState(state));
    }
    
    /// <summary>
    /// Cadastra uma nova localidade
    /// </summary>
    /// <returns>Retorna atributos da localidade informada</returns>
    /// <response code="201">Localidade criada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] Location location)
    {
        if (location.id.Length != 7)
            return BadRequest("Código do IBGE inválido");
        
        var validationResult = await _locationValidator.ValidateAsync(location);
        
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        
        var repost = await _locationService.CreateLocation(location);

        if (repost is null)
            return BadRequest($"Localidade com código {location.id} já cadastrada!");
        
        return CreatedAtAction(nameof(GetById), new {id = location.id}, location);
    }
    
    /// <summary>
    /// Atualiza uma localidade existente
    /// </summary>
    /// <returns>Retorna atributos da localidade informada</returns>
    /// <response code="200">Localidade atualizada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpPut]
    public async Task<ActionResult> Update([FromBody] Location location)
    {
        if (location.id.Length != 7)
            return BadRequest("Código do IBGE inválido");

        var validationResult = await _locationValidator.ValidateAsync(location);

        if (!validationResult.IsValid)
            return StatusCode(StatusCodes.Status400BadRequest, validationResult);

        var updateLocation = await _locationService.UpdateLocation(location);

        if (updateLocation is null)
            return NotFound("Localização não encontrada");

        return Ok(updateLocation);

    }
    
    /// <summary>
    /// Deleta uma localidade existente pelo ID
    /// </summary>
    /// <returns>Retorna NoContent</returns>
    /// <response code="204">Localidade deletada com sucesso</response>
    /// <response code="401">Não autorizado</response>
    /// <response code="500">Erro provavelmente causado pelo Render, tente novamente, por favor</response>
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(string id)
    {
        var deletedLocation = await _locationService.DeleteLocation(id);
        
        if (deletedLocation is null)
            return NotFound();

        return NoContent();
    }
}