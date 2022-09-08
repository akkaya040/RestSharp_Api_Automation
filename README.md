# RestSharp Nunit Api Automation
Nunit RestSharp Api Test Automation Project

# Test Approach
The tests were created as functional testing, on every test run some checks and validation are done with certain inputs to verify that data is inserted, displayed, updated and deleted correctly. Also tests are supported negative response validation (Negative Tests).


# Project Solution
The tests are located in the test folder under the main directory. Base test includes nunit methods that work collaboratively for all tests. Tests can be run from LoginTests.cs and UserTests.cs. The Drivers folder contains the helper methods and the restsharp methods that we create the API requests. The PetStoreApi directory contains the dto objects we use for serialize and deserialize operations.


This type of solution was used for better code reusability, maintainability of the testing framework.


# Framework / Libraries / Tech Stack 

* C#
* .NET6.0
* RestSharp
* NUnit
* ExtendReport

This project is developed using C# with .NET6.0 with NUnit as the api testing framework and RestSharp as my .NET client for the APIs.



# Scenarios covered on the solution

**The following scenarios are cover by the automation test suite:**

* **Verify users can logIn / logOut(LoginTests.cs).**

* **(Negative) Verify users can't be loged in with wrong password(LoginTests.cs).**

* **Verify users can be created with list(UserTests.cs).**

* **Verify users can be created with array(UserTests.cs).**

* **Verify users can be get from api(UserTests.cs).**

* **(Negative) Verify non-users can not be get from api(UserTests.cs).**

* **Verify users can be Updated(UserTests.cs).**

* **Verify users can be Deleted(UserTests.cs).**

* **(Negative) Verify not exist users can not be Deleted(UserTests.cs).**

