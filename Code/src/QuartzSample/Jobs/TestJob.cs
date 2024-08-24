
namespace QuartzSample.Jobs;

[DisallowConcurrentExecution]
public class TestJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            Console.WriteLine("job triggered");

            await Task.CompletedTask;
        }
        catch (Exception exp)
        {
            Console.WriteLine(exp.Message);
        }
    }
}

