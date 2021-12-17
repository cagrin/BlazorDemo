namespace BlazorDemo.Tests.Data
{
    using BlazorDemo.Data;

    [TestClass]
    public class WeatherForecastServiceTests
    {
        [TestMethod]
        public void EmptyTest()
        {
            var service = new WeatherForecastService();
            var isEmpty = service.Data == null;
            Assert.IsTrue(isEmpty);
        }
    }
}
