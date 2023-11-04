using API.DTO;

using Microsoft.AspNetCore.Components;

namespace ClientUI.Pages;

public partial class CofeeShops
{
    private List<CofeeShopDto> shops = new();

    [Inject] private HttpClient httpClient { get; set; }
    [Inject] private IConfiguration configuration { get; set; }

    protected override async Task OnInitializedAsync()
    {
        var result = await httpClient.GetAsync(configuration["applicationUrl"] + "/api/CofeeShop");
        if(result.IsSuccessStatusCode)
        {
            shops = await result.Content.ReadFromJsonAsync<List<CofeeShopDto>>();
        }
    }
}
