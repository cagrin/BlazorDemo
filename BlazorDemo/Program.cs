using BlazorDemo.Data;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Blazorise.Localization;

Application.Run(args);

public static class Application
{
    public static void Run(string[] args)
    {
        WebApplication
            .CreateBuilder(args)
            .AddServices()
            .Build()
            .Configure()
            .Run();
    }

    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder), "Value cannot be null.");
        }

        var svc = builder.Services;

        svc.AddRazorPages();
        svc.AddServerSideBlazor();
        svc.AddBlazorise(options => { options.ChangeTextOnKeyPress = true; })
           .AddBootstrapProviders()
           .AddFontAwesomeIcons();

        svc.AddSingleton<WeatherForecastService>();

        // This method change language for Blazorise components
        svc.BuildServiceProvider()
           .GetRequiredService<ITextLocalizerService>()
           .ChangeLanguage("pl");

        return builder;
    }

    public static WebApplication Configure(this WebApplication app)
    {
        if (app == null)
        {
            throw new ArgumentNullException(nameof(app), "Value cannot be null.");
        }

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

        return app;
    }
}
