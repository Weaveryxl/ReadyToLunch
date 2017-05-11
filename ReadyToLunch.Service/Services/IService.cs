using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services
{
    public interface IService<T> where T : class
    {
        //Get all records that meet the expression, if expression is not provided, return all existing records
        IEnumerable<T> GetAll(Expression<Func<T, bool>> where = null);
        //Get record By ID
        T GetByID(int? id);
        //create record 
        void Create(T entity);
        //delete record
        void Delete(T entity);
    }
}
