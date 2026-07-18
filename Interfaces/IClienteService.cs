using ClientesApi.DTOs;
using ClientesApi.Models;
using ClientesApi.Results;

namespace ClientesApi.Interfaces;

public interface IClienteService
{
    List<Cliente> ObterTodos();

    Cliente? ObterPorId(int id);

    Cliente Criar(ClienteCreateRequest request);

    Cliente? AtualizarSaldo(int id, AtualizarSaldoRequest request);

    TransferenciaResult Transferir(
        int idOrigem,
        TransferenciaRequest request);
}