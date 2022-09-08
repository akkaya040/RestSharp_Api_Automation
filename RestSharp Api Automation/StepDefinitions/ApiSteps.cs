using System.Net;
using AventStack.ExtentReports.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp_Api_Automation.PetStoreApi.Dtos;
using RestSharp_Api_Automation.Drivers;

namespace RestSharp_Api_Automation.StepDefinitions
{
    public static class ApiSteps
    {
        public static User InitializeUser(string firstName, string lastName, string userName)
        {
            return new User()
            {
                id = int.Parse(Randomizer.GenerateRandomId()),
                firstName = firstName,
                lastName = lastName,
                username = userName,
                email = Randomizer.GenerateRandomEmail(),
                password = Randomizer.GenerateRandomString(),
                phone = Randomizer.GenerateRandomPhoneNumber(),
                userStatus = 1
            };
        }
        
    }
}