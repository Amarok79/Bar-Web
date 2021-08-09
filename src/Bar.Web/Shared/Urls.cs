// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using Bar.Web.Services;


namespace Bar.Web.Shared
{
    public static class Urls
    {
        public static readonly String Cocktails = "/cocktails";

        public static readonly String Gins = "/gins";

        public static readonly String Rums = "/rums";


        public static String GetCocktailUrl(Drink drink)
        {
            return $"{Cocktails}/{drink.Key}";
        }

        public static String GetLowResDrinkImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/low/{image}";
        }

        public static String GetHighResDrinkImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/drink/high/{image}";
        }

        public static String GetLowResGinImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/gin/low/{image}";
        }

        public static String GetLowResRumImage(String image)
        {
            return String.IsNullOrEmpty(image) ? "/images/none.jpg" : $"/images/rum/low/{image}";
        }
    }
}
