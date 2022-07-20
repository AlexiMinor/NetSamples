namespace NetSamples.Threads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Thread th = Thread.CurrentThread;
            //th.Priority = ThreadPriority.AboveNormal;
            //th.Name = "NetSample.Program.Main";

            //Console.WriteLine(th.Name);
            //Console.WriteLine(th.ManagedThreadId); //identifier 
            //Console.WriteLine(th.Priority);
            //Console.WriteLine(th.ThreadState);

            //var domain = Thread.GetDomain();
            //var domainId = Thread.GetDomainID();
            //var processorId = Thread.GetCurrentProcessorId();

            //var ts = new ThreadSamples();
            //ts.CreateThreads();

            //var tss = new ThreadSyncSamples();
            //tss.Do();


            for (int i = 0; i < 20; i++)
            {
                var client = new SemaphoreSample(i);
            }

        }
    }
}