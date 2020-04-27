using System;
using System.Collections.Generic;
using Models;
using System.Text;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer
{
    public class Config
    {

        private static Data.IdentityServerDbContext _identityServerDbContext { get; set; }

        public Config(Data.IdentityServerDbContext identityServerDbContext)
        {
            _identityServerDbContext = identityServerDbContext;
        }


        public static IEnumerable<IdentityResource> Ids =>
            new IdentityResource[]
            {
                new IdentityResources.OpenId()
            };

        /// <summary>
        /// 返回APIResource
        /// </summary>
        public static IEnumerable<ApiResource> GetApiResources([FromServices] Data.IdentityServerDbContext IdentityServerDB)
        {

            var apis = from a in IdentityServerDB.aPIS
                       select a;

            apis = apis.Where(T => T.apiStart != -1);
            var apiList = apis.ToList();

            List<ApiResource> apiResources = new List<ApiResource>();

            foreach (var item in apiList)
            {

                apiResources.Add(new ApiResource(item.apiName, item.apiDisplayName));

            }

            return apiResources;

        }
 
        /// <summary>
        /// 创建客户端
        /// </summary>
        public static IEnumerable<Client> GetClient([FromServices] Data.IdentityServerDbContext IdentityServerDB)
        {
 
            var cliList = from c in IdentityServerDB.userClient
                          select c;

            cliList = cliList.Where(T => T.status != -1);
 
            var dbCliList = cliList.ToList();

            List<Client> clientList = new List<Client>();

            foreach (var item in dbCliList)
            {

                Client client = new Client();

                client.ClientId = item.ClientId;

                client.ClientName = item.ClientName;

                //查询每个cli的API
                var clientSecretsList = IdentityServerDB.userSecret.Where(T => T.clientId==item.ClientId).ToList();

                foreach (var itemThree in clientSecretsList)
                {
             
                    switch (itemThree.pwType)
                    {

                        case "Sha256":
                            client.ClientSecrets.Add(new Secret(itemThree.secretName.Sha256()));
                            break;
                        case "Sha512":
                            client.ClientSecrets.Add(new Secret(itemThree.secretName.Sha512()));
                            break;
                
                        default:
                            throw new Exception($"加密方式未实现！{itemThree.pwType}");
                      
                    }
 
                }
 
                switch (item.AllowedGrantTypes)
                {
                    case "ClientCredentials": //客户端认证
                        client.AllowedGrantTypes = GrantTypes.ClientCredentials;
                        break;
                    case "ResourceOwnerPassword"://密码
                        client.AllowedGrantTypes = GrantTypes.ResourceOwnerPassword;
                        break;
                    case "ResourceOwnerPasswordAndClientCredentials"://客户端和密码
                        client.AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials;
                        break;
                    case "Implicit"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.Implicit;
                        break;

                    case "ImplicitAndClientCredentials"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.ImplicitAndClientCredentials;
                        break;

                    case "Hybrid"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.Hybrid;
                        break;

                    case "HybridAndClientCredentials"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.HybridAndClientCredentials;
                        break;


                    case "Code"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.Code;
                        break;

                    case "CodeAndClientCredentials"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.CodeAndClientCredentials;
                        break;

                    case "DeviceFlow"://TODO 不知道是啥
                        client.AllowedGrantTypes = GrantTypes.DeviceFlow;
                        break;


                    default:
                        throw new Exception($"Client Type 错了！{item.AllowedGrantTypes}");

                }

                //查询每个cli的API
                var allowedScopesList = IdentityServerDB.userAllowedScopes.Where(T => T.scopesStatus != -1&T.ClientId==item.ClientId).ToList();

                foreach (var itemTwo in allowedScopesList)
                {

                    var apisList = IdentityServerDB.aPIS.Where(T => T.apiStart != -1 & T.ID == itemTwo.aPIID).FirstOrDefault();

                    client.AllowedScopes.Add(apisList.apiName);

                }
                clientList.Add(client);
            }

            return clientList;
 
        }

        /// <summary>
        /// 获取用户
        /// </summary>
        /// <returns></returns>
        public static List<TestUser> GetUsers([FromServices] Data.IdentityServerDbContext IdentityServerDB)
        {
            try
            {


                var qdUser = from u in IdentityServerDB.users
                             select u;


                qdUser = qdUser.Where(T => T.status != -1);

                var List = qdUser.ToList();

                var retList = new List<TestUser>();
                foreach (var item in List)
                {

                    TestUser ts = new TestUser();

                    ts.SubjectId = item.SubjectId;

                    ts.Username = item.uName;

                    ts.Password = item.password;

                    retList.Add(ts);

                }

                return retList;
            }
            catch (Exception ex)
            {
                var xxxx = ex.Message;
                throw;
            }



        }
    }
}
