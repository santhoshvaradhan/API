using ProductAPI.Data;
using ProductAPI.Models;

namespace ProductAPI.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ProductDbContext _dbContext;
        public AuthRepository(ProductDbContext productDbContext) 
        { 
            _dbContext = productDbContext;
        }


        public User GetUser(Login login)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == login.UserName && u.Password == login.Password);
            return user;
        }

    }
}
