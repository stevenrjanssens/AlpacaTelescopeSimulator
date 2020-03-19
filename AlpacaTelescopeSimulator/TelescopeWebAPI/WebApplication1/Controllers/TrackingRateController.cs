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
    public class trackingrateController : ControllerBase
    {
        private string methodName = nameof(trackingrateController).Substring(0, nameof(trackingrateController).IndexOf("Controller"));
        // GET: api/DeclinationRate
        [HttpGet]
        public ActionResult<DoubleResponse> Get(int ClientID, int ClientTransactionID)
        {
 try
            {//TODO: return real value
                var result = Program.Simulator.TrackingRate;
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());
                return new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                DoubleResponse response = new DoubleResponse(ClientTransactionID, ClientID, methodName, 0);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
        
        [HttpPut]
        public ActionResult<MethodResponse> Put(int ClientID, int ClientTransactionID, [FromForm] double TrackingRate)
        {
            return new MethodResponse(ClientTransactionID, ClientID, methodName);
        }

    }
}