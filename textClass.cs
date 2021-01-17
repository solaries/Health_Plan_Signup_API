using Xunit;
using health_plan_signup_api;
using health_plan_signup_api.Controllers;
using System.Collections.Generic;

public class TestClass{
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
}