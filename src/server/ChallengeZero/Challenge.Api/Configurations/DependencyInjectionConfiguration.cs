using Microsoft.Extensions.DependencyInjection;
using Challenge.Infra.CrossCutting.IoC;

namespace Challenge.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}