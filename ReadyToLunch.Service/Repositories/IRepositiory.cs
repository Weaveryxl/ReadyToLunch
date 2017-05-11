using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories
{
    public interface IRepository<T> where T : class
    {
        // add a entity
        void Add(T entity);
        // change a entity
        void Update(T entity);
        // delete a entity by entity itself
        void Delete(T entity);// something
        // delete entities by expression
        void Delete(Expression<Func<T, bool>> where);
        // get entity by id
        T GetByID(int? id);
        // get the single record that meet the expression
        T Get(Expression<Func<T, bool>> where);
        // get all records
        IEnumerable<T> GetAll();
        // get all records that meet the expression
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
    }
}
