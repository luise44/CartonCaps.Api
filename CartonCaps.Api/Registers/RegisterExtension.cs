using CartonCaps.Application;
using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Interfaces;
using CartonCaps.Data.MockData;
using CartonCaps.DeepLinkService.Interface;
using CartonCaps.Transversal;

namespace CartonCaps.Api.Registers
{
    public static class RegisterExtension
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection services)
        {
            services
                .AddOptions<JwtOptions>()
                .BindConfiguration("JwtOptions")
                .ValidateOnStart();

            services
                .AddOptions<MessageTemplateOptions>()
                .BindConfiguration("MessageTemplateOptions")
                .ValidateOnStart();

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services)
        {
            services
                .AddSingleton<IDatabase, MockDatabase>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IReferralRepository, MockReferralRespository>()
                .AddTransient<IUserRepository, MockUserRepository>();

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services
                .AddTransient<ILoginService, LoginService>()
                .AddTransient<IRegisterService, RegisterService>()
                .AddTransient<IDeepLinkService, DeepLinkService.DeepLinkService>()
                .AddTransient<ITemplateService, TemplateService>()
                .AddTransient<IReferralService, ReferralService>();

            return services;
        }
    }
}
