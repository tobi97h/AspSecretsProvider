using SecretsProvider;

namespace ExampleSecretProject;

[Section("SECB")]
public class ExampleSecretModelB
{
    public string testSecret { get; set; }
}