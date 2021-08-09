// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;


namespace Bar.Web.Services
{
    /// <summary>
    ///     Represents a Rum.
    /// </summary>
    public sealed class Rum
    {
        /// <summary>
        ///     The name of the Rum, e.g. "A.H. Riise X.O. Reserve".
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        ///     A teaser text of the Rum, e.g. "Special Edition, Kong Haakon".
        /// </summary>
        public String Teaser { get; set; }

        /// <summary>
        ///     A list of image file names of the Rum, e.g. "KRO00442.jpg".
        /// </summary>
        public IList<String> Images { get; set; }

        /// <summary>
        ///     The main image file name of the Rum, e.g. "KRO00442.jpg".
        /// </summary>
        public String Image => Images?.FirstOrDefault();
    }
}
