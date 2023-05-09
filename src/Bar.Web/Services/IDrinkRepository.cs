// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

namespace Bar.Web.Services;


/// <summary>
///     This service provides access to drinks, etc.
/// </summary>
public interface IDrinkRepository
{
    /// <summary>
    ///     Gets all Drinks for the given Bar.
    /// </summary>
    Task<IEnumerable<Drink>> GetAllAsync(
        BarId barId
    );
}
