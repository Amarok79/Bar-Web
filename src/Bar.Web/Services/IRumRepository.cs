﻿// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bar.Web.Services;


/// <summary>
///     Represents a repository of Rums.
/// </summary>
public interface IRumRepository
{
    /// <summary>
    ///     Gets an unordered collection of all Rums.
    /// </summary>
    Task<IEnumerable<Rum>> GetAllAsync();
}
