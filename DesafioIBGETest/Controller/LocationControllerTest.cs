using System.Dynamic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using DesafioIBGE.Controllers;
using DesafioIBGE.Model;
using DesafioIBGE.Service;
using DesafioIBGETest.Factory;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Xunit.Extensions.Ordering;

namespace DesafioIBGETest.Controller;

public class LocationControllerTest : IClassFixture<WebAppFactory>
{
    protected readonly WebAppFactory _factory;
    protected HttpClient _client;
    
    private readonly dynamic token;
    private string Id { get; set; } = string.Empty;
    
    public LocationControllerTest(WebAppFactory factory)
    {
        _factory = factory;
        _client = _factory.CreateClient();

        token = GetToken();
    }
    
    private static dynamic GetToken()
    {
        dynamic data = new ExpandoObject();
        data.sub = "root@root.com";
        return data;
    }
    
    [Fact, Order(1)]
    public async Task DeveListarTodosOsProdutos()
    {
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.GetAsync("/locations");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(2)]
    public async Task DeveCriarUmaLocalidade()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "1234567"},
            {"city", "Teste"},
            {"state", "EX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);
        resposta.EnsureSuccessStatusCode();
        resposta.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact, Order(3)]
    public async Task NaoDeveCriarUmaLocalidadeComIdInvalido()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "12345678"},
            {"city", "Teste"},
            {"state", "EX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(4)]
    public async Task NaodeveCriarUmaLocalidadeComEstadoInvalido()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "1234567"},
            {"city", "Teste"},
            {"state", "EXX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(5)]
    public async Task NaoDeveCriarUmaLocalidadeComCidadeInvalida()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "1234567"},
            {"city", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."},
            {"state", "EX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(6)]
    public async Task NaoDeveCriarUmaLocalidadeDuplicada()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "1234567"},
            {"city", "Teste"},
            {"state", "EX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(7)]
    public async Task DeveListarUmaLocalidade()
    {
        _client.SetFakeBearerToken((object) token);
        
        Id = "1234567";
        
        var resposta = await _client.GetAsync($"/locations/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(8)]
    public async Task DeveListarUmaLocalidadePorCidade()
    {
        _client.SetFakeBearerToken((object) token);
        
        var city = "Tes";
        
        var resposta = await _client.GetAsync($"/locations/city/{city}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(9)]
    public async Task DeveListarUmaLocalidadePorEstado()
    {
        _client.SetFakeBearerToken((object) token);
        
        var state = "EX";
        
        var resposta = await _client.GetAsync($"/locations/state/{state}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(10)]
    public async Task DeveAtualizarUmaLocalidade()
    {
        var newLocation = new Dictionary<string, string>()
        {
            {"id", "7654321"},
            {"city", "Teste 2"},
            {"state", "EX"}
        };
        
        var locationJson = JsonConvert.SerializeObject(newLocation);
        var corpoRequisicao = new StringContent(locationJson, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var resposta = await _client.PostAsync("/locations", corpoRequisicao);
        
        var corpoRespostaPost = await resposta.Content.ReadFromJsonAsync<Location>();
        
        if(corpoRespostaPost != null)
            Id = corpoRespostaPost.id.ToString();
        
        var updatedLocation = new Dictionary<string, string>()
        {
            {"id", Id},
            {"city", "Teste 2 atualizada"},
            {"state", "EX"}
        };
        
        var produtoJsonAtualizado = JsonConvert.SerializeObject(updatedLocation);
        var corpoRequisicaoAtualizado = new StringContent(produtoJsonAtualizado, Encoding.UTF8, "application/json");
        
        _client.SetFakeBearerToken((object) token);
        
        var respostaPut = await _client.PutAsync("/locations", corpoRequisicaoAtualizado);
        
        respostaPut.StatusCode.Should().Be(HttpStatusCode.OK);
    }
    
    [Fact, Order(11)]
    public async Task NaoDeveEncontrarUmaLocalidade()
    {
        _client.SetFakeBearerToken((object) token);
        
        Id = "12345678";
        
        var resposta = await _client.GetAsync($"/locations/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.NotFound);
    }
    
    [Fact, Order(12)]
    public async Task DeveDeletarUmaLocalidade()
    {
        _client.SetFakeBearerToken((object) token);
        
        Id = "1234567";
        
        var resposta = await _client.DeleteAsync($"/locations/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.NoContent);
    }
}