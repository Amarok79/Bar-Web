// Copyright (c) 2021, Olaf Kober <olaf.kober@outlook.com>

using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;


namespace Bar.Web.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true), IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        public String RequestId { get; set; }

        public Boolean ShowRequestId => !String.IsNullOrEmpty(RequestId);

        private readonly ILogger<ErrorModel> mLogger;

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            mLogger = logger;
        }

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
