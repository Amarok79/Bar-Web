// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl.Http;
using Microsoft.Extensions.Configuration;


namespace Bar.Web.Services;

internal sealed class BackendRumRepository : IRumRepository
{
    private readonly IHttpClientFactory mHttpClientFactory;
    private readonly IConfiguration mConfiguration;


    public BackendRumRepository(IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        mHttpClientFactory = httpClientFactory;
        mConfiguration     = configuration;
    }


    public async Task<IEnumerable<Rum>> GetAllAsync()
    {
        var client = new FlurlClient(mHttpClientFactory.CreateClient());
        client.BaseUrl = mConfiguration.GetValue<String>("Backend:Url");
        client.WithHeader("Api-Key", mConfiguration.GetValue<String>("Backend:ApiKey"));

        var items = await client.Request("/api/rums")
           .GetJsonAsync<RumDto[]>();

        return items.Select(
                x => new Rum {
                    Name   = x.Name,
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
