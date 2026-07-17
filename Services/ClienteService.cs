using ClientesApi.Data;
using ClientesApi.Models;
using ClientesApi.DTOs;
using ClientesApi.Results;


namespace ClienteApi.Services;

public class ClienteService
{
    public List<Cliente> ObterTodos()
    {
        return Database.Clientes;
    }
    public Cliente? ObterPorId(int id)
    {
        return Database.Clientes.FirstOrDefault(c => c.Id == id);
    }

    public Cliente Criar(ClienteCreateRequest request)
    {
        int novoId = Database.Clientes.Any()
            ? Database.Clientes.Max(c => c.Id) + 1
            : 1;

        var cliente = new Cliente
        {
            Id = novoId,
            Nome = request.Nome,
            Email = request.Email,
            Saldo = request.Saldo
        };

        Database.Clientes.Add(cliente);

        return cliente;
    }

    public Cliente? AtualizarSaldo(int id, AtualizarSaldoRequest request)
    {
        var cliente = Database.Clientes
        .FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return null;

        cliente.Saldo = request.Saldo;

        return cliente;
    }

    public TransferenciaResult Transferir(
     int idOrigem,
     TransferenciaRequest request)
    {
        var origem = Database.Clientes
            .FirstOrDefault(c => c.Id == idOrigem);

        if (origem == null)
        {
            return new TransferenciaResult
            {
                Resultado = ResultadoTransferencia.OrigemNaoEncontrada
            };
        }

        var destino = Database.Clientes
            .FirstOrDefault(c => c.Id == request.IdDestino);

        if (destino == null)
        {
            return new TransferenciaResult
            {
                Resultado = ResultadoTransferencia.DestinoNaoEncontrado
            };
        }

        if (origem.Saldo < request.Valor)
        {
            return new TransferenciaResult
            {
                Resultado = ResultadoTransferencia.SaldoInsuficiente
            };
        }

        origem.Saldo -= request.Valor;

        destino.Saldo += request.Valor;

        return new TransferenciaResult
        {
            Resultado = ResultadoTransferencia.Sucesso,
            Origem = origem,
            Destino = destino
        };
    }
}