using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Services
{
    public interface ILoginRepository
    {
        Task<int> LoginAsync(string userName, string password);
    }
}
