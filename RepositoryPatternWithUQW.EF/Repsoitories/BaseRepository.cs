using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUQW.Core.Consts;
using RepositoryPatternWithUQW.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUQW.EF.Repsoitories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext _context;

        public BaseRepository(ApplicationDbContext ccontext)
        {
            _context = ccontext;
        }
        public T Add(T Entity)
        {
            _context.Set<T>().Add(Entity);
            _context.SaveChanges();
            return Entity;

        }
        public IEnumerable<T> AddRange(IEnumerable<T> Entities)
        {
            _context.Set<T>().AddRange(Entities);
            _context.SaveChanges();
            return Entities;
        }

        public T Find(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes !=null)
            {foreach(var incluse in includes)
                {
                    query = query.Include(incluse);
                }

            }
            return query.SingleOrDefault(match);
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();
            if (includes != null)
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

            }
            return query.Where(match).ToList();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int take, int skip)
        {
             
            return _context.Set<T>().Where(match).Skip(skip).Take(take).Where(match).ToList();
        }

        //public IEnumerable<T> FindAll(
        //    Expression<Func<T, bool>> match, int? take, int? skip, Expression<Func<T, bool>> 
        //    orderBy = null, string orderByDirection = OrderBy.Ascending)
        //{
        //    IQueryable<T> query = _context.Set<T>().Where(match);

        //    if (take.HasValue)
        //    {
        //        query = query.Take(take.Value);
        //    }

        //    if (skip.HasValue)
        //    {
        //        query = query.Take(skip.Value);
        //    }

        //    if (orderBy != null)
        //    {

        //        if(orderByDirection == OrderBy.Ascending)
        //            query = query.OrderBy(orderBy);
        //        else
                
        //            query = query.OrderByDescending(orderBy);

        //    }

        //    return query.ToList();
        //}

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> match, int? take, int? skip, Expression<Func<T, object>> orderBy = null, string orderByDirection = "ASC")
        {
            IQueryable<T> query = _context.Set<T>().Where(match);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            if (skip.HasValue)
            {
                query = query.Take(skip.Value);
            }

            if (orderBy != null)
            {

                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else

                    query = query.OrderByDescending(orderBy);

            }

            return query.ToList();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
    }
}
