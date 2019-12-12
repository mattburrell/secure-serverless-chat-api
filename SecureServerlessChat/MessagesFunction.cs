using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace SecureServerlessChat
{
    public static class MessagesFunction
    {
        [FunctionName("messages")]
        public static Task SendMessage(
                    [HttpTrigger(AuthorizationLevel.Function, "post")] object message,
                    [SignalR(HubName = "chat")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "newMessage",
                    Arguments = new[] { message }
                });
        }
    }
}
