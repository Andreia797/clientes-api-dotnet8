using System.ComponentModel.DataAnnotations;

namespace ClientesApi.DTOs;

public class AtualizarSaldoRequest
{
    [Range(0, double.MaxValue,
    ErrorMessage = "O saldo não pode ser negativo.")]
    public decimal Saldo { get; set; }
}