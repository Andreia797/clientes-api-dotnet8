using System.Reflection.Metadata.Ecma335;
using ClienteApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ClientesApi.DTOs;
using ClientesApi.Results;
namespace ClientesApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientesController : ControllerBase
{
    private readonly ClienteService _clienteService;

    public ClientesController(ClienteService clienteService)
    {
        _clienteService = clienteService;
    }

    // endpoint GET /api/clientes
    [HttpGet]

    public IActionResult ObterTodos()
    {
        var clientes = _clienteService.ObterTodos();
        return Ok(clientes);
    }

    //  endpoint GET /api/clientes/{id}
    [HttpGet("{id}")]
    public IActionResult ObterPorId(int id)
    {
        var cliente = _clienteService.ObterPorId(id);
        if (cliente == null)
        {
            return NotFound(new
            {
                mensagem = "Cliente não encontrado! '-' "
            });
        }
        return Ok(cliente);
    }

    // endpoint POST /api/clientes
    [HttpPost]
    public IActionResult Criar(ClienteCreateRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cliente = _clienteService.Criar(request);

        return CreatedAtAction(
            nameof(ObterPorId),
            new { id = cliente.Id },
            cliente
        );
    }

    //endpoint PUT /api/clientes/{id}/saldo
    [HttpPut("{id}/saldo")]

    public IActionResult AtualizarSaldo(
       int id,
       AtualizarSaldoRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var cliente = _clienteService.AtualizarSaldo(id, request);

        if (cliente == null)
        {
            return NotFound(new
            {
                mensagem = "Cliente não encontrado."
            });
        }

        return Ok(cliente);
    }

    //endpoint POST /api/clientes/{idOrigem}/transferencia
     [HttpPost("{idOrigem}/transferencia")]
    public IActionResult Transferir(
      int idOrigem,
      TransferenciaRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var resultado = _clienteService.Transferir(idOrigem, request);

        switch (resultado.Resultado)
        {
            case ResultadoTransferencia.OrigemNaoEncontrada:
                return NotFound(new
                {
                    mensagem = "Cliente de origem não encontrado."
                });

            case ResultadoTransferencia.DestinoNaoEncontrado:
                return NotFound(new
                {
                    mensagem = "Cliente de destino não encontrado."
                });

            case ResultadoTransferencia.SaldoInsuficiente:
                return BadRequest(new
                {
                    mensagem = "Saldo insuficiente."
                });

            case ResultadoTransferencia.Sucesso:
                return Ok(new
                {
                    mensagem = "Transferência realizada com sucesso.",
                    origem = resultado.Origem,
                    destino = resultado.Destino
                });

            default:
                return StatusCode(500);
        }
    }
}