using System.ComponentModel.DataAnnotations;

namespace ClientesApi.DTOs;

public class TransferenciaRequest
{
    [Required(ErrorMessage = "O Id do cliente destino é obrigatório.")]
    public int IdDestino { get; set; }

    [Range(0.01, double.MaxValue,
    ErrorMessage = "O valor deve ser maior que zero (0).")]
    public decimal Valor { get; set; }
}