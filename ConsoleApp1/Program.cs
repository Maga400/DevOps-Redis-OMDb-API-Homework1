using Azure.Storage.Queues;
using System;
using System.Threading.Tasks;

string connectionString = "";
string queueName = "newqueue";

QueueClient queueClient = new QueueClient(connectionString, queueName);
await queueClient.CreateIfNotExistsAsync();

if (queueClient.Exists())
{
    while (true)
    {
        Console.WriteLine("Please, enter film name: ");
        string message = Console.ReadLine();

        try
        {
            await queueClient.SendMessageAsync(message, TimeSpan.FromSeconds(0), TimeSpan.FromMinutes(10));
            Console.WriteLine($"Message sent successfully: {message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending message to queue: {ex.Message}");
        }
    }
}
else
{
    Console.WriteLine($"Queue storage encountered a problem: {queueName}");
}
