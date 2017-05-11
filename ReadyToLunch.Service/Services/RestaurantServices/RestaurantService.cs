using ReadyToLunch.Service.Repositories;
using ReadyToLunch.Service.Services.RestaurantServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ReadyToLunch.Model.Models;
using ReadyToLunch.Data;


namespace ReadyToLunch.Service.Services.RestaurantServices
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepo _RestaurantRepo;

        //public RestaurantService(LunchContext context)
        //{
        //    _RestaurantRepo = new RestaurantRepo(context, context.Restaurants);
        //}

        public RestaurantService(IRestaurantRepo Repo)
        {
            _RestaurantRepo = Repo;
        }

        public void Create(Restaurant entity)
        {
            _RestaurantRepo.Add(entity);
        }

        public void Delete(Restaurant entity)
        {
            _RestaurantRepo.Delete(entity);
        }

        public IEnumerable<Restaurant> GetAll(Expression<Func<Restaurant, bool>> where = null)
        {
            var res = where == null
                ? _RestaurantRepo.GetAll()
                : _RestaurantRepo.GetAll().AsQueryable().Where(where);
            return res;
        }

        public Restaurant GetByID(int? id)
        {
            return _RestaurantRepo.GetByID(id);
        }

        public Restaurant GetByName(string name)
        {
            return _RestaurantRepo.GetByName(name);
        }
    }
}
