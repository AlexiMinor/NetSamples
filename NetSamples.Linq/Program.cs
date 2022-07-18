using System.Linq;
using System.Linq.Expressions;

namespace NetSamples.Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var le = new LinqExecution();
            le.Do();
           
            var linqSamples = new LinqSamples();
            linqSamples.CollectionHandling();


            // LINQ - Language-Integrated Query. Implemented as some amount extension methods

            // Types of LINQ:
            // LINQ to Objects - when u work with collections
            // Linq to Entities - when u work with EntityFramework 
            // Linq to XML
            // Linq to DataSet 
            // PLinq - Parallel LINQ 


            var list = new List<string>() { "Bob", "Alice", "Tom", "John", "Jacob"};

            //trying to get all names start with "J" and print as sorted alphabetically list
            var jList = new List<string>();

            foreach (var name in list)
            {
                if (name.ToUpperInvariant().StartsWith("J"))
                {
                    jList.Add(name);
                }
            }

            jList.Sort();

            foreach (var name in jList)
            {
                Console.WriteLine(name);
            }

            //LINQ implementation

            //sql-like syntax 
            Console.WriteLine("LINQ implementations:");
            Console.WriteLine("sql-like syntax");
            var selectedJList = 
                from name in list
                where name.ToUpperInvariant().StartsWith("J") 
                orderby name
                select name;

            foreach (var name in selectedJList)
            {
                Console.WriteLine(name);
            }

            //lambda syntax
            Console.WriteLine("lambda syntax");

            var selectedJNames = list
                .Where(n => n.ToUpperInvariant().StartsWith("J"))
                .OrderBy(n => n)
                .ToList();

            foreach (var name in selectedJNames)
            {
                Console.WriteLine(name);
            }
      


        }
    }
}