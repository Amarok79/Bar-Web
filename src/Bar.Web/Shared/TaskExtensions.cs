// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System.Threading.Tasks;


namespace Bar.Web.Shared;


public static class TaskExtensions
{
    public static Task<T> AsTask<T>(
        this T obj
    )
    {
        return Task.FromResult(obj);
    }
}
