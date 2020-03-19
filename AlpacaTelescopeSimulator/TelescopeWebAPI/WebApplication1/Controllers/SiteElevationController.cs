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
    public class siteelevationController : ControllerBase
    {
        private string methodName = nameof(siteelevationController).Substring(0, nameof(siteelevationController).IndexOf("Controller"));
        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
            DoubleResponse result = new DoubleResponse(ClientID, ClientTransactionID, methodName, 100);
            return result;
        }


        // PUT: api/DeclinationRate/5
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] int SiteElevation)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }
    }
}