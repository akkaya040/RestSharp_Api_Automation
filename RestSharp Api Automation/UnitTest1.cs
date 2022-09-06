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
        string responseString = _api.responseString;
        
        Assert.Pass();
    }

    [TearDown]
    public void Stop()
    {
        
    }
}