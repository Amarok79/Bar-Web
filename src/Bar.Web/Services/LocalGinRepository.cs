/* MIT License
 * 
 * Copyright (c) 2020, Olaf Kober
 * https://github.com/Amarok79/Bar-Web
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

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
