// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;


namespace Bar.Web;


public static class Program
{
    public static void Main(String[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(String[] args)
    {
        return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(builder => builder.UseStartup<Startup>());
    }
}
