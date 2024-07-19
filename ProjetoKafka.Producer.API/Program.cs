using ProjetoKafka.Producer.API;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ProducerService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/", async ([FromServices] ProducerService service, [FromBody] RelatorioSolicitado relatorio) =>
{
    Relatorio Relatorio = new(relatorio.Nome);

    return await service.SendMessage(Relatorio);
});

app.Run();
