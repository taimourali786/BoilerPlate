using BoilerPlateViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolerPlateUIShared.Services
{
    public interface IAccountService
    {
        public Task<HttpResponseMessage> Login(LoginModel login);
    }
    public class AccountService : IAccountService
    {
        public IHttpService _httpService;
        public AccountService(IHttpService httpService)
        {
            _httpService = httpService;
        }
        public async Task<HttpResponseMessage> Login(LoginModel login)
        {
            var response = await _httpService.Post("login", login);
            return response;

        }
    }
}
