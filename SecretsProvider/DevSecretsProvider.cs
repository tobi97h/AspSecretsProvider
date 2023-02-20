
using Microsoft.Extensions.Configuration;

namespace SecretsProvider;

public class DevSecretsProvider : ISecretsProvider
{
    private readonly IConfiguration _configuration;

    private readonly string _defaultSection;
    
    public DevSecretsProvider(IConfiguration configuration, string defaultSection)
    {
        _configuration = configuration;
        _defaultSection = defaultSection;
    }

    public T GetSecret<T>()
    {
        return GetSecret<T>(_defaultSection);
    }
    
    public T GetSecret<T>(string section)
    {
        var secret = _configuration.GetSection(section).Get<T>();
        return secret;
    }
}