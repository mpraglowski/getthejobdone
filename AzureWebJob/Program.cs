using System.Configuration;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Jobs;
using Microsoft.WindowsAzure.StorageClient;

namespace AzureWebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(ConfigurationManager.ConnectionStrings["AzureJobsData"].ConnectionString);
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("input");
            queue.CreateIfNotExist();
            queue.AddMessage(new CloudQueueMessage("@wrocnet"));

            JobHost host = new JobHost();
            host.RunAndBlock();
        }

        public static void ProcessQueueMessage([QueueInput] string input, 
                                                  [BlobOutput("hello/out.txt")] out string output)
        {
            output = "Hello " + input;
        }
    }
}
