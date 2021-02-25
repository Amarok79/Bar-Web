/* MIT License
 * 
 * Copyright (c) 2021, Olaf Kober
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
using System.Linq;
using System.Threading.Tasks;
using Bar.Web.Services;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages
{
    partial class Cocktail
    {
        private Drink mDrink;


        [Inject]
        public IDrinkRepository Repository { get; set; }

        [Parameter]
        public String Key { get; set; }


        protected override async Task OnInitializedAsync()
        {
            var barId = new BarId(Guid.Empty);

            IEnumerable<Drink> drinks = await Repository.GetAllAsync(barId);
            mDrink = drinks.FirstOrDefault(x => x.Key.Equals(Key, StringComparison.OrdinalIgnoreCase));
        }
    }
}
