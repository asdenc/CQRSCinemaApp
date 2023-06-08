using CinemaApp.Bookings.Contract;
using CinemaApp.Bookings.Services;
using CinemaApp.Customer.Contract;
using CinemaApp.Customer.Services;
using CinemaApp.Movies.Contract;
using CinemaApp.Movies.Services;
using CinemaApp.Screen.Contract;
using CinemaApp.Screen.Services;
using CinemaAppInfra;
using CQRSCinemaApp.Controllers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IBookingService, BookingService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IMoviesService, MoviesService>();
builder.Services.AddScoped<IScreenService, ScreenService>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddControllers()
    .AddApplicationPart(typeof(MoviesController).Assembly)
    .AddApplicationPart(typeof(CustomerController).Assembly)
    .AddApplicationPart(typeof(ScreenController).Assembly)
    .AddApplicationPart(typeof(BookingController).Assembly);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
