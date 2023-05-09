namespace SecretsProvider;


[System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct)
]
public class SectionAttribute : Attribute
{
    public string SectionName;

    public SectionAttribute(string sectionName)
    {
        SectionName = sectionName;
    }
}