using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
   public interface IDataContext
    {
        DbSet<People> Person { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
