namespace NetSamples.AsyncExecution
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var asyncSample = new AsyncSamples();

            //var list = new List<int>();
            await asyncSample.DoAsync();

            //var task = asyncSample.DoAsync();
            //task.Start();
            //list.FirstOrDefault( i => i == task.Result);
        }

    }
}