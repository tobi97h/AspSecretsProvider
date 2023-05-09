# SecretsProvider

Simple wrapper around the default asp secrets management, making it either settable
via env or the cli.

This package is also available on nuget 

`dotnet add package SecretsProvider --version 1.1.0`

# Default usage

Initialize for usage with asp di using `WebApplicationBuilder.AddSecretsProvider()`.

Create your secret model classes like so:

```
[Section("SECA")]
public class ExampleSecretModelA
{
    public string testSecret { get; set; }
}
```

# Setting secrets in development

```bash
dotnet user-secrets init
dotnet user-secrets set "SECA:testsecret" "hello1"
```

# In prod

As env variable with a corresponding json value for the class (single line) `export SECA_ExampleSecretModelA='{ "testsecret" : "hello1" }'`.

# Retrieving a Secret

After adding it to the DI, you can inject `ISecretsProvider` anywhere, making `GetSecret<T>()` accessible to you.


