using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wetrip.Data.DBContext;
using Wetrip.Data.Entities;
using Wetrip.Data.GenericRepository;
using Wetrip.Data.IRepositories;

namespace Wetrip.Data.Repositories
{
    public class TemporaryGroupMessageMediumRepository : GenericRepository<TemporaryGroupMessageMedium>, ITemporaryGroupMessageMediumRepository
    {
        public TemporaryGroupMessageMediumRepository(WeTripContext context) : base(context)
        {
        }
    }
}
