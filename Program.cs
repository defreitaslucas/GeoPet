using GeoPet.Models;
using GeoPet.Services.PetCarerService;
using GeoPet.Services.PetService;
using Microsoft.EntityFrameworkCore;

var db = new GeoPetContext();
db.Database.EnsureCreated();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GeoPetContext>();
builder.Services.AddScoped<IPetCarerService, PetCarerService>();
builder.Services.AddScoped<IPetService, PetService>();
//builder.Services.AddTransient<GeoPetContext>();
//builder.Services.AddTransient<SeedData>();
var app = builder.Build();

/*if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedDataGeoPet(app);*/

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

/*void SeedDataGeoPet(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<SeedData>();
        service.Seed();
    }
}*/