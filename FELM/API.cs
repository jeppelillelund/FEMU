using System;
using System.Collections.Generic;
using System.Linq;
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

        public Query testQuery;
        public void LoginQuery()
        {
            var response = client.Query<Query>("s-web01/graphql.php/",
                arguments: new GraphQLQueryArgument("userName", "anotherWord", "SomethingDifferent"));
        }
    }
    public class Query
    {
        [GraphQLArguments("userName", "password", "somethingvariable")]
        public string verifyLogin { get; set; }
        public string Password { get; set; }

    }
}