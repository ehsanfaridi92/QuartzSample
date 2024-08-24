
namespace QuartzSample.Configurations;

public static class AppConfigurator
{
    public static void ConfigQuartz(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var setting = configuration.GetSection(nameof(JobSetting)).Get<JobSetting>();

        serviceCollection.AddQuartz(q =>
        {
            q.ScheduleJob<TestJob>(trigger => trigger
                .WithIdentity(nameof(TestJob))
                .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(setting.Hour, setting.Minute))
            );
        });

        serviceCollection.AddQuartzHostedService(options =>
        {
            options.WaitForJobsToComplete = true;
        });
    }
}

