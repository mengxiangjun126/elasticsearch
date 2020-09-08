using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ElasticsearchSampleWebApi1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //这里添加Nlog
            //测试Nlog日志输出
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            }).ConfigureLogging(LoggingBuilder =>
            {
                LoggingBuilder.AddLog4Net();
            });
    }
}