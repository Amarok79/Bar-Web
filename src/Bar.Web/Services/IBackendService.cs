// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

namespace Bar.Web.Services;


/// <summary>
///     This service provides access to the backend.
/// </summary>
public interface IBackendService
{
    /// <summary>
    ///     Gets the version of the backend service.
    /// </summary>
    Task<String> GetVersion();
}
