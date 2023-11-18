using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ClientUI.Pages
{
    public class LogoutModel : PageModel
    {
        public LogoutModel() { }

        public async Task<IActionResult> OnGetAsync(string redirectUri)
        {
            await Task.CompletedTask;

            return SignOut(new AuthenticationProperties
            {
                RedirectUri = Url.Content("~/")
            }
            , OpenIdConnectDefaults.AuthenticationScheme
            , CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
