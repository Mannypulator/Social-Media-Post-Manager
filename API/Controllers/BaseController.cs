using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    internal int GetStatusCode(string responseCode)
    {
        return responseCode switch
        {
            "99" => StatusCodes.Status400BadRequest,
            "40" => StatusCodes.Status401Unauthorized,
            "41" => StatusCodes.Status401Unauthorized,
            "42" => StatusCodes.Status402PaymentRequired,
            "43" => StatusCodes.Status403Forbidden,
            "44" => StatusCodes.Status404NotFound,
            "45" => StatusCodes.Status405MethodNotAllowed,
            "46" => StatusCodes.Status406NotAcceptable,
            "55" => StatusCodes.Status500InternalServerError,
            "77" => StatusCodes.Status409Conflict,
            "00" => StatusCodes.Status200OK,
            _ => Convert.ToInt32(responseCode)
        };
    }
}