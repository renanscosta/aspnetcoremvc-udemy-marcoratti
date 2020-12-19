using System;
using LanchesMac;
using LanchesMac.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public static class MetodosExtensao
{
    public static IHost CreateAdminRole(this IHost host)
    {
        using (var scope = host.Services.CreateScope())
        {
            var services = scope.ServiceProvider;
            try
            {
                var serviceProvider = services.GetRequiredService<IServiceProvider>();
                var configuration = services.GetRequiredService<IConfiguration>();

                //chama o método para criar os perfis 
                //e atribuir o perfil admin ao superusuario
                SeedData.CreateRoles(serviceProvider, configuration).Wait();
            }
            catch (Exception exception)
            {
                var logger = services.GetRequiredService<ILogger<Program>>();
                logger.LogError(exception, "Ocorreu um erro na criação dos perfis dos usuários");
            }
        }
        return host;
    }
}