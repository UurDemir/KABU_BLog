using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Blog.AI.Modules;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Blog.AI.Startup))]
namespace Blog.AI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            SetDependencyInjection(app);
            ConfigureAuth(app);

        }

        public static void SetDependencyInjection(IAppBuilder app)
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            app.UseAutofacMiddleware(container);
            app.UseAutofacMvc();
        }
    }
}
