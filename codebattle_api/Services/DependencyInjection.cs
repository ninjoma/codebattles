
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Repositories;

namespace codebattle_api.Services
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection collection)
        {
            // collection.AddTransient<IUserService, UserService>(); TEMPLATE
            collection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
        }
    }
}