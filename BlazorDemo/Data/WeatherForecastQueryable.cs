namespace BlazorDemo.Data
{
    using Blazorise.DataGrid;

    public class WeatherForecastQueryable
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching",
        };

        private IQueryable<WeatherForecast>? _forecasts;

        public WeatherForecast[]? Data { get; set; }

        public int TotalItems { get; set; }

        public async Task OnReadDataAsync(DataGridReadDataEventArgs<WeatherForecast> e)
        {
            if (e == null)
            {
                throw new ArgumentNullException(nameof(e), "Value cannot be null.");
            }

            if (this._forecasts == null)
            {
                var items = await this.GetForecastAsync(DateTime.Now);
                this._forecasts = items.AsQueryable<WeatherForecast>();
            }

            var query = this._forecasts;
/*
            var filteredColumns = e.Columns.Where(f => !string.IsNullOrEmpty(f.SearchValue?.ToString())).ToArray();
            foreach (var column in filteredColumns)
            {
                var search = column.SearchValue?.ToString();
                if (search != null)
                {
                    query = column.Field switch
                    {
                        nameof(WeatherForecast.Date) => query.Where(f => f.Date.ToShortDateString().Like(search)),
                        nameof(WeatherForecast.TemperatureC) => query.Where(f => f.TemperatureC.ToString().Like(search)),
                        nameof(WeatherForecast.TemperatureF) => query.Where(f => f.TemperatureF.ToString().Like(search)),
                        nameof(WeatherForecast.Summary) => query.Where(f => f.Summary.Like(search)),
                        _ => query,
                    };
                }
            }

            var sortedColumns = e.Columns.Where(f => f.SortIndex >= 0).OrderByDescending(f => f.SortIndex).ToArray();
            foreach (var column in sortedColumns)
            {
                query = (column.Field, column.SortDirection) switch
                {
                    (nameof(WeatherForecast.Date), SortDirection.Ascending) => query.OrderBy(f => f.Date),
                    (nameof(WeatherForecast.Date), SortDirection.Descending) => query.OrderByDescending(f => f.Date),
                    (nameof(WeatherForecast.TemperatureC), SortDirection.Ascending) => query.OrderBy(f => f.TemperatureC),
                    (nameof(WeatherForecast.TemperatureC), SortDirection.Descending) => query.OrderByDescending(f => f.TemperatureC),
                    (nameof(WeatherForecast.TemperatureF), SortDirection.Ascending) => query.OrderBy(f => f.TemperatureF),
                    (nameof(WeatherForecast.TemperatureF), SortDirection.Descending) => query.OrderByDescending(f => f.TemperatureF),
                    (nameof(WeatherForecast.Summary), SortDirection.Ascending) => query.OrderBy(f => f.Summary),
                    (nameof(WeatherForecast.Summary), SortDirection.Descending) => query.OrderByDescending(f => f.Summary),
                    _ => query,
                };
            }
*/
            this.TotalItems = query.Count();
            this.Data = query.Skip((e.Page - 1) * e.PageSize).Take(e.PageSize).ToArray();
        }

        private Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 25).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)],
            }).ToArray());
        }
    }
}
