namespace NetSamples.Threads;

public class ThreadSyncSamples
{
    private int _x = 0;

    private object _locker = new object();
    private Mutex _mutex = new Mutex();

    private AutoResetEvent _waitHandler = new AutoResetEvent(true);

    public void Do()
    {
        for (var i = 0; i < 3; i++)
        {
            var th = new Thread(DoSmthWithLock)
            {
                Name = $"Thread {i}"
            };
            th.Start();
        }

    }

    private void DoSmthWithLock()
    {
        Console.WriteLine("AAA");

        lock (_locker)
        {
            _x = 0;
            for (var i = 1; i < 15; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(200);
            }
        }

        Console.WriteLine("BBB");
    }

    private void DoSmthWithMonitor()
    {
        Console.WriteLine("AAA");

        var acquiredLock = false;

        try
        {
            Monitor.Enter(_locker, ref acquiredLock);
            _x = 0;
            for (var i = 1; i < 15; i++)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
                _x++;
                Thread.Sleep(200);
            }
        }
        finally
        {
            if (acquiredLock)
            {
                Monitor.Exit(_locker);
                Console.WriteLine("BBB");
            }
        }

    }

    private void DoSmthWithAutoResetEvent()
    {
        Console.WriteLine("AAA");
        _waitHandler.WaitOne();

        //AutoResetEvent.WaitAny(new WaitHandle[] { _waitHandler});
        //AutoResetEvent.WaitAll(new WaitHandle[] { _waitHandler });

        _x = 0;
        for (var i = 1; i < 15; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
            _x++;
            Thread.Sleep(200);
        }

        _waitHandler.Set();
        Console.WriteLine("BBB");
    }

    private void DoSmthWithMutex()
    {
        Console.WriteLine("AAA");

        _mutex.WaitOne();
        
        _x = 0;
        for (var i = 1; i < 15; i++)
        {
            Console.WriteLine($"{Thread.CurrentThread.Name}: {_x}");
            _x++;
            Thread.Sleep(200);
        }

        _mutex.ReleaseMutex();

        Console.WriteLine("BBB");
    }
}