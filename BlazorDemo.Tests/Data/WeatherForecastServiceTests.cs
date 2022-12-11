namespace BlazorDemo.Tests.Data
{
    using BlazorDemo.Data;

    [TestClass]
    public class WeatherForecastServiceTests
    {
        [TestMethod]
        public async Task WeatherForecastServiceShouldHasData()
        {
            var service = new WeatherForecastService();

            var forecasts = await service.GetForecastAsync(DateOnly.FromDateTime(DateTime.Now));

            Assert.IsTrue(forecasts.Length == 25);
        }
    }
}
