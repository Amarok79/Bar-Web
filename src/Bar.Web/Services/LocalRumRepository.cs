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
            {
                return Array.Empty<Rum>();
            }

            await using var stream = File.OpenRead(fileInfo.PhysicalPath);

            var dto = await JsonSerializer.DeserializeAsync<RumsDto>(
                stream,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            if (dto?.Rums == null)
            {
                return Array.Empty<Rum>();
            }

            return dto.Rums.OrderBy(x => x.Name);
        }


        [UsedImplicitly]
        private sealed class RumsDto
        {
            public IEnumerable<Rum> Rums { get; set; }
        }
    }
}
