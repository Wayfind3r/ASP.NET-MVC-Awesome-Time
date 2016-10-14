using Microsoft.Owin;
using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using System.Web;

namespace Awesome_Time.DependencyResolution
{
    public class IdentityRegistry : Registry
    {
        public IdentityRegistry()
        {
            this.For<IOwinContext>().Use(() => HttpContext.Current.GetOwinContext()).LifecycleIs<TransientLifecycle>();
        }
    }
}