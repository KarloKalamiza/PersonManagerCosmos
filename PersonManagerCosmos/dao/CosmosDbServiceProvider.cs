using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PersonManagerCosmos.dao
{
    public class CosmosDbServiceProvider
    {
        private const string DatabaseName = "PersonManagerCosmos";
        private const string ContainerName = "personmanager";
        private const string Account = "https://personmanager.documents.azure.com:443/";
        private const string Key = "QT07Xk0wVb5u1YtVv81XPZ2QIHAqZVKlibZO1bkQUNYSVeYcovZZyAduGTgczOC77T0DGhi3BruoACDbqah3Ew==";

        private static ICosmosDbService cosmosDbService;

        public static ICosmosDbService CosmosDbService { get => cosmosDbService; }

        public async static Task Init()
        {
            CosmosClient client = new CosmosClient(Account, Key);
            cosmosDbService = new CosmosDbService(client, DatabaseName, ContainerName);
            DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(DatabaseName);
            await database.Database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
        }
    }
}