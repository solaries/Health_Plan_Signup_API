using Xunit; 
using health_plan_signup_api.Controllers; 
using health_plan_signup_api.Models;
using System;
using health_plan_signup_api.data;
public class Tests{
    // [Fact]
    // public void PasingWetherTest(){
    //     SignUpController signUp = new SignUpController();
    //     Assert.IsType<ResponsMessage>( signUp.NewPlanSubscription());
    // }
    [Fact]
    public void EmailLessThanFiveCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="abc";
        request.FirstName=""; 
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid email address" ? "true":"false")); 
    }

    [Fact]
    public void EmailGreaterThanFiftyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="abcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyz";
        request.FirstName=""; 
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid email address" ? "true":"false")); 
    }

    [Fact]
    public void EmailBewteen_5_AndFiftyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com";
        request.FirstName=""; 
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Message != "Invalid email address" ? "true":"false")); 
    }


    [Fact]
    public void FirstNameLessThanOneCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName=""; 
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid first name" ? "true":"false")); 
    }

    [Fact]
    public void FirstNameGreaterThanTwentyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="abcdefghijklmnopqrstuvwxyz";
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid first name" ? "true":"false")); 
    }

    [Fact]
    public void FirstNameBewteen_1_AndTwentyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Message != "Invalid first name" ? "true":"false")); 
    }





    [Fact]
    public void LastNameLessThanOneCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple"; 
        request.LastName="";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid last name" ? "true":"false")); 
    }

    [Fact]
    public void LastNameGreaterThanTwentyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="abcdefghijklmnopqrstuvwxyz";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid last name" ? "true":"false")); 
    }

    [Fact]
    public void LastNameBewteen_1_AndTwentyCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Message != "Invalid last name" ? "true":"false")); 
    }





    [Fact]
    public void PhoneLessThanElevenCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple"; 
        request.LastName="simple";
        request.Phone="123";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid phone number" ? "true":"false")); 
    }

    [Fact]
    public void PhoneGreaterThanElevenCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="123456789012";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid phone number" ? "true":"false")); 
    }

    [Fact]
    public void PhoneBewteenIsElevenCharacter(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="12345678901";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Message != "Invalid phone number" ? "true":"false")); 
    }




    [Fact]
    public void SandboxKeyNotEntered(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple"; 
        request.LastName="simple";
        request.Phone="12345678901";
        request.Sandbox_Key="";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid sandbox key" ? "true":"false")); 
    }

    [Fact]
    public void SandboxKeyEntered(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="12345678901";
        request.Sandbox_Key="123";
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Message != "Invalid sandbox key" ? "true":"false")); 
    } 

    [Fact]
    public void ValidateUniqueEmailCheckInDatabase(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="12345678901";
        request.Sandbox_Key="123";
        Enrollees enrollee = new Enrollees();
        if(enrollee.get_enrollees($" where email = '{request.Email}'").Count ==0){
            Enrollees_Table enrolleesData = new Enrollees_Table();
// please either try to check this email for every test or delete it's record from the database            
            enrolleesData.Email="simple@yahoo.com"; 
            enrolleesData.First_name="simple";
            enrolleesData.Last_name="simple";
            enrolleesData.Phone="12345678901";   
            enrollee.add_enrollees(enrolleesData);   
        }
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Enrollee data already exists" ? "true":"false")); 
    } 

    [Fact]
    public void SubmitPost(){
        SignUpController signUp = new SignUpController();
        RequestMessage request = new RequestMessage();
        request.Email="simple12@yahoo.com"; 
        request.FirstName="simple";
        request.LastName="simple";
        request.Phone="12345678901";
        request.Sandbox_Key="2"; 
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Successful" && response.Message == "Enrollee data captured successfully" ? "true":"false")); 
    } 
}