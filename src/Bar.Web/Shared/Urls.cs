// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using Bar.Web.Services;


namespace Bar.Web.Shared;


public static class Urls
{
    public static readonly String Cocktails = "/cocktails";

    public static readonly String Gins = "/gins";

    public static readonly String Rums = "/rums";


    public static String GetCocktailUrl(
        Drink drink
    )
    {
        return $"{Cocktails}/{drink.Key}";
    }

    public static String GetGinUrl(
        Gin gin
    )
    {
        return $"{Gins}/{gin.Id}";
    }

    public static String GetRumUrl(
        Rum rum
    )
    {
        return $"{Rums}/{rum.Id}";
    }


    public static String GetLowResDrinkImage(
        String? image
    )
    {
        return String.IsNullOrEmpty(image)
            ? "https://amarok.blob.core.windows.net/bar/none.jpg"
            : $"https://amarok.blob.core.windows.net/bar/drink/low/{image}";
    }

    public static String GetHighResDrinkImage(
        String? image
    )
    {
        return String.IsNullOrEmpty(image)
            ? "https://amarok.blob.core.windows.net/bar/none.jpg"
            : $"https://amarok.blob.core.windows.net/bar/drink/high/{image}";
    }

    public static String GetLowResGinImage(
        String? image
    )
    {
        return String.IsNullOrEmpty(image)
            ? "https://amarok.blob.core.windows.net/bar/none.jpg"
            : $"https://amarok.blob.core.windows.net/bar/gin/low/{image}";
    }

    public static String GetLowResRumImage(
        String? image
    )
    {
        return String.IsNullOrEmpty(image)
            ? "https://amarok.blob.core.windows.net/bar/none.jpg"
            : $"https://amarok.blob.core.windows.net/bar/rum/low/{image}";
    }
}
