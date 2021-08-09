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
    internal sealed class LocalGinRepository : IGinRepository
    {
        private readonly IWebHostEnvironment mWebHostEnvironment;


        public LocalGinRepository(IWebHostEnvironment webHostEnvironment)
        {
            mWebHostEnvironment = webHostEnvironment;
        }


        public async Task<IEnumerable<Gin>> GetAllAsync()
        {
            var fileInfo = mWebHostEnvironment.WebRootFileProvider.GetFileInfo("gin.json");

            if (!fileInfo.Exists)
                return Array.Empty<Gin>();

            await using var stream = File.OpenRead(fileInfo.PhysicalPath);

            var dto = await JsonSerializer.DeserializeAsync<GinsDto>(
                stream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (dto?.Gins == null)
                return Array.Empty<Gin>();

            return dto.Gins.OrderBy(x => x.Name);
        }


        [UsedImplicitly]
        private sealed class GinsDto
        {
            public IEnumerable<Gin> Gins { get; set; }
        }
    }
}
