// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable

using Bar.Web.Services;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;


public partial class RumsCollection
{
    private IEnumerable<Rum> mItems;


    [Inject]
    public IRumRepository Repository { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;


    protected override async Task OnInitializedAsync()
    {
        // display dummy items
        mItems = Utils.CreateEmptyRums();

        await Task.Delay(50);

        // load and render real items
        mItems = await Repository.GetAllAsync();
        mItems = mItems.OrderBy(x => x.Name);
    }

    private void _HandleClicked(
        Rum item
    )
    {
        NavigationManager.NavigateTo(Urls.GetRumUrl(item));
    }
}
