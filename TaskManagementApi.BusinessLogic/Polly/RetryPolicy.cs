using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serilog;
namespace TaskManagementApi.BusinessLogic.Polly
{
    public class RetryPolicy : IRetryPolicy
{
    private readonly IAsyncPolicy _policy;

    public RetryPolicy()
    {
        _policy = Policy.Handle<Exception>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                (exception, timeSpan, retryCount, context) =>
                {
                    Log.Warning($"Retry {retryCount} after {timeSpan.Seconds} seconds due to {exception.Message}.");
                });
    }

    public T Execute<T>(Func<T> action)
    {
        return _policy.ExecuteAsync(() => Task.FromResult(action())).GetAwaiter().GetResult();
    }
}

}
