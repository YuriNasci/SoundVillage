using System;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace SoundVillage.ProcessaNotificacao
{
    public class Function1
    {
        [FunctionName("Function1")]
        public void Run([ServiceBusTrigger("notification", Connection = "ServicebusConnectionString")] ServiceBusReceivedMessage myQueueItem, ILogger log)
        {
            log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem.Body.ToString()}");
        }
    }
}
