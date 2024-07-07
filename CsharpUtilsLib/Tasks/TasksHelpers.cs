namespace CsharpUtilsLib.Tasks;

public static class TasksHelpers
{
    public static async Task RetryWithBackoff(this Func<Task> action, int maxRetries, int initialDelayMilliseconds)
    {
        int retries = 0;
        int delay = initialDelayMilliseconds;

        while (true)
        {
            try
            {
                await action();
                break;
            }
            catch
            {
                if (++retries == maxRetries)
                    throw;

                await Task.Delay(delay);
                delay *= 2;
            }
        }
    }

    public static async Task ExecuteWithTimeout(this Action action, TimeSpan timeout)
    {
        using (var cts = new CancellationTokenSource())
        {
            var task = Task.Run(action, cts.Token);
            if (await Task.WhenAny(task, Task.Delay(timeout, cts.Token)) == task)
            {
                cts.Cancel();
                await task;  // Ensure any exceptions are rethrown
            }
            else
            {
                throw new TimeoutException("The operation has timed out.");
            }
        }
    }

    public static Task<Task<T>> WhenAnyWithCompletionSource<T>(IEnumerable<Task<T>> tasks)
    {
        TaskCompletionSource<Task<T>> tcs = new TaskCompletionSource<Task<T>>();

        foreach (Task<T> task in tasks)
        {
            task.ContinueWith(t => tcs.TrySetResult(t), TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t => tcs.TrySetException(t?.Exception?.InnerExceptions!), TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
        }

        return tcs.Task;
    }

    public static async Task WhenAllWithThrottling(IEnumerable<Task> tasks, int maxDegreeOfParallelism)
    {
        SemaphoreSlim semaphore = new SemaphoreSlim(maxDegreeOfParallelism, maxDegreeOfParallelism);

        IEnumerable<Task> tasksWithSemaphore = tasks.Select(async task =>
        {
            await semaphore.WaitAsync();

            try
            {
                await task;
            }
            finally
            {
                semaphore.Release();
            }
        });

        await Task.WhenAll(tasksWithSemaphore);
    }

    public static async Task WhenAllWithProgress(IEnumerable<Task> tasks, IProgress<double> progress)
    {
        int totalTasks = tasks.Count();
        int completedTasks = 0;

        foreach (Task task in tasks)
        {
            await task;
            completedTasks++;
            progress.Report((double)completedTasks / totalTasks);
        }
    }

    public static void FireAndForget(this Task task, Action<Exception> errorHandler = null!)
    {
        task.ContinueWith(t =>
        {
            if (t.IsFaulted && errorHandler != null)
            {
                errorHandler(t.Exception!);
            }
        }, TaskContinuationOptions.OnlyOnFaulted);
    }

    public static async Task<T> Retry<T>(this Func<Task<T>> taskFactory, int maxRetries, TimeSpan delay)
    {
        foreach (int retry in Enumerable.Range(0, maxRetries))
        {
            try
            {
                return await taskFactory().ConfigureAwait(false);
            }
            catch
            {
                if (retry == maxRetries - 1)
                {
                    throw;
                }

                await Task.Delay(delay).ConfigureAwait(false);
            }
        }

        return default!;
    }

    public static async Task OnFailure(this Task task, Action<Exception> onFailure)
    {
        try
        {
            await task.ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            onFailure(ex);
        }
    }

    public static async Task WithTimeout(this Task task, TimeSpan timeout)
    {
        Task delayTask = Task.Delay(timeout);
        Task completedTask = await Task.WhenAny(task, delayTask);

        if (completedTask == delayTask)
        {
            throw new TimeoutException();
        }

        await task;
    }

    public static async Task<T> Fallback<T>(this Task<T> task, T fallbackValue)
    {
        try
        {
            return await task.ConfigureAwait(false);
        }
        catch
        {
            return fallbackValue;
        }
    }

    public static async Task<T> TryAsync<T>(this Task<T> task, Action<Exception> errorHandler = null!)
    {
        try
        {
            return await task;
        }
        catch (Exception ex) when (errorHandler is not null)
        {
            errorHandler(ex);
        }

        return default!;
    }
}
