// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using Amarok.Contracts;


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
    public Ingredient(Double amount, String unit, String substance)
    {
        Verify.IsPositive(amount, nameof(amount));
        Verify.NotNull(unit, nameof(unit));
        Verify.NotEmpty(substance, nameof(substance));

        Amount    = amount;
        Unit      = unit;
        Substance = substance;
    }

    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public Ingredient(String substance)
    {
        Verify.NotEmpty(substance, nameof(substance));

        Amount    = null;
        Unit      = null;
        Substance = substance;
    }


    /// <summary>
    ///     Returns a string that represents the current instance.
    /// </summary>
    public override String ToString()
    {
        if (Amount.HasValue)
            return $"{Amount} {Unit} {Substance}";

        return Substance;
    }
}
