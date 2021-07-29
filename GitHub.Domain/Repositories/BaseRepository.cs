using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GitHub.Domain.Interfaces;
using GitHub.Domain.Models;
using GitHub.Domain.Repositories.API;

namespace GitHub.Domain.Repositories
{
    public abstract class BaseRepository<T> : ApiClient, IRepository<T> where T : class
    {
        public Task<ICollection<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Add(T entity)
        {
            throw new NotImplementedException();
        }

        public Task AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public Task Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
