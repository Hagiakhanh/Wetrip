using Microsoft.EntityFrameworkCore.Storage;
using Wetrip.Data.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wetrip.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork,IDisposable
    {
        private readonly WeTripContext _context;
        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(WeTripContext context)
        {
            _context = context;
        }
        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
            }
        }

        public void Dispose()
        {
            _context.Dispose(); // Giải phóng tài nguyên quản lý
            GC.SuppressFinalize(this); // Garbage Collector không cần thực thi phương thức hủy nữa
                }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
            }
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
