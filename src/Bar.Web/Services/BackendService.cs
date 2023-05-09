// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable


using Flurl.Http;


namespace Bar.Web.Services;


internal sealed class BackendService : IBackendService
{
    private readonly IHttpClientFactory mHttpClientFactory;
    private readonly IConfiguration mConfiguration;


    public BackendService(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration
    )
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
