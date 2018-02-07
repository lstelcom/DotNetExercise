using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DotNetExercise.Startup))]
namespace DotNetExercise
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
