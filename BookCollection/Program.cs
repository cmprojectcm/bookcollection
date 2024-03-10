using BookCollection.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Both InMemory and SqlServer can be enabled, just comment and uncomment what you need
//builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase(builder.Configuration.GetValue<string>("MemoryConnectionString")));
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetValue<string>("DbConnectionString")));

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder =>
        {
            builder
            .WithOrigins("http://localhost:4200") //Specify here the FrontEnd Origin Url to use
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
        });
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.DisplayRequestDuration());
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowSpecificOrigin");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
