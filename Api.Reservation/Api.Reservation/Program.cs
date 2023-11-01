using Api.Reservation.Business.Service;
using Api.Reservation.Datas.Context;
using Api.Reservation.Datas.Repository;
using Microsoft.EntityFrameworkCore;
using Refit;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddRefitClient<IFlightsApi>()
          .ConfigureHttpClient(c => c.BaseAddress = new Uri(configuration.GetSection("Services:FlightApi").Value));

// Database link
builder.Services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
       options.UseSqlite(configuration.GetConnectionString("DefaultConnection"),
       b => b.MigrationsAssembly("Api.Reservation")));

builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();

builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IUtilisateurService, UtilisateurService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();


app.Run();
