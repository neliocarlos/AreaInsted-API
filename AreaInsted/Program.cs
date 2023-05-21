using AreaInsted.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string conStr = builder.Configuration.GetConnectionString("AreaInstedConnection");

builder.Services.AddDbContext<AreaInstedContext>(options => options.UseSqlServer(conStr));


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Alterado pelo Programador.
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Area Insted",
        Description = "API REST utilizada para estudo e desenvolvimento do modelo de aplicações baseado em boas práticas e no modelo de maturidade de Richardson.",
        TermsOfService = new Uri("https://github.com/neliocarlos"),
        Contact = new OpenApiContact()
        {
            Name = "Nélio Carlos Diniz Peres",
            Email = "neliocarlos95@gmail.com",
        },
        License = new OpenApiLicense()
        {
            Name = "Area Insted Group.",
            Url = new Uri("https://github.com/neliocarlos"),
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    //options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

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

app.Run();
