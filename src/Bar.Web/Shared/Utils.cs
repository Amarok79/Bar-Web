// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;
using Bar.Web.Services;


namespace Bar.Web.Shared;

public static class Utils
{
    public static IEnumerable<T> TakeRandom<T>(this IEnumerable<T> items, Int32 count)
    {
        var used   = new List<Int32>();
        var result = new List<T>();
        var random = new Random();
        var total  = items.Count();

        while (result.Count != count)
        {
            var index = random.Next(total);

            if (used.Contains(index))
                continue;

            result.Add(
                items.Skip(index - 1)
                   .First()
            );

            used.Add(index);
        }

        return result;
    }

    public static IEnumerable<Drink> CreateEmptyDrinks(Int32 count = 4)
    {
        return Enumerable.Repeat(new Drink(default, default), count);
    }

    public static IEnumerable<Gin> CreateEmptyGins(Int32 count = 4)
    {
        return Enumerable.Repeat(new Gin(), count);
    }

    public static IEnumerable<Rum> CreateEmptyRums(Int32 count = 4)
    {
        return Enumerable.Repeat(new Rum(), count);
    }
}
