using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services.Models
{
    public interface ILoginService
    {
        Task<int> LoginAsync(string username, string password);
    }
}
