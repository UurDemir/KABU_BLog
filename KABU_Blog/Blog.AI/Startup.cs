using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.AI.Startup))]
namespace Blog.AI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
