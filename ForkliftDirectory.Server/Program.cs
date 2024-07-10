using ForkliftDirectory.Server;
using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Extensions;
using ForkliftDirectory.Server.Interfaces;
using ForkliftDirectory.Server.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRouting();

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowClient", builder => builder
        .WithOrigins("https://localhost:5173")
        .AllowAnyHeader()
        .AllowAnyMethod());

    opts.AddPolicy("AllowAll", builder => builder
        .AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

} );

builder.Services.AddControllers();
builder.Services.ConfigureAutomapper();
builder.Services.AddDbContext<ForkliftDirectoryDbContext>(opts => opts.UseNpgsql(builder.Configuration["ConnectionStrings:ForkliftConnection"]));
builder.Services.AddScoped<IRepository<Forklift>, ForkliftRepository>();

using var scope = builder.Services.BuildServiceProvider().CreateScope();
var dbContext = scope.ServiceProvider.GetService<ForkliftDirectoryDbContext>();
dbContext.Database.Migrate();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();
// app.UseCookiePolicy();

app.UseRouting();
// app.UseRateLimiter();
// app.UseRequestLocalization();
app.UseCors("AllowClient");

app.UseAuthentication();
app.UseAuthorization();
// app.UseSession();
// app.UseResponseCompression();
// app.UseResponseCaching();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
