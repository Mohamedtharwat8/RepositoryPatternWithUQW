using RepositoryPatternWithUQW.Core;
using RepositoryPatternWithUQW.Core.interfaces;
using RepositoryPatternWithUQW.Core.Models;
using RepositoryPatternWithUQW.EF.Repsoitories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace RepositoryPatternWithUQW.EF
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IBaseRepository<Author> Authors { get; set; }

        public IBaseRepository<Book> Books { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;

            Authors = new BaseRepository<Author>(_context);
            Books = new BaseRepository<Book>(_context);
        }

        public int Complete() {
            return _context.SaveChanges();
        
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
