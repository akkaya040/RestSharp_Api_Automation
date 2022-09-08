using NUnit.Framework;

namespace RestSharp_Api_Automation.Tests;

[TestFixture]
public class UserTests: BaseTest
{
    
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
        
        Assert.Fail();
    }   
    [Test]
    public void Test3()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }
    
    

    
}