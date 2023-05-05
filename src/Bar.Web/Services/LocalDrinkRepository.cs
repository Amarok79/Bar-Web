// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Hosting;


namespace Bar.Web.Services;


/// <summary>
///     An implementation that loads drinks from a file downloaded from Azure.
/// </summary>
internal sealed class LocalDrinkRepository : IDrinkRepository
{
    private readonly IWebHostEnvironment mWebHostEnvironment;


    public LocalDrinkRepository(
        IWebHostEnvironment webHostEnvironment
    )
    {
        mWebHostEnvironment = webHostEnvironment;
    }


    /// <summary>
    ///     Gets all Drinks for the given Bar.
    /// </summary>
    public Task<IEnumerable<Drink>> GetAllAsync(
        BarId barId
    )
    {
        var fileInfo = mWebHostEnvironment.WebRootFileProvider.GetFileInfo("drinks.xml");

        if (!fileInfo.Exists)
        {
            return Array.Empty<Drink>().AsEnumerable().AsTask();
        }

        return _LoadFromManifest(barId, fileInfo.PhysicalPath).AsEnumerable().AsTask();
    }


    private static List<Drink> _LoadFromManifest(
        BarId barId,
        String manifestPath
    )
    {
        var doc = XDocument.Load(manifestPath);
        var catalogNode = doc.Element("catalog");

        var substances = new Dictionary<String, String>();

        foreach (var substanceNode in catalogNode.Element("substances").Elements("substance"))
        {
            var id = substanceNode.Attribute("id").Value;

            var name = substanceNode.Value;

            substances.Add(id, name.Trim());
        }

        var drinks = new List<Drink>();

        foreach (var drinkNode in catalogNode.Element("drinks").Elements("drink"))
        {
            var id = drinkNode.Element("id").Value;

            var name = drinkNode.Element("name").Value;

            var teaser = drinkNode.Element("teaser").Value;

            var image = drinkNode.Element("image").Value;

            var desc = drinkNode.Element("description").Value;

            var tags = drinkNode.Element("tags").Value;

            var glass = drinkNode.Element("glass")?.Value;

            var ice = drinkNode.Element("ice")?.Value;

            var garnish = drinkNode.Element("garnish")?.Value;

            var key = _MakeKey(name);

            var drink = new Drink(new DrinkId(new Guid(id)), barId).SetName(name.Trim())
                .SetKey(key)
                .SetTeaser(teaser.Trim())
                .SetImage(image)
                .SetDescription(_TrimDescription(desc))
                .SetTags(_SplitAndTrimTags(tags))
                .SetGlass(glass?.Trim() ?? String.Empty)
                .SetIce(ice?.Trim() ?? String.Empty)
                .SetGarnish(garnish?.Trim() ?? String.Empty);

            Ingredient[] ingredients = null;
            String[] instructions = null;

            var recipeNode = drinkNode.Element("recipe");

            if (recipeNode != null)
            {
                ingredients = recipeNode.Elements("ingredient")
                    .Select(
                        x => {
                            var amount = x.Attribute("amount")?.Value;

                            var unit = x.Attribute("unit")?.Value;

                            var substance = x.Attribute("substance").Value;

                            if (substance.StartsWith("@", StringComparison.Ordinal))
                            {
                                var substanceId = substance[1..];

                                if (substances.TryGetValue(substanceId, out var substanceName))
                                {
                                    substance = substanceName;
                                }
                            }

                            if (amount == null && unit == null)
                            {
                                return new Ingredient(substance);
                            }

                            return new Ingredient(Double.Parse(amount, CultureInfo.InvariantCulture), unit, substance);
                        }
                    )
                    .ToArray();

                instructions = recipeNode.Elements("instruction").Select(x => x.Value?.Trim()).ToArray();
            }

            drink.SetRecipe(
                new Recipe(ingredients ?? Array.Empty<Ingredient>(), instructions ?? Array.Empty<String>())
            );

            drinks.Add(drink);
        }

        return drinks;
    }

    private static String _MakeKey(
        String name
    )
    {
        return name.Replace("  ", " ")
            .Replace(" ", "-")
            .Replace("&", "")
            .Replace("'", "")
            .Replace("(", "")
            .Replace(")", "")
            .Replace("--", "-")
            .ToLower();
    }

    private static String _TrimDescription(
        String text
    )
    {
        if (text == null)
        {
            return String.Empty;
        }

        var lines = text.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        var sb = new StringBuilder();

        foreach (var line in lines)
        {
            if (sb.Length > 0)
            {
                sb.AppendLine();
            }

            sb.AppendLine(line.Trim());
        }

        return sb.ToString();
    }

    private static String[] _SplitAndTrimTags(
        String text
    )
    {
        if (text == null)
        {
            return Array.Empty<String>();
        }

        var tags = text.Split(new[] { '|', ';', ',' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => x.Trim())
            .ToArray();

        return tags;
    }
}
