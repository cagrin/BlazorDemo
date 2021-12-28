namespace BlazorDemo.Tests.Data
{
    using System.Collections.Generic;
    using BlazorDemo.Data;
    using Blazorise;
    using Blazorise.DataGrid;

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

        [TestMethod]
        public async Task WeatherForecastServiceShouldHasData()
        {
            DataGridReadDataMode readDataMode = DataGridReadDataMode.Paging;
            IEnumerable<DataGridColumn<WeatherForecast>> columns = new List<DataGridColumn<WeatherForecast>>();
            IList<DataGridColumn<WeatherForecast>> sortByColumns = new List<DataGridColumn<WeatherForecast>>();
            int page = 1;
            int pageSize = 5;
            int virtualizeOffset = 0;
            int virtualizeCount = 1;
            var e = new DataGridReadDataEventArgs<WeatherForecast>(readDataMode, columns, sortByColumns, page, pageSize, virtualizeOffset, virtualizeCount);

            var service = new WeatherForecastService();
            await service.OnReadDataAsync(e);
            var isEmpty = service.Data == null;
            Assert.IsFalse(isEmpty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WeatherForecastServiceShouldThrowArgumentNullException()
        {
            var service = new WeatherForecastService();
            await service.OnReadDataAsync(e: null!);
        }
    }
}
