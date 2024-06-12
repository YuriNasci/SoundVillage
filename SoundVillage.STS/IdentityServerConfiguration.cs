using IdentityServer4;
using IdentityServer4.Models;

namespace SoundVillage.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResource() {
            return new List<ApiResource>()
            {
                new ApiResource("soundvillage-api", "SoundVillage", new string[] {"soundvillage-user"})
                {
                    ApiSecrets =
                    {
                        new Secret("SoundVillageSecret".Sha256())
                    },
                    Scopes =
                    {
                        "SoundVillageScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes() {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "SoundVillageScope",
                    DisplayName = "SoundVillage API",
                    UserClaims = { "soundvillage-user" }
                }
            };
        }

        public static IEnumerable<Client> GetClients() {
            return new List<Client>()
            {
                new Client() {
                    ClientId = "client-angular-soundvillage",
                    ClientName = "Acesso do front as APIs",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SoundVillageSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SoundVillageScope"
                    }
                }
            };
        }
    }
}
