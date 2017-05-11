using ReadyToLunch.Model.Models;
using ReadyToLunch.Service.Repositories.DishRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadyToLunch.Service.Services.DishServices
{
    public class DishService : GenericService<Dish>, IDishService
    {
        private readonly IDishRepo _DishRepo;

        public DishService(IDishRepo Repo) : base(Repo)
        {
            _DishRepo = Repo;
        }

        public Dish GetByName(string name)
        {
            return _DishRepo.GetByName(name);
        }
    }
}
