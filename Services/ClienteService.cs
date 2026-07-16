using ClientesApi.Data;
using ClientesApi.Models;

namespace ClienteApi.Services;

public class ClienteService
{
    public List<Cliente> ObterTodos()
    {
        return Database.Clientes;
    }
}