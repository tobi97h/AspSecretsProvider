using System.Text.Json;


namespace SecretsProvider;

public class EnvSecretsProvider : ISecretsProvider
{
    private readonly string? _defaultPrefix;
    
    public EnvSecretsProvider(string? defaultPrefix = null)
    {
        _defaultPrefix = defaultPrefix;
    }
    
    public T GetSecret<T>()
    {
        string prefix;
        SectionAttribute? sectionAttribute = (SectionAttribute?) Attribute.GetCustomAttribute(typeof(T), typeof(SectionAttribute));
        
        if (_defaultPrefix == null && sectionAttribute == null)
        {
            throw new Exception("Neither Section Attribute defined nor default prefix defined");
        }
        
        if (sectionAttribute != null)
        {
            prefix = sectionAttribute.SectionName;
        }
        else
        {
            prefix = _defaultPrefix;
        }

        var secretName = typeof(T).Name;
        var secretJsonFromEnv = Environment.GetEnvironmentVariable(prefix + "_" + secretName.ToUpper());
        if (string.IsNullOrEmpty(secretJsonFromEnv))
        {
            throw new Exception("Env var for secret " + prefix + "_" + secretName.ToUpper() + " not set!");
        }

        var secret = JsonSerializer.Deserialize<T>(secretJsonFromEnv);
        if (secret == null)
        {
            throw new Exception("Error deserializing secret from env: " + secretName + " " + secretJsonFromEnv);
        }
        return secret;
    }
}