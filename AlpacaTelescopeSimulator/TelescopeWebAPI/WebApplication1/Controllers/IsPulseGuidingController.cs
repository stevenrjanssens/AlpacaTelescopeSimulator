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
    public class ispulseguidingController : ControllerBase
    {
    private string methodName = nameof(canslewController).Substring(0, nameof(canslewController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<BoolResponse> Get(int ClientID, int ClientTransactionID)
        {
                       try
            {
                var result = Program.Simulator.IsPulseGuiding;
                Program.TraceLogger.LogMessage(methodName + " Get", "");

                return new BoolResponse(ClientTransactionID, ClientID, methodName,result);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                var response = new BoolResponse(ClientTransactionID, ClientID, methodName,false);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }
    }
}