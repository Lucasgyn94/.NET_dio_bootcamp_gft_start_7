using ContatoApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// configuração da conexão com banco de dados
var stringDeConexao = builder.Configuration.GetConnectionString("ConexaoPadrao");
builder.Services.AddDbContext<AgendaContext>(options =>
{
    options.UseMySql(stringDeConexao, ServerVersion.AutoDetect(stringDeConexao));
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

//app.UseHttpsRedirection();

app.Run();

