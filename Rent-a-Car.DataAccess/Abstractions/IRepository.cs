using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rent_a_Car.DataAccess.Abstractions
{
    public interface IRepository<TEntity> where TEntity : class
    {
        bool Insert(TEntity entity);
        bool Update(TEntity entity);
        bool DeleteById(int id);
        TEntity SelectById(int id);
        IList<TEntity> SelectAll();
    }
}
