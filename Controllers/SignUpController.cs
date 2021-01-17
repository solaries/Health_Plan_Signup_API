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
            if(request.Email.Trim().Length < 5 || request.Email.Trim().Length > 50){
                message.Response = "Failed";
                message.Message = "Invalid email address"; 
                return message;
            }
            if(request.FirstName.Trim().Length < 1 || request.FirstName.Trim().Length > 20){
                message.Response = "Failed";
                message.Message = "Invalid first name"; 
                return message;
            }
            if(request.LastName.Trim().Length < 1 || request.LastName.Trim().Length > 20){
                message.Response = "Failed";
                message.Message = "Invalid last name"; 
                return message;
            }
            if(request.Phone.Trim().Length != 11){
                message.Response = "Failed";
                message.Message = "Invalid phone number"; 
                return message;
            }
            if(request.Sandbox_Key.Trim().Length < 1){ 
                message.Response = "Failed";
                message.Message = "Invalid sandbox key"; 
                return message;
            } 
            return message;
            
        }
    }
}
