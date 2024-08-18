using IconBuilderAI.Application.Common.Interfaces;
using IconBuilderAI.WebApi.Services;

namespace IconBuilderAI.WebApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpContextAccessor();

            services.AddScoped<ICurrentUserService, CurrentUserManager>();

            return services;
        }
    }
}