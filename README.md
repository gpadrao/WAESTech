# WAES Tech Assignment

Provides an entire solution developed using Visual Studio Enterprise 2017 to complete the requirements received by email. This solution consists in a Web Api service, that implements the requested endpoints for the requirements.

## Technologies 
- Asp.Net Web Api
- .Net Framework 4.5.2
- C#
- Microsoft SQL Server 2016 Express Edition

## Nuget Packages
- EntityFramework 6.1.3
- NInject 3.2.2
- NInject.Web.Common 3.2.3
- NInject.Web.WebApi 3.2.4
- CommonServiceLocator 1.3.0
- MSTest.TestFramework 1.1.11
- MSTest.TestAdapter 1.1.11
- Newtonsoft.Json 10.0.3
- AutoMapper 3.2.1
- Swashbuckle 5.2.1
- Swashbuckle.Core 5.2.1
- Log4Net 2.0.8

## Projects within this solution

I've splitted up all projects according to DDD ( Domain Driven Design ) definitions.

#### Application / Service:
 - WAES.Web ( Web Api ). Must be set in Visual Studio as Start Project
 
#### Libraries
 - WAES.Application
 - WAES.Domain 
 - WAES.Infra.Data
 - WAES.Infra.CrossCutting.IoC
 - WAES.Infra.CrossCutting.Log
 - WAES.Infra.CrossCutting.Utilities
 
#### Test:

- Integration Test
  - WAES.Web.Tests
- Unit Tests
  - WAES.Application.Tests
  - WAES.Domain.Tests

## Downloading and Configuring the Application

- Download the source code.
- After unzip the file, locate the slnWAES.sln file and open it in your Visual Studio 2017 version.
- I highly recommend that you should click on Build -> Clean Solution menu to clear the code ( bin and obj folders )

![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/clean_solution.PNG)

- Right Click over the solution on Project Explorer Tab and click on "Restore Nuget Packages" menu. This action will update all packages used in this solution and will update all references.
 
![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/restore_nuget_packages.PNG)

- The solution needs a Microsoft SQL Server database to store information, so locate one available instance of SQL Server ( as mentioned  before, I've used the 2016 Express version ) and create a new database with your own login.
- In the solution, locate the **WAES.Infra.Data** project, than locate in this project a folder named **DatabaseScripts**. There is only one file named **CreateTablesWAES.sql**. The project should like the image below.

![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/opening_script.PNG)

- Open this file in your SQL IDE ( I always use the Microsoft SQL Server Management Studio ), select your new database that you should have created previously and then execute this script.
- After execute the script, your database should like the image below.

![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/database_tables_creation.PNG)

- Now it's time to configure the "connectionstring" property that is within the Web.config file located in the **WAES.Web** project. You will need to change the following values:
  - Server
  - Database
  - User Id
  - Password
- Current values of each of these parameters listed above start with "your" ( like the image below ), then you should, please, specify the correct values for all.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/connection_string.PNG)
 
 - That's all to run the application, but we will need to run Integration Test, so let's take an advantage that we are here and configure the **App.config** to point to the correct host. So, please locate the **WAES.Web.Tests** project and open its **App.config** file. If you plan to deploy the Api and run the tests pointing to this new address, please make sure to change the **urlBase** key in the AppSettings node. Now, this configured address is pointing to localhost. See the images below.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/web_tests_app_config.PNG)
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/app_config_tests.PNG)
 
 ## Swagger and Help Page
 
 OK, after creating the database and then configure all **.config** files, it's time to run the application. I used the **Swashbuckle** Nuget Package to provide **Swagger** support for running few tests before implementing the integration tests. So the Swagger page will be available just writing **/Swagger** at the end of base url, like **"http://yourapiaddress/swagger"**. In this case, you will be able to run a few tests and see the generated routes. See the Swagger page below.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/swagger.PNG)
 
 You can also access the **Help** page typing **"http://yourapiaddress/help"**, where you also can see the generated routes. See the Help page below.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/help_page.PNG)
 

## Integration Test and Unit Tests

Finally, the tests!

You will be able to see the tests in the **Test Explorer** tab ( Menu  = Test -> Windows -> Test Explorer ). The test list must look like the image below.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/test_explorer.PNG)
 
**Please, don't forget to check if the App.config file of the project "WAES.Web.Test" is pointing to the correct address and also check the connectionstring property in the Web.config file within the project "WAES.Web"**. If everything is correct, after running all tests, the results will be equal the image below.
 
 ![alt text](https://github.com/luisferop/WAESTech/blob/master/Images/test_explorer_success.PNG)
 
 ## Thank you!
 
Thank you and feel free to contact me if you have any problems.

Email: luisferop@gmail.com
Skype: luisfernandopereira
 
