namespace NetSamples.Threads;

public class SemaphoreSample
{
    private static Semaphore _semaphore = new Semaphore(5,5);

    private Thread _semaphoreSampleThread;

    private int _count = 5;

    public SemaphoreSample(int id)
    {
        _semaphoreSampleThread = new Thread(GetPapers);
        _semaphoreSampleThread.Name = $"Client {id}";
        _semaphoreSampleThread.Start();
    }

    public void GetPapers()
    {
        while (_count > 0)
        {
            _semaphore.WaitOne(); //wait a possibility to go

            Console.WriteLine($"{Thread.CurrentThread.Name} go in");
            Console.WriteLine($"{Thread.CurrentThread.Name} check papers");
            Thread.Sleep(1000);

            Console.WriteLine($"{Thread.CurrentThread.Name} go out");
            _semaphore.Release();

            _count--;
            Thread.Sleep(2000);
        }
    }
}