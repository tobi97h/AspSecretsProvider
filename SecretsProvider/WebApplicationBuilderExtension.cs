using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SecretsProvider;

public static class WebApplicationBuilderExtension
{

    public static void AddSecretsProvider(this WebApplicationBuilder builder, string? defaultSection = null)
    {
        if (builder.Environment.IsDevelopment())
        {
            builder.Services.AddDevSecretsProvider(defaultSection);
        }else if (builder.Environment.IsProduction())
        {
            builder.Services.AddEnvSecretsProvider(defaultSection);
        }
    }
    
    public static void AddDevSecretsProvider(this IServiceCollection serviceCollection, string? defaultSection = null)
    {
        serviceCollection
            .AddSingleton<ISecretsProvider, DevSecretsProvider>(provider => new DevSecretsProvider(provider.GetRequiredService<IConfiguration>(), defaultSection));
    }

    public static void AddEnvSecretsProvider(this IServiceCollection serviceCollection, string? defaultSection = null)
    {
        serviceCollection
            .AddSingleton<ISecretsProvider, EnvSecretsProvider>(_ => new EnvSecretsProvider(defaultSection));
    }
}