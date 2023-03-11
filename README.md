# SecretsProvider

Simple wrapper around the default asp secrets management, making it either settable
via env or the cli.

This package is also available on nuget 

`dotnet add package SecretsProvider --version 1.0.1`

# Adding to services

Simply call `IServiceCollection.AddDevSecretsProvider(defaultSection)` or `IServiceCollection.AddEnvSecretsProvider(defaultPrefix)`
in your configuration class. This then tries to read the prefixed Secrets from env / the cli set secrets, based on the class name.

You may also call `WebApplicationBuilder.AddSecretsProvider(defaultSection)` for an implementation that adds the dev provider if `IsDevelopment()` / the env
provider if `IsProduction()`.

# Retrieving a Secret

After adding it to the DI, you can inject `ISecretsProvider` anywhere, making `GetSecret<T>()` and `GetSecret<T>(SectionName)` accessible to you.

# Adding Secrets

## cli (for development)

`dotnet user-secrets init`

`dotnet user-secrets set "SECTION_NAME:ServiceApiKey" "12345"`

The here specified `SECTION_NAME`, is the same that is referenced in "Adding to services".

Lets say we have some generic `clientId` and `clientSecret` as values. Our class would look like this:

```csharp
public class GenericSecrets {
    
    public string clientId { get;set; }
    
    public string clientSecret { get;set; }
}
```

To initialise these secrets we have to choose a section that these two values are contained in. Lets just call it `GS`, it could be anything tho.

```bash
dotnet user-secrets set "GS:clientId" "ABC"
dotnet user-secrets set "GS:clientSecret" "123"
```

To then recieve it in our code we either do `ISecretsProvider.GetSecret<GenericSecrets>("GS");`, or just `ISecretsProvider.GetSecret<GenericSecrets>();` if we initialised the provider with the default section `GS`.

This is useful if you have all of your secrets in a single class, which is a design pattern that is useful if you have an app that only contains a handful of secrets.

##  env (for production)

Simply set the entire secret json as an environmental variable. The name is Section + "_" + ClassName, like so:

```bash
export GS_GenericSecrets='{ "clientId" : "ABC", "clientSecret" : "123" }'
```

Receiving it is just the same (which is the point of this library).



