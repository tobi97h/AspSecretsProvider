namespace SecretsProvider;

public interface ISecretsProvider
{
    public T GetSecret<T>();
}