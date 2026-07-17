using ClientesApi.Models; 

namespace ClientesApi.Results; 

public class TransferenciaResult 
{ 
public ResultadoTransferencia Resultado { get; set; } 
public Cliente? Origem { get; set; } 
public Cliente? Destino { get; set; } 
} 
