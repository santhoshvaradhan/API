using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public interface IAuthRepository
    {
         User GetUser(Login login);
    }
}
