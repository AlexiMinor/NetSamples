namespace NetSamples.Linq;

public class LinqSamples
{
    public List<Person> persons = new List<Person>()
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
  

    public void Projection()
    {
        //var names = new List<string>();
        //foreach (var person in persons)
        //{
        //    names.Add(person.Name);
        //}
        var personNames = persons?.Select(person => person?.Name).ToList(); //null possible
        foreach (var personName in personNames)
        {
            Console.WriteLine(personName);
        }

        List<string> catsName;
            
        var someVariable = persons.Select(p 
                    => p.Cats
                        .Select(cat => cat.Name)
                        .ToList())
                .ToList(); // collection of collection(list of list)

        foreach (var catsNames in someVariable)
        {
            Console.WriteLine(catsNames);
            foreach (var name in catsNames)
            {
                Console.WriteLine(name);
            }
        }

        catsName = persons.SelectMany(person => person.Cats)//work as select with merging to one collection
            .Select(cat => cat.Name)
            .ToList(); // collection of string 

        foreach (var catName in catsName)
        {
            Console.WriteLine(catName);
        }

        var intList = new List<int>() { 1, 2, 3, 4, 5, 6 };

        var powsList = intList.Select(i => $"{i}^2 = {Math.Pow(i, 2):N1}").ToList();
        foreach (var element in powsList)
        {
            Console.WriteLine(element);
        }
    }

    public void Filtration()
    {
        var filteredPersons = persons
            .Where(p => 
                p.Name.ToUpperInvariant().StartsWith("J") 
                        || p.Age >= 30)
            .ToList();

        var filteredPersonsNames = persons
            .Select(person => person.Name)
            .Where(p => p.ToUpperInvariant().Contains("O"))
            .ToList();
     

        foreach (var filteredPerson in filteredPersons)
        {
            Console.WriteLine($"Person {filteredPerson.Name} - {filteredPerson.Age}");
        }


        //filtration by type:
        var employees = persons.OfType<Employee>().ToList();

        foreach (var employee  in employees)
        {
            Console.WriteLine($"Person {employee.Name} - {employee.Age} - {employee.Company}");
        }
        
    }

    public void OrderBy()
    {
        var sortedPersons = persons
            .OrderBy(person => person.Age)
            .ToList();

        var sortedDescPersons = persons
            .OrderByDescending(person => person.Age)
            .ToList();

        var sortedPersons2 = persons
            .OrderBy(person => person.Name)
            .ThenByDescending(person => person.Age)
            .ToList();


        //only if u rly need it
        var sortedWithComparator = persons
            .OrderBy(person => person,new PersonComparer())
            .ToList();


    }

    public void CollectionHandling()
    {
        var fruits = new List<string>() { "Apple", "PineApple", "Cherry" };
        var companies = new List<string>() { "Apple", "MS", "Asus" };

        //except
        var fruitsWithoutCompanyNames = fruits.Except(companies).ToList(); // "PineApple", "Cherry"

        //intersect 
        var fruitCompanies = fruits.Intersect(companies).ToList(); // "Apple"

        //distinct
        var numbers = new List<int>() { 1,2,3,3,4,5,5,5,6 };
        var uniqueNumbers = numbers.Distinct().ToList(); //1,2,3,4,5,6

        //concat & Union
        var concatenate = fruits.Concat(companies).ToList(); // apple will be here twice
        var union = fruits.Union(companies).ToList();

    }

    public void AggregateHandling()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };
        var result = numbers.Aggregate((x, y) => x * y); //720

        var strings = new List<string>() { "a","b","c"};
        var strResult = strings.Aggregate((x, y) => $"{x} {y}"); //a b c
        //1*2*3*4*5*6

        var count = numbers.Where(i => i % 2 == 0).Count();
        var count2 = numbers.Count(i => i % 2 == 0);

        //sum
        var numbersSum = numbers.Sum();//sum of all elements
        var ageSum = persons.Sum(p=>p.Age);

        var min = persons.Min();
        var max = persons.Max();
        var avg = persons.Average(person => person.Age);
    }

    public void GetPage(int pageNumber, int pageSize)
    {
        var firstPersonPage = persons.Take(5).ToList(); 
        var secondPersonPage = persons.Skip(5).Take(5).ToList(); //if not possible to take 5
        var lastPersonPage = persons.TakeLast(5).ToList();

        var someData = persons.TakeWhile(person => !person.Name.StartsWith("J")).ToList();
        var someData2 = persons.SkipWhile(person => !person.Name.StartsWith("J")).ToList();

        //pagination algorithm

        var pageData = persons.Skip((pageNumber - 1) * pageSize).Take(pageSize);

    }

    public void Group()
    {
        var employees = new List<Employee>()
        {
            new Employee() { Name = "Bob", Age = 20, Company = "Microsoft" },
            new Employee() { Name = "Tim", Age = 30, Company = "Apple" },
            new Employee() { Name = "Alice", Age = 40, Company = "Microsoft" },
            new Employee() { Name = "Bill", Age = 70, Company = "Apple" },
            new Employee() { Name = "John", Age = 22, Company = "Microsoft" },
        };

        var employeeGroups = employees.GroupBy(employee => employee.Company);

      
        var keys = employeeGroups.FirstOrDefault();

        var companies = employeeGroups
            .ToDictionary(group => 
                    group.Key, 
                    group 
                        => group.ToList());

    }

    public void CheckIsContain()
    {
        var numbers = new List<int>() { 1, 2, 3, 4, 5, 6 };

        var isAllElementsPositive = numbers.All(i => i >= 0);
        var isAnyElementsPositive = numbers.Any(i => i >= 0);

        if (numbers.Any())
        {
            //some logic here
        }

        var isContains = numbers.Where(i => i>0).Contains(5);
        if (isContains)
        {
            var firstElement3 = numbers.First(i => i == 5);

        }


        var firstElement1 = numbers.FirstOrDefault(); 
        var firstElement4 = numbers.FirstOrDefault(i=>i ==3);

        var firstElement2 = numbers.First();


        var lastElement = numbers.LastOrDefault();
        var lastElement2 = numbers.LastOrDefault(i => i == 3);

        //just know that method contains. 
        //Check that only one match 
        var singleElement = numbers.SingleOrDefault();
        var singleElement2 = numbers.SingleOrDefault(i => i != 3);
    }
}