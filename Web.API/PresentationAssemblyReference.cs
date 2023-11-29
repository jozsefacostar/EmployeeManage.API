using System.Reflection;

namespace Web.API
{
    public class PresentationAssemblyReference
    {
        public class ApplicationAssemblyReference
        {
            internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
        }
    }
}
