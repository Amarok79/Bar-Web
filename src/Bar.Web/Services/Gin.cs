// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;


namespace Bar.Web.Services;

/// <summary>
///     Represents a Gin.
/// </summary>
public sealed class Gin
{
    /// <summary>
    ///     The unique Id of the Gin.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    ///     The name of the Gin, e.g. "The Stin Dry Gin".
    /// </summary>
    public String Name { get; set; } = default!;

    /// <summary>
    ///     A teaser of the Gin, e.g. "Styrian Dry Gin".
    /// </summary>
    public String? Teaser { get; set; }

    /// <summary>
    ///     A list of image file names of the Gin, e.g. "KRO01046.jpg", "KRO00364.jpg".
    /// </summary>
    public IList<String>? Images { get; set; }


    /// <summary>
    ///     The main image file name of the Gin, e.g. "KRO01046.jpg".
    /// </summary>
    public String? Image => Images?.FirstOrDefault();
}
