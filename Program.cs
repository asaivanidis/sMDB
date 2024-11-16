using Microsoft.EntityFrameworkCore;
using SMDb.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding the MovieDBContext
builder.Services.AddDbContext<MovieDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieDatabase")));


// Allow cross-origin requests (for local development)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:3000", "https://smdb.saiva.space") // React app origin
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Define port 5000 for http only
builder.WebHost.UseUrls("http://0.0.0.0:5000");


var app = builder.Build();

// Setup default mapping for testing
app.MapGet("/", () => "Hello, World!");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowReactApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
