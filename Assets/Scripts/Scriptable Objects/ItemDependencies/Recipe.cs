using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class Recipe
{
    private readonly int[] ingredients;
    public IReadOnlyList<int> Ingredients => ingredients;
    public string Key {get; private set;}


    public Recipe(params int[] ingredients)
    {
        this.ingredients = ingredients;
        Key = GenerateKey(Ingredients.ToList());
    }

    public static string GenerateKey(List<int> Ingredients)
    {
        return string.Join("-", Ingredients.OrderBy(x => x));
    }
}
