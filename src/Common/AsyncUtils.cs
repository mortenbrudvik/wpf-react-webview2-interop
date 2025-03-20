namespace Common;

public static class AsyncUtils
{
    /// <summary>
    /// Ensures safe operation of a task without await even if
    /// an execution fails with an exception. This forces the
    /// exception to be cleared unlike a non-continued task.
    /// </summary>
    /// <param name="t">Task Instance</param>
    public static void FireAndForget(this Task t)
    {
        t.ContinueWith(tsk => tsk.Exception,
            TaskContinuationOptions.OnlyOnFaulted);
    }
}