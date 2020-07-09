using CoronaApp.Services;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CoronaApp.Dal
{
    public class LoginRepository : ILoginRepository
    {
        CoronaContext _coronaContext;

        public LoginRepository(CoronaContext coronaContext)
        {
            _coronaContext = coronaContext;
        }

        public async Task<int> LoginAsync(string userName, string password)
        {
            Patient p = await _coronaContext.Patient                                            
                                            .FirstOrDefaultAsync(p => p.UserName == userName
                                            && p.Password == password);
            return p.Id;
        }
    }
}
