namespace JwtExample.Consumers.Desktop.Application.Extensions;

public static class StringArrayExtensions
{
    public static bool AnyIsNotNullOrWhiteSpace(this string[] strings) =>
        strings.All(predicate: stroke => string.IsNullOrWhiteSpace(value: stroke) is false);
}