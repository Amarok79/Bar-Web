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
using System.Linq;
using Bar.Web.Services;


namespace Bar.Web.Shared
{
    public static class Utils
    {
        public static String GetLowResDrinkImagePath(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/low/{image}";
        }

        public static String GetHighResDrinkImagePath(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/high/{image}";
        }

        public static String GetLowResGinImagePath(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/gin/low/{image}";
        }

        public static String GetLowResRumImagePath(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/rum/low/{image}";
        }

        public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> items, Int32 count)
        {
            var used   = new List<Int32>();
            var result = new List<T>();
            var random = new Random();
            var total  = items.Count();

            while (result.Count != count)
            {
                var index = random.Next(total);

                if (used.Contains(index))
                    continue;

                result.Add(items.Skip(index - 1).First());
                used.Add(index);
            }

            return result;
        }

        public static IEnumerable<Drink> CreateEmptyDrinks(Int32 count = 4)
        {
            return Enumerable.Repeat(new Drink(default, default), count);
        }

        public static IEnumerable<Gin> CreateEmptyGins(Int32 count = 4)
        {
            return Enumerable.Repeat(new Gin(), count);
        }

        public static IEnumerable<Rum> CreateEmptyRums(Int32 count = 4)
        {
            return Enumerable.Repeat(new Rum(), count);
        }
    }
}
