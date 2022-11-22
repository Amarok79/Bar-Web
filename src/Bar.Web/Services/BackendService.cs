// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Configuration;


namespace Bar.Web.Services;


internal sealed class BackendService : IBackendService
{
    private readonly IHttpClientFactory mHttpClientFactory;
    private readonly IConfiguration mConfiguration;


    public BackendService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        mHttpClientFactory = httpClientFactory;
        mConfiguration = configuration;
    }


    public async Task<String> GetVersion()
    {
        var client = new FlurlClient(mHttpClientFactory.CreateClient());
        client.BaseUrl = mConfiguration.GetValue<String>("Backend:Url");
        client.WithHeader("Api-Key", mConfiguration.GetValue<String>("Backend:ApiKey"));

        var dto = await client.Request("/api/version").GetJsonAsync<VersionDto>();

        return dto.ServerVersion;
    }


    internal sealed class VersionDto
    {
        public String ServerVersion { get; set; }
    }
}
