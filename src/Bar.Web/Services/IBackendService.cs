// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Threading.Tasks;


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
