/******************************************/
using ApiUser.DbContexts;
using ApiUser.Repository;
using Microsoft.EntityFrameworkCore;
/******************************************/

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/******************************************/
// dependency injection IUserRepository
builder.Services.AddScoped<IUserRepository, UserSQLRepository>();
// configure the connection string
var connectionString = builder.Configuration.GetConnectionString("UserDB");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
// Cors configuration
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyAllowedOrigins",
        policy =>
        {
            // dont forget to add http or https
            policy.WithOrigins("http://localhost:4200") // note the port is included 
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
/******************************************/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

/**************/
// Extra line for CORS after build
app.UseCors("MyAllowedOrigins");
/**************/

app.Run();
