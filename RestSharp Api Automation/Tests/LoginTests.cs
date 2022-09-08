using System;
using System.Diagnostics;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp_Api_Automation.PetStoreApi.Dtos;
using RestSharp_Api_Automation.StepDefinitions;

namespace RestSharp_Api_Automation.Tests;

[TestFixture]
[Category("Login Tests")]
public class LoginTests: Base
{
    [Test]
    [Order(1)]
    [TestCase("loginkurtulus")]
    public void CreateAUserForLogin(string username)
    {
        _api.endPoint = "/user";
        _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
        _api.restRequest = new RestRequest(_api.endPoint, Method.Post);
        
        User aUser = ApiSteps.InitializeUser("Kurtulus", "Akkaya", username);
        aUser.password = "passwordKurtulus";
        
        string jsonString = JsonConvert.SerializeObject(aUser);
        
        _api.restRequest.AddParameter("application/json", jsonString,  ParameterType.RequestBody);
        _api.restResponse = _api.restClient.ExecutePostAsync(_api.restRequest).GetAwaiter().GetResult();
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);
    }
    
    [Test]
    [Order(2)]
    [TestCase("loginkurtulus", "passwordKurtulus")]
    public void LoginWithCorrectUserAndPass(string username,string passwd)
    {
        _api.endPoint = "/user/login?username="+username+"&"+"password="+passwd;
        _api.GetRequest(_api.endPoint);
        
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);

        string? responseMessage = _api.restResponse.Content;

        Assert.NotNull(responseMessage,"responseMessage == null");
        _api.apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseMessage ?? throw new InvalidOperationException());

        string sessionId = _api.apiResponse.Message.Split(":")[1];
        
        Assert.That(sessionId!.Length==13,"sessionId.Length should be equal to 13");

    }   
    
    
    [Test,Description("Negative Login Test Cases")]
    [Order(3)]
    public void LoginWithWrongUserAndPass([Random(2)] int username,[Random(2)] int passwd)
    {
        _api.endPoint = "/user/login?username="+username+"&"+"password="+passwd;
        _api.GetRequest(_api.endPoint);
        
        Assert.AreEqual(400,(int)_api.restResponse!.StatusCode);

    }  
    

}