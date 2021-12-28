// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System.Globalization;
using Bar.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Bar.Web;

public class Startup
{
    public IConfiguration Configuration { get; }


    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddRazorPages();
        services.AddServerSideBlazor();
        services.AddApplicationInsightsTelemetry(Configuration["APPINSIGHTS_CONNECTIONSTRING"]);

        services.AddTransient(typeof(IRumRepository), typeof(BackendRumRepository));
        services.AddTransient(typeof(IGinRepository), typeof(BackendGinRepository));
        services.AddTransient(typeof(IDrinkRepository), typeof(LocalDrinkRepository));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var cultureInfo = CultureInfo.GetCultureInfo("de-AT");
        CultureInfo.DefaultThreadCurrentCulture   = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

        if (env.IsDevelopment())
            app.UseDeveloperExceptionPage();
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
