namespace Adp.Interview.Calc.Shared.Util
{
    public interface IReadOnlyStringKeyValuePairs
    {
        string this[string key]
        {
            get;
        }

        bool CanCheckContainsKey
        {
            get;
        }

        bool ContainsKey(string key);
    }
}
