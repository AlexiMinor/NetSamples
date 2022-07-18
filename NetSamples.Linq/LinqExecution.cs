namespace NetSamples.Linq;

public class LinqExecution
{
    private List<Person> _persons = new List<Person>()
    {
        new Person(){Name = "Bob",  Age = 10},
        new Person(){Name = "Alice",  Age = 30},
        new Employee(){Name = "Tom",  Age = 20, Company = "Hoves and Gloves"},
        new Person(){Name = "John",  Age = 30},
        new Person(){Name = "John",  Age = 35},
        //null,
        new Person(){Name = "Jacob", Age = 50 },
        new Employee(){Name = "Billy", Age = 50, Company = "MS"},
    };
    
    public void Do()
    {
        //var selectedPersons = _persons.Where(person => IsOk(person));
        
        var selectedPersons = _persons.Where(person => IsOk(person)).ToList();

        //linq execution variants:
        //deferred 
        
        //immediate for 
        // Aggregate,
        // All,
        // Any,
        // Average,
        // Contains,
        // Count,
        // ElementAt,
        // ElementAtDefault,
        // Empty,
        // First,
        // FoD,
        // Last,
        // LoD,
        // LongCount,
        // Max,
        // Min,
        // SequenceEqual,
        // Single,
        // SoD,
        // Sum,
        // To-methods
        var x = 15;

        //SomeCollectio with 1B

        var data = new List<Person>();

       
        
        data.Where(person => person.Age > 0).ToList();




        selectedPersons = selectedPersons.Where(p => p.Age >= 15).ToList();

        foreach (var person in selectedPersons)
        {
            Console.WriteLine(person.Name);
        }
    }

    private bool IsOk(Person person)
    {
        return person.Name.StartsWith("J");
    }
 
}