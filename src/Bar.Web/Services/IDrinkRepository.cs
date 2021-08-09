// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System.Collections.Generic;
using System.Threading.Tasks;


namespace Bar.Web.Services
{
    /// <summary>
    ///     This service provides access to drinks, etc.
    /// </summary>
    public interface IDrinkRepository
    {
        /// <summary>
        ///     Gets all Drinks for the given Bar.
        /// </summary>
        Task<IEnumerable<Drink>> GetAllAsync(BarId barId);
    }
}
