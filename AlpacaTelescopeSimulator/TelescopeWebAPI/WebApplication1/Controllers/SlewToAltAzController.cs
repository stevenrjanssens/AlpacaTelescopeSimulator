﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
   [Route("telescope/{device_number}/[controller]")]
    [ApiController]
    public class slewtoaltazController : ControllerBase
    {
        private string methodName = nameof(slewtoaltazController).Substring(0, nameof(slewtoaltazController).IndexOf("Controller"));

        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double Altitude, [FromForm] double Azimuth)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}