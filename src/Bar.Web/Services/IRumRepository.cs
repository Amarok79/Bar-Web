// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

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
