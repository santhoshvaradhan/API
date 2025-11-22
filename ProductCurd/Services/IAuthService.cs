using Azure;
using ProductAPI.Models;

namespace ProductAPI.Services
{
    public interface IAuthService
    {
        ResponseBuilder GetUser(Login login);
    }
}
