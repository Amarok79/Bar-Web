// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bar.Web.Services;


/// <summary>
///     Represents a repository of Gins.
/// </summary>
public interface IGinRepository
{
    /// <summary>
    ///     Gets an unordered collection of all Gins.
    /// </summary>
    Task<IEnumerable<Gin>> GetAllAsync();
}
