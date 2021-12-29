namespace BlazorDemo.Tests.Data
{
    using BlazorDemo.Data;

    [TestClass]
    public class WeatherForecastTests
    {
        [DataTestMethod]
        [DataRow(0, 32)]
        [DataRow(10, 49)]
        [DataRow(30, 85)]
        [DataRow(100, 211)]
        public void WeatherForecastShouldHasTemperatureF(int tempC, int tempF)
        {
            var wf = new WeatherForecast() { TemperatureC = tempC };
            Assert.AreEqual<int>(tempF, wf.TemperatureF);
        }
    }
}
