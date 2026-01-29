using CartonCaps.Application;
using CartonCaps.Application.Interfaces;
using CartonCaps.Data.Interfaces;
using CartonCaps.Data.MockData;
using CartonCaps.Transversal;

namespace CartonCaps.Api.Registers
{
    public static class RegisterExtension
    {
        public static IServiceCollection RegisterOptions(this IServiceCollection services)
        {
            services
    .           AddOptions<MockDatabaseOptions>()
                .BindConfiguration("MockDatabaseOptions")
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
                .AddTransient<IReferralRepository, MockReferralRespository>();

            return services;
        }

        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services
                .AddTransient<IReferralService, ReferralService>();

            return services;
        }
    }
}
