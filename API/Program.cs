using API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();

Usuario usuario = new();

usuario.Imc = usuario.Peso / (usuario.Altura * usuario.Altura);

app.MapGet("/", () => "Prova Final ");



app.MapPost("/api/usuario/cadastrar", ([FromBody] Usuario usuario,
    [FromServices] AppDbContext ctx) =>
{
    ctx.usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created($"/usuario/{usuario.Id}", usuario);
});

string imcMessage = "";

if (usuario.Imc < 18.5)
{
    double imcValue = usuario.Imc;
    imcMessage = "Abaixo do peso";
}
if (usuario.Imc >= 18.5 && usuario.Imc < 24.9)
{
    double imcValue = usuario.Imc;
    imcMessage = "Peso normal";
}
if (usuario.Imc >= 25 && usuario.Imc < 29.9)
{
    double imcValue = usuario.Imc;
    imcMessage = "Sobrepeso";
}
if (usuario.Imc >= 30 && usuario.Imc < 34.9)
{
    double imcValue = usuario.Imc;
    imcMessage = "Obesidade grau 1";
}
if (usuario.Imc >= 35 && usuario.Imc < 39.9)
{
    double imcValue = usuario.Imc;
    imcMessage = "Obesidade grau 2";
}
if (usuario.Imc >= 40)
{
    double imcValue = usuario.Imc;
    imcMessage = "Obesidade grau 3";
}

Console.WriteLine(imcMessage);










app.Run();
