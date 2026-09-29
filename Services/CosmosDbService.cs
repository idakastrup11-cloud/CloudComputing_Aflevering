using Microsoft.Azure.Cosmos;
using SupportWebApp.Models;
using System.Collections.Concurrent;
using System.ComponentModel;

namespace SupportWebApp.Services;

public class CosmosDbService
{
    private readonly Microsoft.Azure.Cosmos.Container _container;

    public CosmosDbService(IConfiguration configuration)
    {
        CosmosClient client = new CosmosClient(
            configuration["CosmosDb:ConnectionString"]);

        _container = client.GetContainer(
            configuration["CosmosDb:DatabaseName"],
            configuration["CosmosDb:ContainerName"]);
    }

    public async Task CreateSupportMessageAsync(SupportMessage message)
    {
        Console.WriteLine("PRØVER AT GEMME I COSMOS");

        await _container.CreateItemAsync(
            message,
            new PartitionKey(message.Category));

        Console.WriteLine("GEMT I COSMOS");
    }
}