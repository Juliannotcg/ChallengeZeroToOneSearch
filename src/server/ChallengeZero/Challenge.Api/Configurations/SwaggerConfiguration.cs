using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace Challenge.Api.Configurations
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "CHALLENGE API",
                    Description = "API Challenge Zero To One Search",
                    TermsOfService = "Description",
                    Contact = new Contact { Name = "Julianno Garcia", Email = "juliannotcg@hotmail.com", Url = "https://github.com/Juliannotcg/ChallengeZeroToOneSearch" },
                    License = new License { Name = "MIT", Url = "https://github.com/Juliannotcg/ChallengeZeroToOneSearch" }
                });

            });
        }
    }
}