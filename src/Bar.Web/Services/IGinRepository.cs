// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

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
