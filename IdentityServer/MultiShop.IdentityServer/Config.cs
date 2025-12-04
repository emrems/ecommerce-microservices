// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4;
using IdentityServer4.Models;
using System.Collections.Generic;

namespace MultiShop.IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiResource> ApiResources => new ApiResource[]// ApiResources propu çağrıldığı zaman her microservice için bir key tanımlayacak
        {
            new ApiResource("ResourceCatalog")
            {
                Scopes={"CatalogFullPermisson","CatalogReadPermission"}//ResourceCatalog keyine sahip olan biri CatalogFullPermisson scopundaki tüm işlemleri yapabilir. Scopesun içine başka izinler de yazabilirz
            },
            new ApiResource("ResourceDiscount")
            {
                Scopes={ "DiscountFullPermission" }
            },
            new ApiResource("ResourceOrder")
            {
                Scopes = {"OrderFullPermission"}
            },
             new ApiResource("ResourceCargo")
            {
                Scopes = {"CargoFullPermission"}
            },
            new ApiResource(IdentityServerConstants.LocalApi.ScopeName)
        };

        //IdentityResources ifadesi ile tokenini aldığım kullanıcının 3 değerine erişebilicem token içinde
        public static IEnumerable<IdentityResource> IdentityResources => new IdentityResource[]
        {
            new IdentityResources.OpenId(),
            new IdentityResources.Email(),
            new IdentityResources.Profile()
        };

        public static IEnumerable<ApiScope> ApiScopes => new ApiScope[]
        {
            //CatalogFullPermisson tokenına sahip kişi "Full authority for catalog operations" işlemlerinin hepsini yapabilecek
            new ApiScope("CatalogFullPermisson","Full authority for catalog operations"),
            new ApiScope("CatalogReadPermission","Reading authority for catalog operations"),
            new ApiScope("DiscountFullPermission","Reading authority for discount operations"),
            new ApiScope("OrderFullPermission","Reading authority for order operations"),
            new ApiScope("CargoFullPermission","Reading authority for cargo operations"),
            new ApiScope(IdentityServerConstants.LocalApi.ScopeName)
        };

        // kendi clientlerimizi oluşturacağız
        public static IEnumerable<Client> Clients => new Client[]
        {
            //visitor
            new Client
            {
                ClientId="MultiShopVisitorId",
                ClientName="MultiShop Visitor User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("multishopsecret".Sha256())
                },
                AllowedScopes={ "DiscountFullPermission" }

            },
            //Manger
            new Client
            {
                 ClientId="MultiShopManagerId",
                ClientName="MultiShop Manager User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("multishopsecret".Sha256())
                },
                AllowedScopes={ "CatalogReadPermission", "CatalogFullPermisson" }

            },
            //admin
            new Client
            {
                ClientId="MultiShopAdminId",
                ClientName="MultiShop Admin User",
                AllowedGrantTypes=GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("multishopsecret".Sha256())
                },
                AllowedScopes =
                {   "CatalogReadPermission",
                    "CatalogFullPermisson",
                    "DiscountFullPermission",
                    "OrderFullPermission",
                    "CargoFullPermission",
                    IdentityServerConstants.LocalApi.ScopeName,
                    IdentityServerConstants.StandardScopes.Email,
                    IdentityServerConstants.StandardScopes.OpenId,
                    IdentityServerConstants.StandardScopes.Profile
                },
                AccessTokenLifetime=600//token ömrü

            }
        };
    }
}