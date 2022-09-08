using NUnit.Framework;

namespace RestSharp_Api_Automation.Tests;

[TestFixture]
[Category("Login Tests")]
public class LoginTests: Base
{
    [Test]
    [Order(1)]
    public void CreateAUserForLogin()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }
    
    [Test]
    [Order(3)]
    public void Test2()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Fail();
    }   
    [TestCase]
    [Order(1)]
    public void Test3()
    {
        _api.endPoint = "/pet/findByStatus?status=available";
        _api.GetRequest(_api.endPoint);
        var responseString = _api.responseString;
        
        Assert.Pass();
    }

}