using DataBaseLayout.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.PlaneFacilityuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataBaseLayout;

public static class DependencyInjection
{
    public static IServiceCollection AddDataLayout(this IServiceCollection services, IPlaneFacilityuration configuration)
    {
        services.AddScoped<IContext, Context.Context>();

        var databaseConnectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<Context.Context>(options => options.UseSqlServer(databaseConnectionString));
        return services;
    }
}