using System.Diagnostics;

namespace NetSamples.Tasks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //var task = new Task(() =>
            //{
            //    Thread.Sleep(2000);
            //    Console.WriteLine("Hello task1");
            //    var subTask = new Task(() => Console.WriteLine("Hello from subtask"));
            //    subTask.Start();
            //    subTask.Wait();
            //});
            //task.Start();

            //var task2 = Task.Factory.StartNew(() => Console.WriteLine("Hello again task2"));

            //var task34 = new Task(() => Console.WriteLine("Hello there task3"));
            //task34.RunSynchronously();//in same thread


            //var task3 = Task.Run(() => Console.WriteLine("Hello there task4"));

            //task.Wait();
            //task2.Wait();
            //task3.Wait();

            //var x = 15; // task34 can be not executed

            //var taskStatus = TaskStatus.Running;


            var taskSamples = new TaskSamples();
            //taskSamples.Do();

            //taskSamples.RunFewTasksInParallel();

            //taskSamples.Calculate();


            //sw.Restart();
            //taskSamples.BuySmthInParallel();
            //sw.Stop();
            //Console.WriteLine($"Running parallel takes {sw.ElapsedMilliseconds}");
            
            //var sw = new Stopwatch();
            //sw.Start();
            //taskSamples.BuySmthSync();
            //sw.Stop();
            //Console.ForegroundColor  = ConsoleColor.Red;
            //Console.WriteLine($"Running sync takes {sw.ElapsedMilliseconds}");
            //Console.ResetColor();
            //var ps = new ParallelSample();
            //sw.Restart();
            //ps.DoForEach();
            //sw.Stop();
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine($"Running parallel takes {sw.ElapsedMilliseconds}");
            //Console.ResetColor();

            //Console.WriteLine("Main ended");

            var cancellationTokenSample = new CancellationTokenSample();
            cancellationTokenSample.Do();
        }
    }
}