using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using RestSharp_Api_Automation.PetStoreApi.Dtos;
using RestSharp_Api_Automation.StepDefinitions;
using Randomizer = RestSharp_Api_Automation.Drivers.Randomizer;

namespace RestSharp_Api_Automation.Tests;

[TestFixture]
[Category("User Tests")]
public class UserTests: Base
{
    
    [Order(1)]
    [Test,Description("/user/createWithList")]
    public void CreatingAUser()
    {
        _api.endPoint = "/user/createWithList";
        _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
        _api.restRequest = new RestRequest(_api.endPoint, Method.Post);

        User aUser = ApiSteps.InitializeUser("Kurtulus","Akkaya","kurtulusmakkaya");
        var userList = new List<User> {aUser};
        string jsonString = JsonConvert.SerializeObject(userList, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
        
        _api.restRequest.AddParameter("application/json", jsonString,  ParameterType.RequestBody);
        _api.restResponse = _api.restClient.ExecutePostAsync(_api.restRequest).GetAwaiter().GetResult();
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);

         
        _api.responseString = _api.restResponse.Content;
    }
    
    [Order(2)]
    [Test,Description("/user/createWithArray With Given Params")]
    [TestCase("kurtulus", "akkaya", "kurtulusakkaya")]
    public void CreatingAUserWithGivenParams(string name,string surname,string username)
    {
        _api.endPoint = "/user/createWithArray";
        _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
        _api.restRequest = new RestRequest(_api.endPoint, Method.Post);

        User aUser = ApiSteps.InitializeUser(name, surname, username);
        var userList = new List<User> {aUser};
        string jsonString = JsonConvert.SerializeObject(userList, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, Formatting = Formatting.Indented });
        
        _api.restRequest.AddParameter("application/json", jsonString,  ParameterType.RequestBody);
        _api.restResponse = _api.restClient.ExecutePostAsync(_api.restRequest).GetAwaiter().GetResult();
        
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);

    }
    
    
    [Order(3)]
    [Test,Description("Confirm User From Endpoint /user/username")]
    [TestCase("kurtulusakkaya")]
    public void GetUserByUsername(string username)
    {
        _api.endPoint = "/user/"+username;
        _api.GetRequest(_api.endPoint);
        
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);

        User responseUser = JsonConvert.DeserializeObject<User>(_api.responseString ?? throw new InvalidOperationException());
        Assert.AreEqual(responseUser.username, username);
        
    }   
    
    [Order(4)]
    [Test,Description("Update & Confirm User Update")]
    [TestCase("kurtulusakkaya")]
    public void UpdateUserByUsername(string username)
    {
        //Get User From Api
        GetUserByUsername(username);
        User userAtFirst = JsonConvert.DeserializeObject<User>(_api.responseString ?? throw new InvalidOperationException());

        //Set New Api Endpoint Params
        _api.endPoint = "/user/"+username;
        _api.restClient = new RestClient(_api.baseUrl ?? throw new InvalidOperationException());
        _api.restRequest = new RestRequest(_api.endPoint, Method.Put);

        string updatedPass = Randomizer.GenerateRandomString();
        userAtFirst.password = updatedPass;
        
        string jsonString = JsonConvert.SerializeObject(userAtFirst);
        
        _api.restRequest.AddParameter("application/json", jsonString,  ParameterType.RequestBody);
        _api.restResponse = _api.restClient.ExecutePutAsync(_api.restRequest).GetAwaiter().GetResult();
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);


        GetUserByUsername(username);
        User responseUser = JsonConvert.DeserializeObject<User>(_api.responseString ?? throw new InvalidOperationException());
        Assert.AreEqual(responseUser.username, username);
        Assert.AreEqual(responseUser.password,updatedPass);
        
    }
    
    [Order(5)]
    [Test,Description("Delete User By Username & Confirm")]
    [TestCase("kurtulusakkaya")]
    public void DeleteUserByUsername(string username)
    {

        _api.endPoint = "/user/" + username;
        _api.DelRequest(_api.endPoint);
        Assert.AreEqual(200,(int)_api.restResponse!.StatusCode);
    }
    
    [Order(6)]
    [Test,Description("Negative Test: Delete Not Exist User")]
    [TestCase("test_8716235")]
    public void DeleteUserByUsername2(string username)
    {

        _api.endPoint = "/user/" + username;
        _api.DelRequest(_api.endPoint);
        Assert.AreEqual(404,(int)_api.restResponse!.StatusCode);
    }


}