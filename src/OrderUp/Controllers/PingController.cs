using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace OrderUp.Controllers
{
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        private readonly ILogger<PingController> _logger;
        
        public PingController(ILogger<PingController> logger)
        {
            _logger = logger;
        }
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromHeader(Name = "X-Signature-Ed25519")] string signature, [FromHeader(Name = "X-Signature-Timestamp")]string timestamp)
        {
            _logger.LogInformation("Signature: {sig}", signature);
            _logger.LogInformation("Timestamp: {ts}", timestamp);

            return new JsonResult(new {type = 1});
        }
    }
}
