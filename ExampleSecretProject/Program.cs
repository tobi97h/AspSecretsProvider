using ExampleSecretProject;
using SecretsProvider;

var builder = WebApplication.CreateBuilder(args);
builder.AddSecretsProvider();

var app = builder.Build();

var provider = app.Services.GetRequiredService<ISecretsProvider>();
var secA = provider.GetSecret<ExampleSecretModelA>();
var secB = provider.GetSecret<ExampleSecretModelB>();
Console.WriteLine(secA.testSecret);
Console.WriteLine(secB.testSecret);

app.MapGet("/", () => "Hello World!");

app.Run();