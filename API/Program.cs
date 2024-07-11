using API.models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Prova Final ");

//Cadastrar, Listar, Consultar, Atualizar e Deletar
//Usuario

app.MapPost("/api/usuario/cadastrar", ([FromBody] Usuario usuario,
    [FromServices] AppDbContext ctx) =>
{
    ctx.usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created($"/{usuario.Id}", usuario);
});








app.Run();
