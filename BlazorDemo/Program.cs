using BlazorDemo.Data;
using Blazorise;
using Blazorise.Localization;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

var builder = WebApplication.CreateBuilder(args);
var svc = builder.Services;

// Add services to the container.
svc.AddRazorPages();
svc.AddServerSideBlazor();
svc.AddBlazorise(options => { options.ChangeTextOnKeyPress = true; } )
   .AddBootstrapProviders()
   .AddFontAwesomeIcons();

svc.AddSingleton<WeatherForecastService>();

// This method change language for Blazorise components
svc.BuildServiceProvider()
   .GetRequiredService<ITextLocalizerService>()
   .ChangeLanguage("pl");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
