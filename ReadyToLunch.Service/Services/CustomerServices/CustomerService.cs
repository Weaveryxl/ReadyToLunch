using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Repositories; // shall I change the namespace of Customer and Restaurant?
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.CustomerServices
{
    public class CustomerService : GenericService<Customer>, ICustomerService
    {
        private readonly ICustomerRepo _CustomerRepo;

        public CustomerService(ICustomerRepo Repo) : base(Repo)
        {
            _CustomerRepo = Repo;
        }

        public Customer GetByName(string name)
        {
            return _CustomerRepo.GetByName(name);
        }
    }
}
