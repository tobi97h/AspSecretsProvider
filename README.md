# SecretsProvider

Simple wrapper around the default asp secrets management, making it either settable
via env or the cli.

## cli

`dotnet user-secrets init`

`dotnet user-secrets set "Movies:ServiceApiKey" "12345"`

## prod / env

Simply set the entire secret json as an environmental variable

# Adding to services

Simply call `IServiceCollection.AddDevSecretsProvider(defaultSection)` or `IServiceCollection.AddEnvSecretsProvider(defaultPrefix)`
in your configuration class. This then tries to read the prefixed Secrets from env / the cli set secrets, based on the class name.