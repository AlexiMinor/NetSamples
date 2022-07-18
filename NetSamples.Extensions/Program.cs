namespace NetSamples.Extensions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int>() {1,2,3,4,5,6};

            string str = "";

            var isStrEmpty = str.IsEmpty();


            var realizer = new InterfaceRealizator();
            realizer.Do();
        }
    }
}