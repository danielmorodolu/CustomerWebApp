using Microsoft.EntityFrameworkCore;
using ProductService.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            // Enable retry logic for SQL Server
            sqlOptions.EnableRetryOnFailure(
                maxRetryCount: 5, 
                maxRetryDelay: TimeSpan.FromSeconds(10), 
                errorNumbersToAdd: null
            );
        }
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
