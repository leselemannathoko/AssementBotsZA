using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Repositories
{
    public interface IPersonRepository
    {
        Task<People> Get(int id);
        Task<IEnumerable<People>> GetAll();
        Task Add(People people);
        Task Delete(int id);
        Task update(People people);
    }
}
