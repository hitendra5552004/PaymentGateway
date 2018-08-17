using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaymentGateway.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Add(TEntity obj);
        TEntity GetById(int id);
        IEnumerable<TEntity> Search(Func<TEntity, bool> expr = null, params string[] navigation);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Delete(TEntity obj);
    }
}
