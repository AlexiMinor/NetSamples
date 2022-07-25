namespace NetSamples.Tasks;

public class CancellationTokenSample
{
    public void Do()
    {
        using (var cts = new CancellationTokenSource())
        {
            var token = cts.Token;

            var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var task = new Task(() =>
            {
                foreach (var i in list)
                {
                    if (token.IsCancellationRequested)
                    {
                        Console.WriteLine("Execution has been canceled");
                        return;
                    }

                    Console.WriteLine(i);
                    Thread.Sleep(200);
                }
            }, token);

            task.Start();
            Thread.Sleep(500);
            cts.Cancel();
            Thread.Sleep(500);

            Console.WriteLine(task.Status);
        }


    }
}