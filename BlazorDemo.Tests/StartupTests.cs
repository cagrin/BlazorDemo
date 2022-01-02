namespace BlazorDemo.Tests
{
    using BlazorDemo;
    using Microsoft.Extensions.Configuration;
    using Moq;

    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void StartupShouldHasConfiguration()
        {
            var startup = new Startup(new Mock<IConfiguration>().Object);
            Assert.IsNotNull(startup.Configuration);
        }
    }
}