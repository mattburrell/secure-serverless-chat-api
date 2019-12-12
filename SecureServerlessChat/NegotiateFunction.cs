using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace SecureServerlessChat
{
    public static class NegotiateFunction
    {
        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
            [HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req,
            [SignalRConnectionInfo(HubName = "chat")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }
    }
}
