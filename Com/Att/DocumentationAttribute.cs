namespace Sys.Com.Att
{
    [AttributeUsage(AttributeTargets.All)]
    public sealed class DocumentationAttribute(string uri) : Attribute
    {
        public string Uri { get; } = uri;
    }
}
