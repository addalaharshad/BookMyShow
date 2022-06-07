using BookMyShow_BE.Models;
using Microsoft.AspNetCore.Identity;

namespace BookMyShow_BE
{
    public static class ServiceAuthentication
    {
        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentityCore<Login>(q => q.User.RequireUniqueEmail = true);

            builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);

            builder.AddEntityFrameworkStores<BookMyShowContext>().AddDefaultTokenProviders();
        }
    }
}
