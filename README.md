# WAES Tech Assignment

Provides an entire solution develped using Visual Studio Enterprise 2017 to complete the requirements received by email. This solution consists in a Web Api service, that implements the requested endpoints for the requirements.

### Technologies 
- Asp.Net Web Api
- .Net Framework 4.5.2
- C#
- Microsoft SQL Server 2016 Express Edition

### Nuget Packages
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
