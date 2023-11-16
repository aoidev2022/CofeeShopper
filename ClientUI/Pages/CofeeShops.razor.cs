using API.DTO;

using ClientUI.Services;

using IdentityModel.Client;

using Microsoft.AspNetCore.Components;

namespace ClientUI.Pages;

public partial class CofeeShops
{
    private List<CofeeShopDto> shops = new();

    [Inject] private HttpClient HttpClient { get; set; }
    [Inject] private IConfiguration Configuration { get; set; }
    [Inject] private ITokenService TokenService { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var tokenResponse = await TokenService.GetTokenAsync("CofeeShop.API.read");

        HttpClient.SetBearerToken(tokenResponse.AccessToken);

        var result = await HttpClient.GetAsync(Configuration["applicationUrl"] + "/api/CofeeShop");
        if(result.IsSuccessStatusCode)
        {
            shops = await result.Content.ReadFromJsonAsync<List<CofeeShopDto>>();
        }
    }
}
