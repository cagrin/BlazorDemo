namespace BlazorDemo.Tests
{
    using BlazorDemo;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.TestHost;

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ProgramBuilderShouldRun()
        {
            Program.CreateHostBuilder(args: null!);
        }

        [TestMethod]
        public async Task ErrorPageShouldRun()
        {
            using var server = new TestServer(new WebHostBuilder().UseStartup<Startup>());

            var client = server.CreateClient();

            var response = await client.GetAsync(new Uri("/error"));

            Assert.IsNotNull(response);
        }
    }
}