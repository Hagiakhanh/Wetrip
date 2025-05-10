using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Wetrip.Data.GenericRepository;

namespace Wetrip.Data.IRepositories
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
    }
}
