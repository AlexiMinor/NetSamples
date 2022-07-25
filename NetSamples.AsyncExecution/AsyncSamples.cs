namespace NetSamples.AsyncExecution;

public class AsyncSamples
{
    //void, Task, Task<T>, ValueTask<T>
    //async method can't use out, ref, in
    public async Task<int> DoAsync()
    {
        Console.WriteLine("Hello there");
        await PrintDataAsync();

        try
        {
            await DoSmth();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }

        return 1;
    }

    public async Task DoSmth()
    {
        throw new NotImplementedException();
    }

    public async Task DoWithStreams()
    {
        using (var sr = new StreamReader(File.Open("path", FileMode.Open)))
        {
            var line = await sr.ReadLineAsync();
        }
    }

    private async Task PrintDataAsync()
    {
        var task = Task.Run(() => Console.WriteLine("hello World"));
        await task;
    }
}