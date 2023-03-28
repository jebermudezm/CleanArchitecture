namespace Api.Extensions.Features
{
    internal static class FeatureExtensions
    {
        public static IServiceCollection AddFeature(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddCors();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //                .AddMicrosoftIdentityWebApi(configuration.GetSection("AzureAd"));

            return services;
        }
    }
}
