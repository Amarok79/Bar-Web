// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable

using Bar.Web.Services;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;


public partial class CocktailDetail
{
    private Drink mDrink;


    [Inject]
    public IDrinkRepository Repository { get; set; }

    [Parameter]
    public String Key { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var barId = new BarId(Guid.Empty);

        var drinks = await Repository.GetAllAsync(barId);
        mDrink = drinks.FirstOrDefault(x => x.Key.Equals(Key, StringComparison.OrdinalIgnoreCase));
    }
}
