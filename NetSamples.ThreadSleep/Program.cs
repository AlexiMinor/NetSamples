namespace NetSamples.ThreadSleep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var date = DateTime.Now;
            Console.WriteLine(date.ToString("R"));

            //Thread.Sleep(5000);

            var date2 = DateTime.Now.AddDays(11).AddMonths(2);
            Console.WriteLine(date2.ToString("R"));

            var deltaDate = date2 - date;
            Console.WriteLine(deltaDate);
        }
    }
}