// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

using Flurl.Http;


namespace Bar.Web.Services;


internal sealed class BackendRumRepository : IRumRepository
{
    private readonly IHttpClientFactory mHttpClientFactory;
    private readonly IConfiguration mConfiguration;


    public BackendRumRepository(
        IHttpClientFactory httpClientFactory,
        IConfiguration configuration
    )
    {
        mHttpClientFactory = httpClientFactory;
        mConfiguration = configuration;
    }


    public async Task<IEnumerable<Rum>> GetAllAsync()
    {
        var client = new FlurlClient(mHttpClientFactory.CreateClient());
        client.BaseUrl = mConfiguration.GetValue<String>("Backend:Url");
        client.WithHeader("Api-Key", mConfiguration.GetValue<String>("Backend:ApiKey"));

        var items = await client.Request("/api/rums").GetJsonAsync<RumDto[]>();

        return items.Select(
                x => new Rum {
                    Id = x.Id,
                    Name = x.Name,
                    Teaser = x.Teaser ?? String.Empty,
                    Images = x.Images ?? Array.Empty<String>(),
                }
            )
            .OrderBy(x => x.Name)
            .ToList();
    }

    internal sealed class RumDto
    {
        public Guid Id { get; set; }
        public String Name { get; set; } = default!;
        public String? Teaser { get; set; }
        public IList<String>? Images { get; set; }
    }
}
