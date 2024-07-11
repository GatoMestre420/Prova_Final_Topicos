public class IMC
{
    public int Id { get; set; }
    public required Usuario UsuarioId { get; set; }
    public double Altura { get; set; }
    public double Peso { get; set; }
    public double ValorIMC { get; set; }
    public string? Classificacao { get; set; }
}