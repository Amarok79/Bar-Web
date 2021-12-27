// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Linq;
using System.Threading.Tasks;
using Bar.Web.Services;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;

public partial class Cocktail
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
