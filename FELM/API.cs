using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using SAHB.GraphQL;
using SAHB.GraphQLClient;
using SAHB.GraphQLClient.Extentions;
using SAHB.GraphQLClient.FieldBuilder.Attributes;
using SAHB.GraphQLClient.QueryGenerator;

namespace FELM
{



    public class API
    {
        IGraphQLHttpClient client = GraphQLHttpClient.Default();

       
        public async Task<bool> LoginQuery(string userName, string password)
        {


            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", String.Empty);


                Console.WriteLine("-----");
                Console.WriteLine("-----");
                Console.WriteLine(hashedPassword);
                Console.WriteLine("-----");
                Console.WriteLine("-----");

            
                var query = client.CreateQuery(builder =>
                    builder.Field("verifyLogin",
                        verifyLogin =>
                            verifyLogin
                                .Argument("username", "String", "username", true)
                                .Argument("password", "String", "password", true)
                                ),
                                "http://192.168.76.20:8080/",arguments: new[] { new GraphQLQueryArgument("username", userName), new GraphQLQueryArgument("password", hashedPassword) });
                var builderResponse = await query.Execute();
                Console.WriteLine("-----");
                Console.WriteLine("-----");
                Console.WriteLine(builderResponse["verifiedLogin"]);
                return builderResponse["verifiedLogin"]["verified"];
            
            }
        }
    }
    


}