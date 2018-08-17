using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using PaymentGateway.Domain.Interfaces.Repositories;
using PaymentGateway.Infrastructure.Data;

namespace PaymentGateway.Infrastructure.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {

        private readonly PaymentGatewayContext _dbContext;


        public Repository(PaymentGatewayContext dbContext)
        {
            _dbContext = dbContext;
        }

        public TEntity Add(TEntity obj)
        {
            var entidade = _dbContext.Set<TEntity>().Add(obj).Entity;
            _dbContext.SaveChanges();
            return entidade;
        }

        public void Update(TEntity obj)
        {
            _dbContext.Entry(obj).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        public void Delete(TEntity obj)
        {
            _dbContext.Set<TEntity>().Remove(obj);
            _dbContext.SaveChanges();
        }

        public TEntity GetById(int id)
        {
            return _dbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> Search(Func<TEntity, bool> expr = null, params string[] navigation)
        {
            var query = _dbContext.Set<TEntity>().IncludeMultiple(navigation);
            if (expr != null)
                return query.Where(expr);
            else
                return query;
        }

    }

    internal static class EntityDataAccessExtensions
    {
        internal static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,
            params string[] includes) where T : class
        {
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            return query;
        }
    }

}
