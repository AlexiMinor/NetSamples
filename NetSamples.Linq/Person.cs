namespace NetSamples.Linq;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }

    public List<Cat> Cats = new List<Cat>()
    {
        new Cat(){Name = "Cat-Bob"},
        new Cat(){Name = "Cat-Alice"},
        new Cat(){Name = "Cat-Tom"},
        new Cat(){Name = "Cat-John"},
        new Cat(){Name = "Cat-Jacob"},
    };
}