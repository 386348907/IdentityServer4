// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer4.Models;
using System.Collections.Generic;

namespace IdentityServer
{
    //F3 创建配置类   
    public static class Config
    {
        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        /// <summary>
        /// 返回APIResource
        /// </summary>
        public static IEnumerable<ApiResource> GetApiResources =>
            new ApiResource[]
            {
                new ApiResource("Api1", "My Api1")
            };


        /// <summary>
        /// 创建客户端
        /// </summary>
        public static IEnumerable<Client> GetClient()
        {


            return new List<Client> {


                new Client()
                 {
                ClientId = "client1",
                
                //配置验证类型为客户端验证
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                //加密Secret   
               ClientSecrets =new List<Secret> {
                       new Secret("Secret1".Sha256())
                   },

               //该客户端可以访问的Resource
                AllowedScopes = { "Api1" }
                  } 
            
            };

        }
    }


}