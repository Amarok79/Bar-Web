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
using System.Collections.Generic;
using System.Linq;


namespace Bar.Web.Services
{
    /// <summary>
    /// Represents a Rum.
    /// </summary>
    public sealed class Rum
    {
        /// <summary>
        /// The name of the Rum, e.g. "A.H. Riise X.O. Reserve".
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// A teaser text of the Rum, e.g. "Special Edition, Kong Haakon".
        /// </summary>
        public String Teaser { get; set; }

        /// <summary>
        /// A list of image file names of the Rum, e.g. "KRO00442.jpg".
        /// </summary>
        public IList<String> Images { get; set; }

        /// <summary>
        /// The main image file name of the Rum, e.g. "KRO00442.jpg".
        /// </summary>
        public String Image => Images?.FirstOrDefault();
    }
}
