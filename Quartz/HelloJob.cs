using System;
using Quartz;

namespace QuartzSample
{
    public class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            var name = context.MergedJobDataMap.GetString("name");
            Console.WriteLine("Hello {0}!", name);
        }
    }
}