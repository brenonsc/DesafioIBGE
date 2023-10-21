using System.Dynamic;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using DesafioIBGE.Model;
using DesafioIBGETest.Factory;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit.Extensions.Ordering;

namespace DesafioIBGETest.Controller;

public class UserControllerTest : IClassFixture<WebAppFactory>
{
    protected readonly WebAppFactory _factory;
    protected HttpClient _client;
    
    private readonly dynamic token;
    private string Id { get; set; } = string.Empty;
    
    public UserControllerTest(WebAppFactory factory)
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
    public async Task DeveCriarUmUsuario()
    {
        var novoUsuario = new Dictionary<string, string>()
        {
            { "usuario", "brenonsc@gmail.com" },
            { "senha", "12345678" }
        };
        
        var usuarioJson = JsonConvert.SerializeObject(novoUsuario);
        var corpoRequisicao = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        
        var resposta = await _client.PostAsync("/usuarios/signup", corpoRequisicao);
        resposta.EnsureSuccessStatusCode();
        resposta.StatusCode.Should().Be(HttpStatusCode.Created);
    }
    
    [Fact, Order(2)]
    public async Task DeveDarErroEmail()
    {
        var novoUsuario = new Dictionary<string, string>()
        {
            { "usuario", "brenousuario.com" },
            { "senha", "12345678" }
        };
        
        var usuarioJson = JsonConvert.SerializeObject(novoUsuario);
        var corpoRequisicao = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        
        var resposta = await _client.PostAsync("/usuarios/signup", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(3)]
    public async Task NaoDeveCriarUsuarioDuplicado()
    {
        var novoUsuario = new Dictionary<string, string>()
        {
            { "usuario", "teste@usuario.com" },
            { "senha", "12345678" }
        };
        
        var usuarioJson = JsonConvert.SerializeObject(novoUsuario);
        var corpoRequisicao = new StringContent(usuarioJson, Encoding.UTF8, "application/json");
        
        await _client.PostAsync("/usuarios/signup", corpoRequisicao);
        
        var resposta = await _client.PostAsync("/usuarios/signup", corpoRequisicao);
        
        resposta.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    }
    
    [Fact, Order(4)]
    public async Task DeveListarUmUsuario()
    {
        _client.SetFakeBearerToken((object) token);
        
        Id = "1";
        
        var resposta = await _client.GetAsync($"/usuarios/{Id}");

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }

    [Fact, Order(5)]
    public async Task DeveAutenticarUmUsuario()
    {
        var novoUsuario = new Dictionary<string, string>()
        {
            { "usuario", "brenonsc@gmail.com" },
            { "senha", "12345678" }
        };

        var usuarioJson = JsonConvert.SerializeObject(novoUsuario);
        var corpoRequisicao = new StringContent(usuarioJson, Encoding.UTF8, "application/json");

        var resposta = await _client.PostAsync("/usuarios/signin", corpoRequisicao);

        resposta.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}