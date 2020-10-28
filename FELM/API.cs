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

       
        public async Task<string> LoginQueryAsync(string userName, string password)
        {


            using (SHA1 sha1Hash = SHA1.Create())
            {
                //From String to byte array
                byte[] sourceBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha1Hash.ComputeHash(sourceBytes);
                string hashedPassword = BitConverter.ToString(hashBytes).Replace("-", String.Empty);
                
                Console.WriteLine(hashedPassword);
            
                var query = client.CreateQuery(builder =>
                    builder.Field("verifyLogin",
                        verifyLogin =>
                            verifyLogin
                                .Argument("username", "String", "username", true)
                                .Argument("password", "String", "password", true)
                                ),
                                "http://192.168.76.20:8080/",arguments: new[] { new GraphQLQueryArgument("username", userName), new GraphQLQueryArgument("password", hashedPassword) });
                var response = await query.Execute();
                string result = response["verifyLogin"];
                return result;
                // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";

            }
        }

        public async Task<string> AllEventsQueryAsync()
        {
                var query = client.CreateQuery(builder => builder.Field("GetAllEvents"), "http://192.168.76.20:8080/");
                var response = await query.Execute();
                string result = response["GetAllEvents"];
                return result;
                // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";

        }
    }
}
    


