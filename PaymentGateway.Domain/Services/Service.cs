using System;
using System.Collections.Generic;
using System.Text;
using PaymentGateway.Domain.Interfaces.Services;
using PaymentGateway.Domain.Interfaces.Repositories;

namespace PaymentGateway.Domain.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {

        private readonly IRepository<TEntity> Repository;

        public Service(IRepository<TEntity> repositorio)
        {
            Repository = repositorio;
        }

        public TEntity Add(TEntity obj)
        {
            return Repository.Add(obj);
        }

        public void Update(TEntity obj)
        {
            Repository.Update(obj);
        }

        public void Delete(TEntity obj)
        {
            Repository.Delete(obj);
        }

        public TEntity GetById(int id)
        {
            return Repository.GetById(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public IEnumerable<TEntity> Search(Func<TEntity, bool> expr, string[] navigation)
        {
            return Repository.Search(expr, navigation);
        }

    }
}
