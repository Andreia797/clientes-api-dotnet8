using System.Reflection.Metadata.Ecma335;
using ClienteApi.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]

    public IActionResult ObterTodos()
    {
        var clientes = _clienteService.ObterTodos();
        return Ok(clientes);
    }
}