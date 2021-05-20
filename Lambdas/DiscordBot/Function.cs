using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.Core;
using Chaos.NaCl;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace DiscordBot
{
    public class Function
    {
        public APIGatewayProxyResponse Ping(APIGatewayProxyRequest request, ILambdaContext context)
        {
            // todo get this from secrets manager or env
            var publicKey = "";
            
            var signature = request.Headers["X-Signature-Ed25519"];
            var timestamp = request.Headers["X-Signature-Timestamp"];

            context.Logger.Log($"signature {signature}");
            context.Logger.Log($"timestamp {timestamp}");
            
            var response = new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.Unauthorized,
                Body = $"unauthorized",
                Headers = new Dictionary<string, string> { { "Content-Type", "text/plain" } }
            };

            return response;
        }
    }
}