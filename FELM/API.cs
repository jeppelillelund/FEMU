using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
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
        public async Task<JObject> LoginQueryAsync(string userName, string password)
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
                                .Field("status")
                                .Field("type")
                                ),
                                "http://192.168.76.20:8080/",arguments: new[] { new GraphQLQueryArgument("username", userName), new GraphQLQueryArgument("password", hashedPassword) });
                var response = await query.Execute();
                JObject result = response["verifyLogin"];
                return result;
                // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";
            }
        }

        public async Task<JArray> GetItemsQueryAsync()
        {
                var query = client.CreateQuery(builder =>
                    builder.Field("Vare",
                        GetAllItems =>
                            GetAllItems
                                .Argument("ChoseEvent", "int", "ChoseEvent", true)
                                .Field("beskrivelse")
                                .Field("antal")
                                .Field("status")
                                ),
                                "http://192.168.76.20:8080/", arguments: new[] { new GraphQLQueryArgument("ChoseEvent", 1) });
                var response = await query.Execute();
                JArray result = response["Vare"];
                return result;
                // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";
        }

        public async Task<string> SetFavoritQueryAsync(string Event, string Vare, string Antal)
        {
            var query = client.CreateQuery(builder =>
                builder.Field("Vare",
                    SetFavorit =>
                        SetFavorit
                            .Argument("Event", "String", "Event", true)
                            .Argument("Vare", "String", "Vare", true)
                            .Argument("Antal", "String", "Antal", true)
                            ),
                            "http://192.168.76.20:8080/", arguments: new[] 
                            {   new GraphQLQueryArgument("Event", Event), 
                                new GraphQLQueryArgument("Vare", Vare),
                                new GraphQLQueryArgument("Antal", Antal)
                            });

            var response = await query.Execute();
            string result = response["Vare"];
            return result;
            // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";
        }

        public async Task<JArray> AllEventsQueryAsync()
        {
                var query = client.CreateQuery(builder => builder.Field("Event",
                        GetAllEvents =>
                            GetAllEvents
                                .Field("EventName")
                                .Field("EventId")
                                ),
                                "http://192.168.76.20:8080/");
            var response = await query.Execute();
            JArray result = response["Event"];
                return result;
                // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";
        }

        public async Task<JArray> AllFavoritsQuery()
        {
            var query = client.CreateQuery(builder => builder.Field("Vare",
                        GetAllFavorits =>
                            GetAllFavorits
                                .Argument("favorit", "int", "favorit", true)
                                .Field("beskrivelse")
                                ),
                                "http://192.168.76.20:8080/", arguments: new[] { new GraphQLQueryArgument("favorit", 1) });
            var response = await query.Execute();
            JArray result = response["Vare"];
            return result;
            // builderResponse["verifiedLogin"]["verified"] ? "true" : "false";
        }
    }
}
    


