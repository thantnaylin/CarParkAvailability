using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkAvailability.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);

        TEntity GetByEmail(string email);

        void Add(TEntity entity);
        TEntity Login(string email, string password);
    }
}
