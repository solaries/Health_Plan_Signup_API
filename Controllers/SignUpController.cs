using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace health_plan_signup_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SignUpController : ControllerBase
    {
      

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }
        public SignUpController()
        { 
        }

        [HttpPost]
        public ResponsMessage NewPlanSubscription([FromBody] RequestMessage request)
        { 
            ResponsMessage message = new ResponsMessage();

            message.Response = "ok";
            message.Message = "ok";

            if(request.Email.Trim().Length < 5 || request.Email.Trim().Length > 50){
                message.Response = "Failed";
                message.Message = "Invalid email address"; 
            }
            return message;
            
        }
    }
}
