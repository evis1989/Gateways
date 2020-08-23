using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace Gateways.Insfastructure.AppContext
{
    public interface IDbContext
    {
        DbContext BaseDbContext { get; }
        DbSet<T> Set<T>() where T : class;
        Task<bool> SaveChangesAsync();
    }
}
