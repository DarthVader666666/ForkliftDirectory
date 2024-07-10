using AutoMapper;
using ForkliftDirectory.Server.Entities;
using ForkliftDirectory.Server.Models;

namespace ForkliftDirectory.Server.Extensions
{
    public static class AutomapperConfiguration
    {
        public static void ConfigureAutomapper(this IServiceCollection services)
        {
            services.AddSingleton(provider =>
            {
                var config = new MapperConfiguration(autoMapperConfig =>
                {
                    autoMapperConfig.CreateMap<Forklift, ForkliftIndexModel>()
                        .ForMember(fim => fim.LastEndTime, opt => opt.MapFrom(f => 
                            new[] { f.Malfunctions.Max(x => x.EndTime), f.Malfunctions.Max(x => x.EndTime) }.Max()))
                        .ForMember(fim => fim.UserName, opt => opt.MapFrom(f => f.User.UserName));
                });

                return config.CreateMapper();
            });
        }
    }

}
