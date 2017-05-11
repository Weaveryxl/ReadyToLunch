using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Repositories
{
    public interface ICustomerRepo : IRepository<Customer>
    {
        Customer GetByName(string name);
    }
}
