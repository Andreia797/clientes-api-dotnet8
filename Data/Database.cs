using ClientesApi.Models;

namespace ClientesApi.Data;


public static class Database
{
    public static List<Cliente> Clientes { get; } = new()
    {
        new Cliente
        {
            Id = 1,
            Nome = "Paulo Silva",
            Email ="paulo@gmail.com",
            Saldo = 1500m

        },

        new Cliente
        {
            Id = 2,
            Nome = "Maria Tavares",
            Email = "maria@gmail.com",
            Saldo = 800m
        },

        new Cliente
        {
            Id = 3,
            Nome = "Lucas Pereira",
            Email = "lucas@gmail.com",
            Saldo = 1200m
        }
    };
}