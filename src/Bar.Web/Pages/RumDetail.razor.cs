// Copyright (c) 2023, Olaf Kober <olaf.kober@outlook.com>

using Bar.Web.Services;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;


public partial class RumDetail
{
    private Rum? mRum;


    [Inject]
    public IRumRepository Repository { get; set; } = default!;

    [Parameter]
    public Guid Id { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var rums = await Repository.GetAllAsync();
        mRum = rums.FirstOrDefault(x => x.Id == Id);
    }
}
