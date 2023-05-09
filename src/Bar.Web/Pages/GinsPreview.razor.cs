﻿// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

#nullable disable

using Bar.Web.Services;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;


public partial class GinsPreview
{
    private IEnumerable<Gin> mItems;


    [Inject]
    public IGinRepository Repository { get; set; } = default!;

    [Inject]
    public NavigationManager NavigationManager { get; set; } = default!;



    protected override async Task OnInitializedAsync()
    {
        // display dummy items
        mItems = Utils.CreateEmptyGins();

        await Task.Delay(50);

        // load and render real items
        mItems = ( await Repository.GetAllAsync() ).TakeRandom(4);
    }


    private void _HandleClicked(
        Gin item
    )
    {
        NavigationManager.NavigateTo(Urls.GetGinUrl(item));
    }
}
