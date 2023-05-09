
using Microsoft.Extensions.Configuration;

namespace SecretsProvider;

public class DevSecretsProvider : ISecretsProvider
{
    private readonly IConfiguration _configuration;

    private readonly string? _defaultSection;
    
    public DevSecretsProvider(IConfiguration configuration, string? defaultSection = null)
    {
        _configuration = configuration;
        _defaultSection = defaultSection;
    }

    public T GetSecret<T>()
    {
        SectionAttribute? sectionAttribute = (SectionAttribute?) Attribute.GetCustomAttribute(typeof(T), typeof(SectionAttribute));
        if (sectionAttribute != null)
        {
            return _configuration.GetSection(sectionAttribute.SectionName).Get<T>();
        }

        if (_defaultSection == null)
        {
            throw new Exception("Neither Section Attribute defined nor default section provided");
        }
        
        return _configuration.GetSection(_defaultSection).Get<T>();
    }
}