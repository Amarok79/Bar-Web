// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

using System.Text;
using CommunityToolkit.Diagnostics;


namespace Bar.Web.Services;


/// <summary>
///     This type represents a Recipe for a Drink. A Recipe consists of a list of Ingredients and a
///     list of Instructions.
/// </summary>
public sealed class Recipe
{
    /// <summary>
    ///     A list of Ingredients needed for this Recipe.
    /// </summary>
    public IReadOnlyList<Ingredient> Ingredients { get; }

    /// <summary>
    ///     A list of Instructions needed for creating the Drink.
    /// </summary>
    public IReadOnlyList<String> Instructions { get; }


    /// <summary>
    ///     Initializes a new instance.
    /// </summary>
    public Recipe(
        IReadOnlyList<Ingredient> ingredients,
        IReadOnlyList<String> instructions
    )
    {
        Guard.IsNotNull(ingredients, nameof(ingredients));
        Guard.IsNotNull(instructions, nameof(instructions));

        Ingredients = ingredients;
        Instructions = instructions;
    }


    /// <summary>
    ///     Returns a string that represents the current instance.
    /// </summary>
    public override String ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine("Ingredients:");

        foreach (var ingredient in Ingredients)
        {
            sb.AppendLine(ingredient.ToString());
        }

        sb.AppendLine("Instructions:");

        foreach (var instruction in Instructions)
        {
            sb.AppendLine(instruction);
        }

        return sb.ToString();
    }
}
