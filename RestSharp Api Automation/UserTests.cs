using NUnit.Framework;
using RestSharp_Api_Automation.Drivers;

namespace RestSharp_Api_Automation;

public class Tests
{
    
    private Api _api = new();
    
    [SetUp]
    public void Setup()
    {
        _api.baseUrl = "https://petstore.swagger.io/v2";
    }

    [Test]
    public void Test1()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }
    
    [Test]
    public void Test2()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }   
    [Test]
    public void Test3()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }
    
    

    [TearDown]
    public void Stop()
    {
        _api.baseUrl = "";
        _api.Dispose();
    }
}