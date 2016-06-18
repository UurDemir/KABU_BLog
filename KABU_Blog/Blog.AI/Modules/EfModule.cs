using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using Blog.Models.Contexts;
using Blog.Services.UnitOfWork;

namespace Blog.AI.Modules
{
    public class EfModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());

            builder.RegisterType(typeof(BlogContext))
                .As(typeof(DbContext))
                .InstancePerLifetimeScope();

            builder.RegisterType(typeof(UnitOfWork))
                .As(typeof(IUnitOfWork))
                .InstancePerRequest();

        }
    }
}