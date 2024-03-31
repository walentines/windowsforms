using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mpp_project.repository
{
    public interface IRepository<TId, T>
    {
        T FindOne(TId id);
        IEnumerable<T> FindAll();
        void Save(T entity);
        void Delete(TId id);
        void Update(T entity);
    }
}
