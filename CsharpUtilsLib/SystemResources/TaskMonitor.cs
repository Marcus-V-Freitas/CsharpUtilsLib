namespace CsharpUtilsLib.SystemResources;

public sealed class TaskMonitor
{
    private TimeSpan _totalTime;
    private long _totalMemory;
    private double _cpuUsage;

    public void MonitorTask(Action task)
    {
        MonitorTaskCommon(() => { task(); return 0; });
    }

    public T MonitorTask<T>(Func<T> task)
    {
        return MonitorTaskCommon(task);
    }

    public async Task MonitorTaskAsync(Func<Task> asyncTask)
    {
        await MonitorTaskCommonAsync(async () => { await asyncTask(); return 0; });
    }

    public async Task<T> MonitorTaskAsync<T>(Func<Task<T>> asyncTask)
    {
        return await MonitorTaskCommonAsync(asyncTask);
    }

    private T MonitorTaskCommon<T>(Func<T> task)
    {
        Process process = Process.GetCurrentProcess();
        var startTime = DateTime.UtcNow;
        var startCpuUsage = process.TotalProcessorTime;
        long startMemory = process.PrivateMemorySize64;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        T result = task();

        stopwatch.Stop();
        _totalTime = stopwatch.Elapsed;
        _totalMemory = GetTotalOfMemory(process.PrivateMemorySize64, startMemory);
        _cpuUsage = GetCPUUsage(process.TotalProcessorTime, startCpuUsage, startTime);

        return result;
    }

    private async Task<T> MonitorTaskCommonAsync<T>(Func<Task<T>> asyncTask)
    {
        Process process = Process.GetCurrentProcess();
        var startTime = DateTime.UtcNow;
        var startCpuUsage = process.TotalProcessorTime;
        long startMemory = process.PrivateMemorySize64;

        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        T result = await asyncTask();

        stopwatch.Stop();
        _totalTime = stopwatch.Elapsed;
        _totalMemory = GetTotalOfMemory(process.PrivateMemorySize64, startMemory);
        _cpuUsage = GetCPUUsage(process.TotalProcessorTime, startCpuUsage, startTime);

        return result;
    }

    private static long GetTotalOfMemory(long endMemory, long startMemory)
    {
        return endMemory - startMemory;
    }

    private static double GetCPUUsage(TimeSpan endCpuUsage, TimeSpan startCpuUsage, DateTime startTime)
    {
        var endTime = DateTime.UtcNow;
        var cpuUsedMs = (endCpuUsage - startCpuUsage).TotalMilliseconds;
        var totalMsPassed = (endTime - startTime).TotalMilliseconds;
        var cpuUsageTotal = cpuUsedMs / (Environment.ProcessorCount * totalMsPassed);
        return cpuUsageTotal * 100;
    }

    public void PrintLastResults()
    {
        Console.WriteLine($"Total time: {_totalTime.Seconds} secs.");
        Console.WriteLine($"Total memory: {_totalMemory} bytes.");
        Console.WriteLine($"CPU usage: {_cpuUsage}%.");
    }
}