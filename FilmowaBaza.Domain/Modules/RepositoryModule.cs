using Autofac;
using FilmowaBaza.Domain.Repositories;
using FilmowaBaza.Domain.Repositories.Interfaces;
using System.Reflection;

namespace FilmowaBaza.Domain.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var repositoriesAssembly = typeof(RepositoryModule)
                .GetTypeInfo()
                .Assembly;
            builder.RegisterGeneric(typeof(BaseRepository<>))
                .As(typeof(IBaseRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repositoriesAssembly)
                .Where(r => r.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}