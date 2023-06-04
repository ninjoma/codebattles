using System.Reflection;
using AutoMapper;
using codebattle_api.DTO;
using codebattle_api.Repositories;
using codebattle_api.Services;

namespace codebattle_api.Services
{
    public static class DependencyInjection
    {

        public static void RegisterServices(this IServiceCollection collection)
        {
            // collection.AddTransient<IUserService, UserService>(); TEMPLATE

            // collection.AddScoped<IUserService, UserService>();
            collection.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));

            //Implementacion de servicios automatica
            var assembly = Assembly.GetExecutingAssembly();
            var serviceTypes = assembly.GetTypes()
                .Where(t => t.Name.EndsWith("Service") && t.GetInterfaces().Any(x => !x.Name.Contains("IMainService")) && !t.Name.Contains("MainService"));

            foreach (var type in serviceTypes)
            {
                // Obtén la interfaz que implementa la clase
                var interfaceType = type.GetInterfaces().First();

                // Agrega el servicio al contenedor de inyección de dependencias
                collection.AddScoped(interfaceType, type);
            }
        }
    }
}