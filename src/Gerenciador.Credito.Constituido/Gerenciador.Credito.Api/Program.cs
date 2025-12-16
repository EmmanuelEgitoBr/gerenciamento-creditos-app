using Gerenciador.Credito.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddDatabaseConfiguration();
builder.AddMediatRConfiguration();
builder.AddFluentValidationConfiguration();
builder.AddRepositoriesConfiguration();
builder.AddHealthChecksConfiguration();

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

app.MapGet("/self", () => Results.Ok("UP"));
app.MapGet("/ready", () => Results.Ok("READY"));

app.Run();
