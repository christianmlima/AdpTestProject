namespace Adp.Interview.Calc.Shared.ApiUtilities
{
    public static class ResponseStatusExtensions
    {
        public static bool Succeeded(this ResponseStatus @this)
        {
            return @this == ResponseStatus.OK || @this == ResponseStatus.Created || @this == ResponseStatus.Accepted || @this == ResponseStatus.NoContent;
        }
    }
}
