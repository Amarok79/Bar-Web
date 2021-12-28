// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

#nullable enable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bar.Web.Services;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;

public partial class RumsPreview
{
    private IEnumerable<Rum>? mItems;


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
        mItems = ( await Repository.GetAllAsync() ).TakeRandom(4);
    }


    private void _HandleClicked(Rum item)
    {
        NavigationManager.NavigateTo(Urls.GetRumUrl(item));
    }
}
