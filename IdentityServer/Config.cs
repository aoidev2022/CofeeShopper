﻿using IdentityServer4.Models;

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

    public static IEnumerable<Client> Clients =>
            new[]
            {
                // m2m client credentials flow client
                new Client
                {
                    ClientId = "m2m.client",
                    ClientName = "Client Credentials Client",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedScopes = { "CofeeShop.API.read", "CofeeShop.API.write" }
                },
                // interactive client using code flow + pkce
                new Client
                {
                    ClientId = "interactive",
                    ClientSecrets = { new Secret("ClientSecret1".Sha256()) },
                    AllowedGrantTypes = GrantTypes.Code,
                    RedirectUris = { "https://localhost:5214/signin-oidc" },
                    FrontChannelLogoutUri = "https://localhost:5214/signout-oidc",
                    PostLogoutRedirectUris = { "https://localhost:5214/signout-callback-oidc" },
                    AllowOfflineAccess = true,
                    AllowedScopes = { "openid", "profile", "CofeeShop.API.read" },
                    RequirePkce = true,
                    RequireConsent = true,
                    AllowPlainTextPkce = false
                }
            };
}
