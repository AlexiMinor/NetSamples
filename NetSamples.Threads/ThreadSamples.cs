namespace NetSamples.Threads;

public class ThreadSamples
{
    public void CreateThreads()
    {
        var th1 = new Thread(PrintData)
        {
            Name = "PrintDataThread"
        };

        var th2 = new Thread(() =>
            {
                var currentThreadName = Thread.CurrentThread.Name;
                for (int i = 1000; i > 500; i--)
                {
                    Console.WriteLine($"{currentThreadName}-{i}");
                }
            })
        {
            Name = "LambdaThread"
        };

        th1.Start();
        th2.Start();

        var th3 = new Thread(PrintMessage);
        var th4 = new Thread(o => Console.WriteLine(o));

        th3.Start("hello");
        th4.Start("Hi");
    }

    private void PrintData()
    {
        var currentThreadName = Thread.CurrentThread.Name;
        for (int i = 0; i < 500; i++)
        {
            Console.WriteLine($"{currentThreadName}-{i}");
        }
    }

    private void PrintMessage(object message)
    {
        var currentThreadName = Thread.CurrentThread.Name;
        Console.WriteLine($"{currentThreadName} - {message}");
    }
}