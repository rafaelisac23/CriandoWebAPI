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

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");


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
