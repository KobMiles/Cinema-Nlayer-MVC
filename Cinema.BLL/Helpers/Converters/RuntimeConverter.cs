using AutoMapper;

namespace Cinema.BLL.Helpers.Converters;

public class RuntimeConverter : IValueConverter<int?, TimeSpan>
{
    public TimeSpan Convert(int? source, ResolutionContext _) =>
        TimeSpan.FromMinutes(source ?? 0);
}