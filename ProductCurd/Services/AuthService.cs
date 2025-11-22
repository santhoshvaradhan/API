using ProductAPI.Models;
using ProductAPI.Repositories;

namespace ProductAPI.Services
{
    public class AuthService:IAuthService
    {
        private readonly IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public ResponseBuilder GetUser(Login login)
        {
            var user = _authRepository.GetUser(login);
            string getToken = TokenService.CreateToken(user);

            return new ResponseBuilder() { UserName = user.UserName, Token = getToken };


        }
    }
}
