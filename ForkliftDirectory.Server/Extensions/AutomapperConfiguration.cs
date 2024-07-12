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
                        .ForMember(fim => fim.LastEndTime, opt => opt.MapFrom(f => GetLastTime(f)))
                        .ForMember(fim => fim.UserName, opt => opt.MapFrom(f => f.User.UserName));

                    autoMapperConfig.CreateMap<ForkliftInsertModel, Forklift>();
                    //.ForMember(f => f.Active, opt => opt.MapFrom(fim => fim.Active.ToString()));

                    autoMapperConfig.CreateMap<ForkliftUpdateModel, Forklift>();

                    autoMapperConfig.CreateMap<Malfunction, MalfunctionIndexModel>()
                        .ForMember(mim => mim.StartTime, opts => opts.MapFrom(m => m.StartTime.ToString()))
                        .ForMember(mim => mim.EndTime, opts => opts.MapFrom(m => m.EndTime.ToString()));
                });

                return config.CreateMapper();
            });
        }

        private static string? GetLastTime(Forklift forklift)
        {
            var maxStartTime = forklift?.Malfunctions?.Max(x => x.EndTime) ?? null;
            var maxEndTime = forklift?.Malfunctions?.Max(x => x.EndTime) ?? null;

            var maxTime = new[] { maxStartTime, maxEndTime }.Max().ToString();

            return maxTime;
        }
    }
}
