# Multi-targeting Demo
The demo uses 4 tags to show different states of an application.  For this example the scenario is that an existing WCF service and client writting in .NETFramework version 4.7 exist, and we want to move the client to netcore 2.2 to run on linux.

The WCF Scenario is something I think might be common.  I want to show that WCF contracts can be converted to be used by both .NETFramework and netcore, and that applications can be converted to netcore from .NETFramework in some cases.  The WCF solution consists of 3 projects

 - Contracts - The Data and Service Contract of the WCF Service implements.
 - Service - The implementation of the WCF Service Contract.
 - Client - A consumer of the WCF Service.

Below each section refers to the state of a git tag and what the state of the applicaiton is in.

## Demo 1
The initial WCF Service state. All three projects use the old style CSPROJ format and are written to compile to .NET 4.7

## Demo 2
A tool is run to convert the Contract Application and the Client Application to the newer SDK-style CSPROJ template.  This is a pre-requisite to mulit-targeting.  Older ASP.NET Web Projects and WCF Web Hosts cannot convert to SDK-style projects, so the Service project stays untouched.

## Demo 3
The Contracts are converted to multi-target both .NETFramework 4.7 and .NETStandard 2.0.  If the service was written in 4.7.2 it would fully support .NET Standard 2.0 and only a single target would be required.  The client was upgraded to netcore 2.2. For this exmaple I wanted to show that even if for some reason the Production hosting environment coudl not upgrade to 4.7.2  it is still possible to consume from a netcore 2.2 client and build a contract DLL that woudl work for both.

## Demo 4
Some sugar on top, adding in Nuget package for the Contracts DLL.
