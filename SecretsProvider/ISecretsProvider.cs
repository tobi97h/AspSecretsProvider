namespace SecretsProvider;

public interface ISecretsProvider
{
    public T GetSecret<T>();
    
    public T GetSecret<T>(string section);

}