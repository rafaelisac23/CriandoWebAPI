using Microsoft.EntityFrameworkCore;
using WebApiCatalogo.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

/*Pra voce fazer a conexão com o banco tambem precisa lançar o codigo para fazer conexão com o banco 
 * Exemplo: 
 * string mySqlConnection = builder.Configuration.GetConnectionString("nome da variavel que voce colocou no appsettings.json")
 */

//string de conexão
string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

// faz parte tambem !!!!

builder.Services.AddDbContext<WebApiCatalogoContext>(options => options.UseMySql(mySqlConnection,
    ServerVersion.AutoDetect(mySqlConnection)));



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
