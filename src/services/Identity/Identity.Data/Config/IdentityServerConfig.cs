using System.Collections.Generic;
using System.Linq;
using IdentityServer4;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using IdentityServer4.Models;

namespace Identity.Data.Config
{
    public static class IdentityServerConfig
    {
        public static IEnumerable<IdentityResource> IdentityResources =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };

        public static IEnumerable<ApiResource> Apis =>
            new ApiResource[]
            {
                new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
            };

        public static IEnumerable<Client> Clients =>
            new Client[]
            {
                // SPA client using code flow + pkce
                new Client
                {
                    ClientId = "spa",
                    ClientName = "SPA Client",
                    ClientUri = "http://identityserver.io",
                    AllowedGrantTypes = GrantTypes.Code,
                    RequirePkce = true,
                    RequireClientSecret = false,
                    RedirectUris =
                    {
                        "http://localhost:5002/index.html",
                        "http://localhost:5002/callback.html",
                        "http://localhost:5002/silent.html",
                        "http://localhost:5002/popup.html",
                    },
                    PostLogoutRedirectUris = { "http://localhost:5002/index.html" },
                    AllowedCorsOrigins = { "http://localhost:5002" },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        IdentityServerConstants.LocalApi.ScopeName
                    }
                }
            };

        /// <summary>
        /// Adds/Updates the configuration DB context 
        /// with the static Identity Resource configurations defined in code.
        /// Persists this to the store.
        /// </summary>
        /// <param name="context"></param>
        public static void SaveIdentityResources(ConfigurationDbContext context)
        {
            foreach (var resource in IdentityResources)
            {
                var savedResource = context.IdentityResources.FirstOrDefault(r => r.Name == resource.Name);
                if (savedResource == null)
                {
                    context.IdentityResources.Add(resource.ToEntity());
                }
                else
                {
                    savedResource = resource.ToEntity();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds/Updates the configuration DB context 
        /// with the static API Resource configurations defined in code.
        /// Persists this to the store.
        /// </summary>
        /// <param name="context"></param>
        public static void SaveApis(ConfigurationDbContext context)
        {
            foreach (var resource in Apis)
            {
                var savedResource = context.ApiResources.FirstOrDefault(r => r.Name == resource.Name);
                if (savedResource == null)
                {
                    context.ApiResources.Add(resource.ToEntity());
                }
                else
                {
                    savedResource = resource.ToEntity();
                }
            }
            context.SaveChanges();
        }

        /// <summary>
        /// Adds/Updates the configuration DB context 
        /// with the static Client configurations defined in code.
        /// Persists this to the store.
        /// </summary>
        /// <param name="context"></param>
        public static void SaveClients(ConfigurationDbContext context)
        {
            foreach (var client in Clients)
            {
                var savedClient = context.Clients.FirstOrDefault(c => c.ClientId == client.ClientId);
                if (savedClient == null)
                {
                    context.Clients.Add(client.ToEntity());
                }
                else
                {
                    savedClient = client.ToEntity();
                }
            }
            context.SaveChanges();
        }
    }
}