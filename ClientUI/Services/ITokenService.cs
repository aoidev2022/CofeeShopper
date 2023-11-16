using IdentityModel.Client;

namespace ClientUI.Services;

public interface ITokenService
{
    Task<TokenResponse> GetTokenAsync(string scope);
}
