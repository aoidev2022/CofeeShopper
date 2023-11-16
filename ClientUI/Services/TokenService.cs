using IdentityModel.Client;

using Microsoft.Extensions.Options;

namespace ClientUI.Services;

public class TokenService : ITokenService
{
    private readonly IOptions<IdentityServerSettings> _identityServerSettings;
    private readonly DiscoveryDocumentResponse _discoveryDocument;
    private readonly HttpClient _httpClient;

    public TokenService(IOptions<IdentityServerSettings> identityServerSettings)
    {
        _identityServerSettings = identityServerSettings;

        _httpClient = new HttpClient();

        _discoveryDocument = _httpClient.GetDiscoveryDocumentAsync(_identityServerSettings.Value.DiscoveryUrl).Result;

    }

    public async Task<TokenResponse> GetTokenAsync(string scope)
    {
        var rq = new ClientCredentialsTokenRequest
        {
            Address = _discoveryDocument.TokenEndpoint,
            ClientId = _identityServerSettings.Value.ClientName,
            ClientSecret = _identityServerSettings.Value.ClientPassword
        };

        var response = await _httpClient.RequestClientCredentialsTokenAsync(rq);

        if(response.IsError)
            throw new Exception("Unable to get token");

        return response;
    }
}
