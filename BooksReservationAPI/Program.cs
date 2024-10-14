using BooksReservationAPI.Data;
using BooksReservationAPI.Repositories.Interfaces;
using BooksReservationAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using BooksReservationAPI.Services.Interfaces;
using BooksReservationAPI.Services;
using BooksReservationAPI.Mappings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseInMemoryDatabase("db"));

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IReservationService, ReservationService>();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder.WithOrigins("http://localhost:5173")
                   .AllowAnyHeader()
                   .AllowAnyMethod()
                   .AllowCredentials();
        });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureDeleted();
    dbContext.Database.EnsureCreated();
}

app.UseCors("AllowReactApp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();