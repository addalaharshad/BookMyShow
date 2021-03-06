using BookMyShow_BE;
using BookMyShow_BE.Models;
using BookMyShow_BE.Profiles;
using BookMyShow_BE.Services;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200/").AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                      });
});
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();

builder.Services.AddScoped<BookMyShowContext,BookMyShowContext>();
builder.Services.AddTransient<IAddShows, AddShow>();
builder.Services.AddTransient<ITheaters, Theater>();
builder.Services.AddTransient<IMovies,Movie>();
builder.Services.AddTransient<ITickets, Tickets>();
builder.Services.AddTransient<IHelper, Helper>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
