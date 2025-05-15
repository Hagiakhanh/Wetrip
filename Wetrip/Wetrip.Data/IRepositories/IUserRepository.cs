using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.Entities;
using Wetrip.Data.GenericRepository;

namespace Wetrip.Data.IRepositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User> GetUserByPhone(string phone);
        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByRequestId(string requestId);
    }
}
