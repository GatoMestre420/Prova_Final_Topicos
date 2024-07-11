using API.models;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Prova Final ");

app.MapPost("/api/usuario/cadastrar", ([FromBody] Usuario usuario,
    [FromServices] AppDbContext ctx) =>
{
    ctx.usuarios.Add(usuario);
    ctx.SaveChanges();
    return Results.Created($"/produto/{usuario.Id}", usuario);
});



app.Run();
