// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Text;
using Amarok.Contracts;


namespace Bar.Web.Services
{
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
        public Recipe(IReadOnlyList<Ingredient> ingredients, IReadOnlyList<String> instructions)
        {
            Verify.NotNull(ingredients, nameof(ingredients));
            Verify.NotNull(instructions, nameof(instructions));

            Ingredients  = ingredients;
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
                sb.AppendLine(ingredient.ToString());

            sb.AppendLine("Instructions:");

            foreach (var instruction in Instructions)
                sb.AppendLine(instruction);

            return sb.ToString();
        }
    }
}
