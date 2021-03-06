﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASCOM.DeviceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASCOMCore;

namespace ASCOMCore.Controllers
{
    [Route("api/v1/telescope/{device_number}/[controller]")]
    [ApiController]
    public class axisratesController : ControllerBase
    {
        private string methodName = nameof(axisratesController).Substring(0, nameof(axisratesController).IndexOf("Controller"));

        [HttpGet]
        public ActionResult<AxisRatesResponse> Get(int ClientID, int ClientTransactionID, TelescopeAxes Axis)
        {

            try
            {  //TODO: Return real value
                var result = Program.Simulator.AxisRates(Axis);
                Program.TraceLogger.LogMessage(methodName + " Get", result.ToString());

                return new AxisRatesResponse(ClientTransactionID, ClientID, methodName,null);
            }
            catch (Exception ex)
            {
                Program.TraceLogger.LogMessage(methodName + " Get", string.Format("Exception: {0}", ex.ToString()));
                AxisRatesResponse response = new AxisRatesResponse(ClientTransactionID, ClientID, method:methodName,null);
                response.ErrorMessage = ex.Message;
                response.ErrorNumber = ex.HResult - Program.ASCOM_ERROR_NUMBER_OFFSET;
                return response;
            }
        }

    }
}