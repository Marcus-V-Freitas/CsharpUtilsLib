namespace CsharpUtilsLib.Tasks;

public static class TasksHelpers
{
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
