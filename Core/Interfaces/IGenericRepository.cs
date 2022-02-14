using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {

        Task<T> GetByIdAsync(int id);

        Task<IReadOnlyList<T>> GetAllAsync();

    }
}
