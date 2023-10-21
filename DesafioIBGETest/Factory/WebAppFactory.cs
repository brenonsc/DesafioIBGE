using DesafioIBGE;
using DesafioIBGE.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebMotions.Fake.Authentication.JwtBearer;

namespace DesafioIBGETest.Factory;

public class WebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType ==
                     typeof(DbContextOptions<AppDbContext>));
            
            if(descriptor != null)
                services.Remove(descriptor);
            
            services.AddDbContext<AppDbContext>(options =>
                options.UseInMemoryDatabase("InMemoryDesafioIBGETest"));

            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            using var appContext = scope.ServiceProvider.GetService<AppDbContext>();

            try
            {
                appContext!.Database.EnsureCreated();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                throw;
            }
        });

        builder.UseContentRoot(".");
        builder.UseTestServer().ConfigureTestServices(collection =>
        {
            collection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = FakeJwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = FakeJwtBearerDefaults.AuthenticationScheme;
            }).AddFakeJwtBearer();
        });
        
        base.ConfigureWebHost(builder);
    }
}