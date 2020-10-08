using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kelechekBurulsunFiveWebsite.Models;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;
using System.Globalization;
using System.Threading;

namespace kelechekCompanyWebsite.Controllers
{
    public class enController : Controller
    {

        public enController()
        {
            CultureInfo ci = new CultureInfo("en");
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> OurProducts()
        {
            return View();
        }

        public async Task<IActionResult> Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = System.DateTimeOffset.UtcNow.AddYears(1) }
            );

            string strPathValue = returnUrl;
            string strSecondForwaredSlashDeleted = String.Empty;
            string strFixedURLValue = String.Empty;
            string strFirstForwardSlashDeleted = (strPathValue).Substring((strPathValue).IndexOf("/") + 1);
            strSecondForwaredSlashDeleted = (strFirstForwardSlashDeleted).Substring((strFirstForwardSlashDeleted).IndexOf("/") + 1);

            if (strFirstForwardSlashDeleted.IndexOf("/") < 0)
            {
                strFixedURLValue = $"~/" + culture;
            }
            else
            {

                strFixedURLValue = $"~/" + culture + "/" + strSecondForwaredSlashDeleted;
            }

            return LocalRedirect(strFixedURLValue);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}