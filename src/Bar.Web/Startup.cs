// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

using System.Globalization;
using Bar.Web.Services;


namespace Bar.Web;


public class Startup
{
    public IConfiguration Configuration { get; }


    public Startup(
        IConfiguration configuration
    )
    {
        Configuration = configuration;
    }


    public void ConfigureServices(
        IServiceCollection services
    )
    {
        services.AddHttpClient();
        services.AddRazorPages();
        services.AddServerSideBlazor();

        services.AddApplicationInsightsTelemetry(
            options => options.ConnectionString = Configuration["ApplicationInsights:ConnectionString"]
        );

        services.AddTransient(typeof(IRumRepository), typeof(BackendRumRepository));
        services.AddTransient(typeof(IGinRepository), typeof(BackendGinRepository));
        services.AddTransient(typeof(IDrinkRepository), typeof(LocalDrinkRepository));
        services.AddTransient(typeof(IBackendService), typeof(BackendService));
    }

    public void Configure(
        IApplicationBuilder app,
        IWebHostEnvironment env
    )
    {
        var cultureInfo = CultureInfo.GetCultureInfo("de-AT");
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseEndpoints(
            endpoints => {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            }
        );
    }
}
