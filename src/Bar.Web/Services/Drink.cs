// Copyright (c) 2022, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;
using CommunityToolkit.Diagnostics;


namespace Bar.Web.Services;


/// <summary>
///     This type represents a Drink. A Drink belongs to a single Bar. A Drink contains information
///     like a simple Name, e.g. "Mai Tai", a so called Teaser text representing the main ingredients,
///     e.g. "Lime, Orgeat, Rum", a photo, and a longer Description text providing interesting
///     information about the drink. In addition, a Drink refers to a Recipe, which indicates a list of
///     Ingredients and a list of Instructions, both necessary to create the Drink.
/// </summary>
public sealed class Drink : Entity<DrinkId>
{
    /// <summary>
    ///     Gets the Id of the Bar this Drink belongs to.
    /// </summary>
    public BarId BarId { get; }

    /// <summary>
    ///     Gets the Key of the Drink, e.g. "mai-tai".
    /// </summary>
    public String Key { get; private set; }

    /// <summary>
    ///     Gets the Name of the Drink, e.g. "Mai Tai".
    /// </summary>
    public String Name { get; private set; }

    /// <summary>
    ///     Gets the Teaser of the Drink, e.g. "Lime, Orgeat, Rum".
    /// </summary>
    public String Teaser { get; private set; }

    /// <summary>
    ///     Gets the Description of the Drink, e.g. "The Mai Tai is a cocktail based on rum...".
    /// </summary>
    public String Description { get; private set; }

    /// <summary>
    ///     Gets the file name of the Image of the Drink.
    /// </summary>
    public String Image { get; private set; }

    /// <summary>
    ///     Gets the Recipe of the Drink.
    /// </summary>
    public Recipe Recipe { get; private set; }

    /// <summary>
    ///     Gets a collection of Tags associated with the Drink.
    /// </summary>
    public IReadOnlyCollection<String> Tags { get; private set; } = Array.Empty<String>();

    /// <summary>
    ///     Gets the Glass to use for this Drink.
    /// </summary>
    public String Glass { get; private set; }

    /// <summary>
    ///     Gets the kind of Ice to use for this Drink.
    /// </summary>
    public String Ice { get; private set; }

    /// <summary>
    ///     Gets the kind of Garnish to use for this Drink.
    /// </summary>
    public String Garnish { get; private set; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public Drink(DrinkId drinkId, BarId barId)
        : base(drinkId)
    {
        BarId = barId;
    }


    /// <summary>
    ///     Sets the Key of the Drink.
    /// </summary>
    /// 
    /// <param name="key">
    ///     The key of the drink. Neither null nor empty strings are allowed.
    /// </param>
    public Drink SetKey(String key)
    {
        Guard.IsNotEmpty(key, nameof(key));
        Key = key;

        return this;
    }

    /// <summary>
    ///     Sets the Name of the Drink.
    /// </summary>
    /// 
    /// <param name="name">
    ///     The name of the drink. Neither null nor empty strings are allowed.
    /// </param>
    public Drink SetName(String name)
    {
        Guard.IsNotEmpty(name, nameof(name));
        Name = name;

        return this;
    }

    /// <summary>
    ///     Sets the Teaser of the Drink.
    /// </summary>
    /// 
    /// <param name="teaser">
    ///     The teaser of the drink. Null is not allowed.
    /// </param>
    public Drink SetTeaser(String teaser)
    {
        Guard.IsNotNull(teaser, nameof(teaser));
        Teaser = teaser;

        return this;
    }

    /// <summary>
    ///     Sets the Description of the Drink.
    /// </summary>
    /// 
    /// <param name="description">
    ///     The description of the drink. Null is not allowed.
    /// </param>
    public Drink SetDescription(String description)
    {
        Guard.IsNotNull(description, nameof(description));
        Description = description;

        return this;
    }

    /// <summary>
    ///     Sets the Id of the Image of the Drink.
    /// </summary>
    /// 
    /// <param name="image">
    ///     The image of the drink.
    /// </param>
    public Drink SetImage(String image)
    {
        Image = image;

        return this;
    }

    /// <summary>
    ///     Sets the Recipe of the Drink.
    /// </summary>
    /// 
    /// <param name="recipe">
    ///     The Recipe of the Drink. Null is not allowed.
    /// </param>
    public Drink SetRecipe(Recipe recipe)
    {
        Guard.IsNotNull(recipe, nameof(recipe));
        Recipe = recipe;

        return this;
    }

    /// <summary>
    ///     Sets the Tags of the Drink.
    /// </summary>
    /// 
    /// <param name="tags">
    ///     The tags of the drink. Null is not allowed.
    /// </param>
    public Drink SetTags(IEnumerable<String> tags)
    {
        Guard.IsNotNull(tags, nameof(tags));
        Tags = tags.ToArray();

        return this;
    }

    /// <summary>
    ///     Sets the Glass of the Drink.
    /// </summary>
    /// 
    /// <param name="glass">
    ///     The glass of the drink. Null is not allowed.
    /// </param>
    public Drink SetGlass(String glass)
    {
        Guard.IsNotNull(glass, nameof(glass));
        Glass = glass;

        return this;
    }

    /// <summary>
    ///     Sets the Ice of the Drink.
    /// </summary>
    /// 
    /// <param name="ice">
    ///     The ice of the drink. Null is not allowed.
    /// </param>
    public Drink SetIce(String ice)
    {
        Guard.IsNotNull(ice, nameof(ice));
        Ice = ice;

        return this;
    }

    /// <summary>
    ///     Sets the Garnish of the Drink.
    /// </summary>
    /// 
    /// <param name="garnish">
    ///     The garnish of the drink. Null is not allowed.
    /// </param>
    public Drink SetGarnish(String garnish)
    {
        Guard.IsNotNull(garnish, nameof(garnish));
        Garnish = garnish;

        return this;
    }


    /// <summary></summary>
    public String GetTranslatedIce()
    {
        return Ice switch {
            "Cubed"   => "Würfel",
            "Crushed" => "Gestoßen",
            _         => "-",
        };
    }
}
