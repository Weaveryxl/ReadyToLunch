[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(AuthenticationPractise3.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(AuthenticationPractise3.App_Start.NinjectWebCommon), "Stop")]

namespace AuthenticationPractise3.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using ReadyToLunch.Model.Models;
    using ReadyToLunch.Service.Repositories;
    using ReadyToLunch.Service.Services.RestaurantServices;
    using ReadyToLunch.Service.Services.CustomerServices;
    using ReadyToLunch.Service.Repositories.DishRepository;
    using ReadyToLunch.Service.Repositories.CartRepository;
    using ReadyToLunch.Service.Services.DishServices;
    using ReadyToLunch.Service.Services.CartServices;
    using ReadyToLunch.Service.Repositories.OrderRepository;
    using ReadyToLunch.Service.Services.OrderServices;
    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            // Repositories
            //kernel.Bind<IRepository<Restaurant>>().To<IRestaurantRepo>();
            //kernel.Bind<IRepository<Customer>>().To<ICustomerRepo>();
            //kernel.Bind<IRepository<Dish>>().To<IDishRepo>();
            //kernel.Bind<IRepository<CartItem>>().To<ICartRepo>();
            //kernel.Bind<IRepository<Order>>().To<IOrderRepo>();

            //kernel.Bind<GenericRepo<Restaurant>>().To<RestaurantRepo>();
            //kernel.Bind<GenericRepo<Customer>>().To<CustomerRepo>();
            //kernel.Bind<GenericRepo<Dish>>().To<DishRepo>();
            //kernel.Bind<GenericRepo<CartItem>>().To<CartRepo>();
            //kernel.Bind<GenericRepo<Order>>().To<OrderRepo>();

            kernel.Bind<IRestaurantRepo>().To<RestaurantRepo>();
            kernel.Bind<ICustomerRepo>().To<CustomerRepo>();
            kernel.Bind<IDishRepo>().To<DishRepo>();
            kernel.Bind<ICartRepo>().To<CartRepo>();
            kernel.Bind<IOrderRepo>().To<OrderRepo>();

            // Services
            kernel.Bind<IRestaurantService>().To<RestaurantService>();
            kernel.Bind<ICustomerService>().To<CustomerService>();
            kernel.Bind<IDishService>().To<DishService>();
            kernel.Bind<ICartService>().To<CartService>();
            kernel.Bind<IOrderService>().To<OrderService>();
        }        
    }
}
