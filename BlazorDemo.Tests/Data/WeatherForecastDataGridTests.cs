namespace BlazorDemo.Tests.Data
{
    using BlazorDemo.Data;
    using Bunit;
    using Microsoft.Extensions.DependencyInjection;

    [TestClass]
    public class WeatherForecastDataGridTests
    {
        [TestMethod]
        public void WeatherForecastDataGridShouldRender()
        {
            using var ctx = new TestContext();

            ctx.Services.AddSingleton<WeatherForecastService>();

            /* var cut = ctx.RenderComponent<WeatherForecastDataGrid>(); */
        }
    }
}