using SecretsProvider;

namespace ExampleSecretProject;

[Section("SECA")]
public class ExampleSecretModelA
{
    public string testSecret { get; set; }
    
    public string nogger { get; set; }
}

[Section("SECA")]
public class ExampleSecretModelC
{
    public string testSecret2 { get; set; }
}