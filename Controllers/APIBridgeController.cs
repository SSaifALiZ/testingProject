﻿using WorkFlow.Models;
using Microsoft.AspNetCore.Mvc;

namespace WorkFlow.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    [ApiController]

    public class APIBridgeController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] APIBridgeRequest reqObj)
        {
            var response = APIBridge.POST(reqObj);
            return Ok(response);
        }
    }
}
