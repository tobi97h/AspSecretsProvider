using ExampleSecretProject;
using SecretsProvider;

var builder = WebApplication.CreateBuilder(args);
builder.AddSecretsProvider();

var app = builder.Build();

var provider = app.Services.GetRequiredService<ISecretsProvider>();
var secA = provider.GetSecret<ExampleSecretModelA>();
var secB = provider.GetSecret<ExampleSecretModelB>();
var secC = provider.GetSecret<ExampleSecretModelC>();
Console.WriteLine(secA.testSecret);
Console.WriteLine(secB.testSecret);
Console.WriteLine(secC.testSecret2);

app.MapGet("/", () => "Hello World!");

app.Run();