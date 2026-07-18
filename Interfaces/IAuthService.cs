using ClientesApi.DTOs;

namespace ClientesApi.Interfaces;

public interface IAuthService
{
    string? Login(LoginRequest request);
}