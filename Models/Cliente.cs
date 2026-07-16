namespace ClientesApi.Models;

//Classe Cliente
public class Cliente
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public decimal Saldo { get; set; }
}
