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

                    autoMapperConfig.CreateMap<ForkliftUpdateModel, Forklift>();

                    autoMapperConfig.CreateMap<Malfunction, MalfunctionIndexModel>()
                        .ForMember(mim => mim.Number, opts => opts.MapFrom(m => m.Forklift.Number))
                        .ForMember(mim => mim.StartTime, opts => opts.MapFrom(m => ((DateTime)m.StartTime).ToString("yyyy-MM-dd HH:mm")))
                        .ForMember(mim => mim.EndTime, opts => opts.MapFrom(m => ((DateTime)m.EndTime).ToString("yyyy-MM-dd HH:mm")))
                        .ForMember(mim => mim.TimeSpan, opts => opts.MapFrom(m => ConvertTimeSpanToString(m.EndTime - m.StartTime)));

                    autoMapperConfig.CreateMap<MalfunctionUpdateModel, Malfunction>()
                        .ForMember(m => m.StartTime, opts => opts.MapFrom(mim => mim.StartTime != null
                            ? (DateTime?)DateTime.SpecifyKind((DateTime)mim.StartTime!, DateTimeKind.Utc)
                            : null))
                        .ForMember(m => m.EndTime, opts => opts.MapFrom(mim => mim.EndTime != null
                            ? (DateTime?)DateTime.SpecifyKind((DateTime)mim.EndTime!, DateTimeKind.Utc)
                            : null));

                    autoMapperConfig.CreateMap<MalfunctionInsertModel, Malfunction>()
                        .ForMember(m => m.StartTime, opts => opts.MapFrom(mim => DateTime.SpecifyKind((DateTime)mim.StartTime!, DateTimeKind.Utc)))
                        .ForMember(m => m.EndTime, opts => opts.MapFrom(mim => mim.EndTime != null 
                            ? (DateTime?)DateTime.SpecifyKind((DateTime)mim.EndTime!, DateTimeKind.Utc) 
                            : null))
                        .ForMember(m => m.TimeSpan, opts => opts.MapFrom(mim => mim.EndTime != null 
                            ? ((TimeSpan)(mim.EndTime - mim.StartTime!)).ToString()
                            : null));
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

        private static string? ConvertTimeSpanToString(TimeSpan? timeSpan)
        {
            if (timeSpan == null)
            {
                return null;
            }

            var time = (TimeSpan)timeSpan;

            return $"{time.Days * 24 + time.Hours}ч {time.Minutes}мин";
        }
    }
}
