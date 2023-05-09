// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable


using CommunityToolkit.Diagnostics;


namespace Bar.Web.Services;


/// <summary>
///     This type represents a single Ingredient in a Recipe, e.g. "5 cl Light Rum".
/// </summary>
public sealed class Ingredient
{
    /// <summary>
    ///     Gets the amount of the ingredient, e.g. "5".
    /// </summary>
    public Double? Amount { get; }

    /// <summary>
    ///     Gets the unit used for the amount of the ingredient, e.g. "cl".
    /// </summary>
    public String Unit { get; }

    /// <summary>
    ///     Gets the name of the ingredient, e.g. "Light Rum".
    /// </summary>
    public String Substance { get; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public Ingredient(
        Double amount,
        String unit,
        String substance
    )
    {
        Guard.IsGreaterThan(amount, 0, nameof(amount));
        Guard.IsNotNull(unit, nameof(unit));
        Guard.IsNotEmpty(substance, nameof(substance));

        Amount = amount;
        Unit = unit;
        Substance = substance;
    }

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public Ingredient(
        String substance
    )
    {
        Guard.IsNotEmpty(substance, nameof(substance));

        Amount = null;
        Unit = null;
        Substance = substance;
    }


    /// <summary>
    ///     Returns a string that represents the current instance.
    /// </summary>
    public override String ToString()
    {
        if (Amount.HasValue)
        {
            return $"{Amount} {Unit} {Substance}";
        }

        return Substance;
    }
}
