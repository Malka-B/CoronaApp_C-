using CoronaApp.Services.Models;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public async Task<int> LoginAsync(string username, string password)
        {
            return await _loginRepository.LoginAsync(username, password);
        }
    }
}
