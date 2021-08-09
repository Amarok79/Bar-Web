// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Hosting;


namespace Bar.Web.Services
{
    internal sealed class LocalRumRepository : IRumRepository
    {
        private readonly IWebHostEnvironment mWebHostEnvironment;


        public LocalRumRepository(IWebHostEnvironment webHostEnvironment)
        {
            mWebHostEnvironment = webHostEnvironment;
        }


        public async Task<IEnumerable<Rum>> GetAllAsync()
        {
            var fileInfo = mWebHostEnvironment.WebRootFileProvider.GetFileInfo("rum.json");

            if (!fileInfo.Exists)
                return Array.Empty<Rum>();

            await using var stream = File.OpenRead(fileInfo.PhysicalPath);

            var dto = await JsonSerializer.DeserializeAsync<RumsDto>(
                stream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (dto?.Rums == null)
                return Array.Empty<Rum>();

            return dto.Rums.OrderBy(x => x.Name);
        }


        [UsedImplicitly]
        private sealed class RumsDto
        {
            public IEnumerable<Rum> Rums { get; set; }
        }
    }
}
