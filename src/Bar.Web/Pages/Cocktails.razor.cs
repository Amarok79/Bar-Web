// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable

using Bar.Web.Services;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;


public partial class Cocktails
{
    private IEnumerable<Drink> mItems;


    [Inject]
    public IDrinkRepository Repository { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }


    protected override async Task OnInitializedAsync()
    {
        // display dummy items
        mItems = Utils.CreateEmptyDrinks();

        await Task.Delay(50);

        // load and render real items
        var id = new BarId(Guid.Empty);
        mItems = await Repository.GetAllAsync(id);
        mItems = mItems.OrderBy(x => x.Name);
    }


    private void _HandleClicked(
        Drink item
    )
    {
        NavigationManager.NavigateTo(Urls.GetCocktailUrl(item));
    }
}
