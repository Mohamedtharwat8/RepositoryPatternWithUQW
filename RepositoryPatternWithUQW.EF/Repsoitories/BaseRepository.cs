using RepositoryPatternWithUQW.Core.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
