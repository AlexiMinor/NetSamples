namespace NetSamples.Linq;

public class PersonComparer : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (ReferenceEquals(x, y)) return 0;
        if (ReferenceEquals(null, y)) return 1;
        if (ReferenceEquals(null, x)) return -1;
        var nameComparison = string.Compare(x.Name, y.Name, StringComparison.Ordinal);
        if (nameComparison != 0) return nameComparison;
        return x.Age.CompareTo(y.Age);
        return x.Age.CompareTo(y.Age);
    }
}