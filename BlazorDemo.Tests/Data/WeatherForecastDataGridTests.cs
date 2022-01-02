namespace BlazorDemo.Tests.Data
{
    using BlazorDemo.Data;
    using Blazorise.Tests.Helpers;
    using Bunit;
    using Microsoft.Extensions.DependencyInjection;

    [TestClass]
    public class WeatherForecastDataGridTests : TestContext
    {
        public WeatherForecastDataGridTests()
        {
            BlazoriseConfig.AddBootstrapProviders(this.Services);
            BlazoriseConfig.JSInterop.AddDataGrid(this.JSInterop);
        }

        [TestMethod]
        public void WeatherForecastDataGridShouldRender()
        {
            this.Services.AddSingleton<WeatherForecastService>();

            var cut = this.RenderComponent<WeatherForecastDataGrid>();

            Assert.IsTrue(cut.Markup.Contains("1 - 5 z 25 wierszy", StringComparison.Ordinal));
        }
    }
}