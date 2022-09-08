using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using RestSharp_Api_Automation.Drivers;
using RestSharp_Api_Automation.StepDefinitions;

namespace RestSharp_Api_Automation.Tests;

public class Base
{
    protected readonly Api _api = new();
    private ExtentReports? _extent;
    private ExtentTest? _test;

    [OneTimeSetUp]
    protected void OneTimeSetUp()
    {
        
        string projectPath = Path.GetFullPath(@"..\..\..\");
        if (!Directory.Exists(projectPath.ToString() + "Reports"))
            Directory.CreateDirectory(projectPath.ToString() + "Reports");
        
        var reportPath = projectPath + "Reports\\ExtentReport.html";
        var htmlReporter = new ExtentHtmlReporter(reportPath);
        _extent = new ExtentReports();
        _extent.AttachReporter(htmlReporter);
        _extent.AddSystemInfo("Host Name","https://petstore.swagger.io/");
        _extent.AddSystemInfo("Environment", "QA");
        _extent.AddSystemInfo("UserName", "Kurtulus Mehmet Akkaya");
    }
    
    [SetUp]
    public void Setup()
    {
        _test = _extent?.CreateTest(TestContext.CurrentContext.Test.Name);
        _api.baseUrl = "https://petstore.swagger.io/v2";
    }
    
    [TearDown]
    public void Stop()
    {
        _api.baseUrl = "";
        _api.Dispose();
        var status = TestContext.CurrentContext.Result.Outcome.Status;
        var stackTrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace)? ""
            : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
        Status logStatus;
        switch (status)
        {
            case TestStatus.Failed:
                logStatus = Status.Fail;
                DateTime time = DateTime.Now;
                _test?.Log(Status.Fail, "Fail");
                break;
            case TestStatus.Inconclusive:
                logStatus = Status.Warning;
                break;
            case TestStatus.Skipped:
                logStatus = Status.Skip;
                break;
            default:
                logStatus = Status.Pass;
                break;
        }
        _test?.Log(logStatus, "Test ended with: |||||->" + logStatus +"<-|||| Stacktrace: "+ stackTrace);
        //_extent.Flush();
    }
    
    
    [OneTimeTearDown]
    protected void OneTimeTearDown()
    {
        _extent?.Flush();
    }
    
    
}