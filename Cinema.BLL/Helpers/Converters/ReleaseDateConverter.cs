using System.Globalization;
using AutoMapper;

namespace Cinema.BLL.Helpers.Converters;


public class ReleaseDateConverter : IValueConverter<string?, DateTime?>
{
    private static readonly string[] Formats = ["yyyy-MM-dd"];
    public DateTime? Convert(string? source, ResolutionContext _)
    {
        if (string.IsNullOrWhiteSpace(source)) return null;
        return DateTime.TryParseExact(source, Formats, CultureInfo.InvariantCulture,
            DateTimeStyles.None, out var dt)
            ? dt : null;
    }
}