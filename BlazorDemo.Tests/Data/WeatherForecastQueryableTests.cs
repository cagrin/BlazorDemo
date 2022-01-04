namespace BlazorDemo.Tests.Data
{
    using System.Collections.Generic;
    using BlazorDemo.Data;
    using Blazorise.DataGrid;

    [TestClass]
    public class WeatherForecastQueryableTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task WeatherForecastQueryableShouldThrowArgumentNullException()
        {
            var service = new WeatherForecastQueryable();
            await service.OnReadDataAsync(e: null!);
        }

        [TestMethod]
        public async Task WeatherForecastQueryableShouldHasData()
        {
            DataGridReadDataMode readDataMode = DataGridReadDataMode.Paging;
            IEnumerable<DataGridColumn<WeatherForecast>> columns = new List<DataGridColumn<WeatherForecast>>();
            IList<DataGridColumn<WeatherForecast>> sortByColumns = new List<DataGridColumn<WeatherForecast>>();
            int page = 1;
            int pageSize = 5;
            int virtualizeOffset = 0;
            int virtualizeCount = 1;
            var e = new DataGridReadDataEventArgs<WeatherForecast>(readDataMode, columns, sortByColumns, page, pageSize, virtualizeOffset, virtualizeCount);

            var service = new WeatherForecastQueryable();
            await service.OnReadDataAsync(e);
            var isEmpty = service.Data == null;
            Assert.IsFalse(isEmpty);
        }
    }
}
