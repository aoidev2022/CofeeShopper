using IdentityServer.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var dbConnectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
{
    options.UseSqlServer(dbConnectionString, b => b.MigrationsAssembly(assembly));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services
    .AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(dbConnectionString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b => b.UseSqlServer(dbConnectionString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();


var app = builder.Build();

app.UseIdentityServer();

app.Run();
