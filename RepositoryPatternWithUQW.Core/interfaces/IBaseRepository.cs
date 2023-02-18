using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPatternWithUQW.Core.interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);



    }
}
