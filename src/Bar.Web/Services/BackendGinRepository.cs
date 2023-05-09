// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

using Flurl.Http;


namespace Bar.Web.Services;


internal sealed class BackendGinRepository : IGinRepository
{
    private readonly IHttpClientFactory mHttpClientFactory;
    private readonly IConfiguration mConfiguration;


    public BackendGinRepository(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration
    )
    {
        mHttpClientFactory = httpClientFactory;
        mConfiguration = configuration;
    }


    public async Task<IEnumerable<Gin>> GetAllAsync()
    {
        var client = new FlurlClient(mHttpClientFactory.CreateClient());
        client.BaseUrl = mConfiguration.GetValue<String>("Backend:Url");
        client.WithHeader("Api-Key", mConfiguration.GetValue<String>("Backend:ApiKey"));

        var items = await client.Request("/api/gins").GetJsonAsync<GinDto[]>();

        return items.Select(
                x => new Gin {
                    Id = x.Id,
                    Name = x.Name,
                    Teaser = x.Teaser ?? String.Empty,
                    Images = x.Images ?? Array.Empty<String>(),
                }
            )
            .OrderBy(x => x.Name)
            .ToList();
    }

    internal sealed class GinDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = default!;
        public String? Teaser { get; set; }
        public IList<String>? Images { get; set; }
    }
}
