using API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
var app = builder.Build();




app.MapGet("/", () => "Prova Final ");

app.MapPost("/api/usuario/cadastrar", ([FromBody] Usuario usuario,
    [FromServices] AppDbContext ctx) =>
{
    ctx.usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created($"/usuario/{usuario.Id}", usuario);
});


app.MapPost("/api/imc/calcular", static ([FromBody] IMC imc,
    [FromServices] AppDbContext ctx) =>
{
    imc.ValorIMC = imc.Peso / (imc.Altura * imc.Altura);    //Calculo do IMC

    if (imc.ValorIMC < 18.5)
    {
        imc.Classificacao = "Abaixo do Peso";
    }
    else if (imc.ValorIMC >= 18.5 && imc.ValorIMC <= 24.9)
    {
        imc.Classificacao = "Peso Normal";
    }
    else if (imc.ValorIMC >= 25 && imc.ValorIMC <= 29.9)
    {
        imc.Classificacao = "Sobrepeso";
    }
    else if (imc.ValorIMC >= 30 && imc.ValorIMC <= 34.9)
    {
        imc.Classificacao = "Obesidade Grau 1";
    }
    else if (imc.ValorIMC >= 35 && imc.ValorIMC <= 39.9)
    {
        imc.Classificacao = "Obesidade Grau 2";
    }
    else
    {
        imc.Classificacao = "Obesidade Grau 3";
    }

    ctx.Set<IMC>().Add(imc);
    ctx.SaveChanges();
    return Results.Created($"/imc/{imc.Id}", imc);
});







app.Run();
