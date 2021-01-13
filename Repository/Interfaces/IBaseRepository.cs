using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TractionTools.Models;

namespace TractionTools.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class, BaseModel
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
    }
}

