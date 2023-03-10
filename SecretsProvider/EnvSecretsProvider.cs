using System.Text.Json;


namespace SecretsProvider;

public class EnvSecretsProvider : ISecretsProvider
{
    private readonly string _defaultPrefix;
    
    public EnvSecretsProvider(string defaultPrefix)
    {
        _defaultPrefix = defaultPrefix;
    }

    public T GetSecret<T>()
    {
        return GetSecret<T>(_defaultPrefix);
    }
    
    public T GetSecret<T>(string prefix)
    {
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