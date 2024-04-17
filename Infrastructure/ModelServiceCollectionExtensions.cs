using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeakerManagementSystem.DatabaseContext;
using SpeakerManagementSystem.Models.Common;
using SpeakerManagementSystem.Repository;
using SpeakerManagementSystem.Repository.Interface;

namespace SpeakerManagementSystem.Infrastructure
{
    public static class ModelServiceCollectionExtensions
    {
        public static IServiceCollection AddDataLayer(this IServiceCollection services, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new ApplicationException("A connection string is required for the data context");
            }

            // Add framework services.
            services.AddDbContext<SpeakerMgmtDbContext>(options => {
                options.UseSqlServer(connectionString);
                options.AddInterceptors(new AuditInterceptor());
            });

            services.AddIdentity<ApplicationUser, IdentityRole>(option => {
                option.SignIn.RequireConfirmedAccount = true;
			}).AddEntityFrameworkStores<SpeakerMgmtDbContext>()
            //.AddDefaultUI()
            .AddDefaultTokenProviders();


            #region Register Services

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();

            #endregion

            return services;
        }
    }
}
