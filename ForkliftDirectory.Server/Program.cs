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

string? connectionString = builder.Configuration["ConnectionStrings:ForkliftConnection"];

if (connectionString == null)
{
    builder.Services.AddDbContext<ForkliftDirectoryDbContext>(options => options.UseInMemoryDatabase("InMemoryDb"));
}
else
{
    builder.Services.AddDbContext<ForkliftDirectoryDbContext>(opts => opts.UseNpgsql(connectionString));
}

builder.Services.AddScoped<IRepository<Forklift>, ForkliftRepository>();
builder.Services.AddScoped<IRepository<Malfunction>, MalfunctionRepository>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ForkliftDirectoryDbContext>();

    if (connectionString == null)
    {
        await dbContext.SeedDatabase();
    }
    else
    {
        dbContext.Database.Migrate();
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("AllowClient");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
