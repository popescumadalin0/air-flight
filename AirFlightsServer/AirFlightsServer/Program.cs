using AirFlightsServer;
using AirFlightsServer.Extensions;
using DataBaseLayout.DbContext;
using DataBaseLayout.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServices(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;
    options.SignIn.RequireConfirmedPhoneNumber = true;
    options.Stores.ProtectPersonalData = true;
    options.User.RequireUniqueEmail = true;
});

//builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddIdentityApiEndpoints<User>()
    .AddEntityFrameworkStores<Context>();

builder.Services.AddScoped<ILookupProtectorKeyRing, KeyRing>();
builder.Services.AddScoped<ILookupProtector, LookupProtector>();
builder.Services.AddScoped<IPersonalDataProtector, PersonalDataProtector>();

var app = builder.Build();

app.MapIdentityApi<User>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
