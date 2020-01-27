// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using IdentityServer.Interface;
using IdentityServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Collections.Generic;

namespace IdentityServer
{
    //F3 创建配置类   
    public static class Config
    {


        public static IUsers iusers { get; set; }

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


                new Client() //创建客户端连接
                 {
                ClientId = "client1",
                
                //配置验证类型为客户端验证
                AllowedGrantTypes = GrantTypes.ClientCredentials,

                //加密Secret   
               ClientSecrets =new List<Secret> {
                       new Secret("Secret1".Sha256())
                   },

               //该Client可以访问的Resource
                AllowedScopes = { "Api1" }
                  },
                new Client()//创建密码连接
                {

                    ClientId="client2",
                    AllowedGrantTypes=GrantTypes.ResourceOwnerPassword,

                        //加密Secret   
               ClientSecrets =new List<Secret> {
                       new Secret("Secret2".Sha256())
                   },

                //该Client可以访问的Resource
                AllowedScopes = { "Api1" }

                }

            };

        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers() {

            return new List<TestUser> {
             new TestUser{ 
             SubjectId="1",
             Username="zs",
             Password="123"
             },
              new TestUser{
             SubjectId="2",
             Username="ls",
             Password="123"
             }
            };
        
        }


    }


}