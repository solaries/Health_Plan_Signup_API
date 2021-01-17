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
        ResponsMessage response = signUp.NewPlanSubscription(request);
        Assert.Equal("true",(response.Response=="Failed" && response.Message == "Invalid email address" ? "true":"false")); 
    }

}