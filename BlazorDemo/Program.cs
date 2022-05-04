namespace BlazorDemo
{
    public static class Program
    {
        public static CancellationTokenSource CancellationTokenSource { get; } = new CancellationTokenSource();

        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            await host.RunAsync(CancellationTokenSource.Token);
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host
                .CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(conf => { conf.UseStartup<Startup>(); });
        }
    }
}
