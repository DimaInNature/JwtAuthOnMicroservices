namespace JwtExample.Consumers.Desktop.Application.Extensions;

public static class StringArrayExtensions
{
    public static bool AllIsNotNullOrWhiteSpace(this string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke) is false);
}