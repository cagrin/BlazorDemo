namespace BlazorDemo.Tests
{
    using BlazorDemo;
    using Microsoft.AspNetCore.Mvc.Testing;

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public async Task ErrorPageShouldRun()
        {
            using var server = new WebApplicationFactory<Program>();

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/error"));

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task DefaultPageShouldRun()
        {
            using var server = new WebApplicationFactory<Program>();

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/"));

            Assert.IsNotNull(response);
        }

        [TestMethod]
        public async Task FetchdataPageShouldRun()
        {
            using var server = new WebApplicationFactory<Program>();

            var client = server.CreateClient();
            var response = await client.GetAsync(new Uri("/fetchdata"));
            var actual = await response.Content.ReadAsStringAsync();

            Assert.IsTrue(actual.Contains("<h1>Weather forecast</h1>", StringComparison.Ordinal));
        }

        [TestMethod]
        public async Task ProgramMainShouldRunWithNullArgs()
        {
            Program.CancellationTokenSource.CancelAfter(5000);

            await Program.Main(args: null!);
        }
    }
}