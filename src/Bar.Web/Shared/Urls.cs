﻿/* MIT License
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
using Bar.Web.Services;


namespace Bar.Web.Shared
{
    public static class Urls
    {
        public static readonly String Cocktails = "/cocktails";

        public static readonly String Gins = "/gins";

        public static readonly String Rums = "/rums";


        public static String GetCocktailUrl(Drink drink)
        {
            return $"{Cocktails}/{drink.Key}";
        }

        public static String GetLowResDrinkImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/low/{image}";
        }

        public static String GetHighResDrinkImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/high/{image}";
        }

        public static String GetLowResGinImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/gin/low/{image}";
        }

        public static String GetLowResRumImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/rum/low/{image}";
        }
    }
}
