// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Linq;
using System.Threading.Tasks;
using Bar.Web.Services;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages;

public partial class GinDetail
{
    private Gin mGin;


    [Inject]
    public IGinRepository Repository { get; set; }

    [Parameter]
    public Guid Id { get; set; }


    protected override async Task OnInitializedAsync()
    {
        var gins = await Repository.GetAllAsync();
        mGin = gins.FirstOrDefault(x => x.Id == Id);
    }
}
