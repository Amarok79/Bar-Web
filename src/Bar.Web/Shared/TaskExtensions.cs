// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

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
