using System;
using System.Linq;
using System.Threading.Tasks;
using AirFlightsServer;
using AirFlightsServer.Extensions;
using DataBaseLayout.DbContext;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Models.Constants;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    //todo: to be configured
    options.SignIn.RequireConfirmedEmail = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    //todo: to be configured
    options.SignIn.RequireConfirmedPhoneNumber = false;
    options.Stores.ProtectPersonalData = true;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddIdentityApiEndpoints<User>()
    .AddRoles<Role>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<ILookupProtectorKeyRing, KeyRing>();
builder.Services.AddScoped<ILookupProtector, LookupProtector>();
builder.Services.AddScoped<IPersonalDataProtector, PersonalDataProtector>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapIdentityApi<User>();

app.UseAuthorization();

app.MapControllers();

await DefaultDataAsync();

app.Run();

return;

async Task DefaultDataAsync()
{
    var roleManager = builder.Services.BuildServiceProvider().GetService<RoleManager<Role>>();

    var userRole = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Roles.User);
    if (userRole == null)
    {
        var result = await roleManager.CreateAsync(
            new Role()
            {
                Id = Roles.User,
                Name = Roles.User
            });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    var employeeRole = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Roles.Employee);
    if (employeeRole == null)
    {
        var result = await roleManager.CreateAsync(
            new Role()
            {
                Id = Roles.Employee,
                Name = Roles.Employee
            });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }

    var adminRole = await roleManager.Roles.FirstOrDefaultAsync(x => x.Id == Roles.Admin);
    if (adminRole == null)
    {
        var result = await roleManager.CreateAsync(
            new Role()
            {
                Id = Roles.Admin,
                Name = Roles.Admin
            });
        if (!result.Succeeded)
        {
            throw new Exception(result.Errors.First().Description);
        }
    }
}
