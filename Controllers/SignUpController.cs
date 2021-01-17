 
using Microsoft.AspNetCore.Mvc;  
using health_plan_signup_api.Models;
using health_plan_signup_api.data;
using System; 
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using System.IO;

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
            Enrollees enrollee = new Enrollees();
            if (enrollee.get_enrollees($" where email = '{request.Email}'").Count ==1){
                message.Response = "Failed";
                message.Message = "Enrollee data already exists"; 
                return message;
            }
            //the paramters receveied are not being used because the sandbox expects hard code data
            string  Referral_code = "1122345";
            Enrollee[] enrollees = new Enrollee[2];
            enrollees[0] = new Enrollee();
            enrollees[1] = new Enrollee();
            enrollees[0].payment_frequency = "monthly";
            enrollees[0].first_name = "John";
            enrollees[0].last_name = "Doe";
            enrollees[0].email_address = "testuser1@kang.pe";
            enrollees[0].phone_number = "08132646940";
            enrollees[0].plan_id = 22;
            enrollees[0].can_complete_profile = true;
            enrollees[0].dependants = new Dependant[2];
            enrollees[0].dependants[0] = new Dependant();
            enrollees[0].dependants[1] = new Dependant();
            enrollees[0].dependants[0].first_name = "Janet";
            enrollees[0].dependants[0].last_name = "Dependant";
            enrollees[0].dependants[0].email_address = "testuser2@kang.pe";
            enrollees[0].dependants[0].phone_number = "08132646940";
            enrollees[0].dependants[0].plan_id = 22;
            enrollees[0].dependants[1].first_name = "Fred";
            enrollees[0].dependants[1].last_name = "Dependant";
            enrollees[0].dependants[1].email_address = "testuser3@kang.pe";
            enrollees[0].dependants[1].phone_number = "08132646940";
            enrollees[0].dependants[1].plan_id = 24;
            enrollees[1].payment_frequency = "q";
            enrollees[1].first_name = "Ben";
            enrollees[1].last_name = "Stiller";
            enrollees[1].email_address = "snr22325@awsoo.com";
            enrollees[1].phone_number = "08132646940";
            enrollees[1].plan_id = 24;
            enrollees[1].can_complete_profile = false; 
            var enrollement = new {Referral_code= Referral_code,enrollees = enrollees };
            var json = JsonConvert.SerializeObject(enrollement, Formatting.Indented);  
            var request22 = (HttpWebRequest)WebRequest.Create("https://sandboxapi.fsi.ng/relianceHMO/retail/signup");
            var postData =json.Replace("null", "[]");
            var data1 = Encoding.ASCII.GetBytes(postData);
            request22.Method = "POST";
            request22.Headers.Add("Sandbox-Key", request.Sandbox_Key);
            request22.ContentType = "application/json";
            request22.ContentLength = data1.Length;  
            var responseString=""; 
            var result = "";
            using (var streamProcess = request22.GetRequestStream())
            {
                streamProcess.Write(data1, 0, data1.Length);
            }
            try
            {
                var newHttpResponse = (HttpWebResponse)request22.GetResponse();
                responseString = new StreamReader(newHttpResponse.GetResponseStream()).ReadToEnd();
                dynamic passString = JsonConvert.DeserializeObject<dynamic>(responseString);
                result = (string)passString.access_token;
            }
            catch (Exception d)
            {
            }   
            if(responseString.IndexOf("\"message\":\"OK\"") > -1){ 
                Enrollees_Table enrolleesData = new Enrollees_Table();
                enrolleesData.Email=request.Email; 
                enrolleesData.First_name=request.FirstName;
                enrolleesData.Last_name=request.LastName;
                enrolleesData.Phone=request.Phone;   
                enrollee.add_enrollees(enrolleesData);  
            }
            else{ 
                message.Response = "Failed";
                message.Message = "Enrollment failed"; 
                return message;
            }  
            message.Response = "Successful";
            message.Message = "Enrollee data captured successfully";                       
            return message;
            
        }
    }
}
