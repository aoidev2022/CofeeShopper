using IdentityServer4.Models;

namespace IdentityServer;

public class Config
{
    public static IEnumerable<IdentityResource> IdentityResources => new[] {
        new IdentityResources.OpenId(),
        new IdentityResources.Profile(),
        new IdentityResource
        {
            Name = "role",
            UserClaims = new List<string> {"role"}
        }
    };

    public static IEnumerable<ApiScope> ApiScopes => new[]
    {
        new ApiScope("CofeeShop.API.read"),
        new ApiScope("CofeeShop.API.write")
    };

    public static IEnumerable<ApiResource> ApiResources => new[]
    {
        new ApiResource("CofeeShop.API")
        {
            Scopes = new [] { "CofeeShop.API.read", "CofeeShop.API.write" },
            ApiSecrets = new [] { new Secret("scopedSecret".Sha256()) },
            UserClaims = new List<string> { "role" }
        }
    };

    public static IEnumerable<Client> Clients => new[]
    {
        new Client()
        {
            ClientId = "m2m.client",
            ClientName = "Client_Credentials",
            AllowedGrantTypes = GrantTypes.ClientCredentials,
            ClientSecrets = new Secret[] { new Secret("clientSecret1".Sha256()) },
            AllowedScopes = { "CofeeShop.API.read" }
        },
        new Client()
        {
            ClientId = "interactive",
            ClientName = "Client_Interactive",
            AllowedGrantTypes = GrantTypes.Code,
            ClientSecrets = new Secret[] { new Secret("clientSecret1".Sha256()) },
            AllowedScopes = { "openid", "profile", "CofeeShop.API.read" },
            RedirectUris = { "https://localhost:???/signin-oidc" },
            FrontChannelLogoutUri = "https://localhost:???/signout-oidc",
            PostLogoutRedirectUris = { "https://localhost:???/signout-callback-oidc" },
            AllowOfflineAccess = true,
            RequirePkce = true,
            RequireConsent = true,
            AllowPlainTextPkce = true,
        }
    };
}
