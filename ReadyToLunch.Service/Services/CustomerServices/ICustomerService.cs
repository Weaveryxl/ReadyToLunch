using ReadyToLunch.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.CustomerServices
{
    public interface ICustomerService
    {
        //Get record By name
        Customer GetByName(string name);
    }
}
