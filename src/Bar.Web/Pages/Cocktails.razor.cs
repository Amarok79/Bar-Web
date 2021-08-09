// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bar.Web.Services;
using Bar.Web.Shared;
using Microsoft.AspNetCore.Components;


namespace Bar.Web.Pages
{
    partial class Cocktails
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


        private void _HandleClicked(Drink item)
        {
            NavigationManager.NavigateTo(Urls.GetCocktailUrl(item));
        }
    }
}
