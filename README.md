# Multi-targeting Demo
The demo uses 4 @tags to show different states of an application.  For this example the scenario is that an existing WCF service and client writting in .NETFramework version 4.7 exist, and we want to move the client to netcore 2.2 to run on linux.

The WCF Scenario is something I think might be common.  I want to show that WCF contracts can be converted to be used by both .NETFramework and netcore, and that applications can be converted to netcore from .NETFramework in some cases.

Later I'll show going the other direction and having a WCF service consume a .NET Core EF 2.2 DLL using a 5th @tag

Below each section refers to the state of a git @tag and what the state of the application is in.

For each demo you can compile and launch the web service and then launch the console app to see it make 2 calls to the WCF service.

## Demo 1
The initial WCF Service state. All three projects use the old style CSPROJ format and are written to compile to .NET 4.7

#### The WCF solution consists of 3 projects:

 - Contracts - The Data and Service Contract of the WCF Service implements.
 - Service - The implementation of the WCF Service Contract.
 - Client - A consumer of the WCF Service.


#### Project targets
- Contracts - net47
- Service - net47
- Client - net47

## Demo 2
A tool is run to convert the Contract Application and the Client Application to the newer SDK-style CSPROJ template.  This is a pre-requisite to mulit-targeting.  Older ASP.NET Web Projects and WCF Web Hosts cannot convert to SDK-style projects, so the Service project stays untouched.

#### Project targets
- Contracts - net47
- Service - net47
- Client - net47

## Demo 3
The Contracts are converted to multi-target both .NETFramework 4.7 and .NETStandard 2.0.  If the service was written in 4.7.2 it would fully support .NET Standard 2.0 and only a single target would be required.  The client was upgraded to netcore 2.2. For this exmaple I wanted to show that even if for some reason the Production hosting environment coudl not upgrade to 4.7.2  it is still possible to consume from a netcore 2.2 client and build a contract DLL that woudl work for both.

#### Project targets
- Contracts - both net47 and netstandard2.0
- Service - net47
- Client - netcoreapp2.2

## Demo 4
Some sugar on top, adding in Nuget package for the Contracts DLL.  This is cool because the nuget package will have both .NETFramework 4.7 and the NETStandard 2.0 dlls an pdbs in it, and will be smart enough to give the right one to a cosumer.  The nuget package will only build if the configuration is release.

    dotnet build -c release

## Demo 5
Demo 5 changes the scenario.  The new Scenario is that the WCF service used to use an Entity Framework 6 Data DLL and we want to show that the data DLL can be upgraded to be a multi-targeted DLL that targets netcore 2.2 and NETStandard 2.0.
In order to make this easy will will assume the latest version of .NET Framework has been applied to the WCF service, .NET Framework 4.7.2, which is compliant with .NETStandard 2.0.  So the Contract DLL now only targets .NETStandard 2.0.  A new project was added that multi-targets to take advantage of Entity Framework Core 2.2 and be used by a .NET Framework WCF Service.

#### Solution now has 4 projects:
- Contracts - The Data and Service Contract of the WCF Service implements.
- Data - EF Core 2.2 SQL Server Database DLL.
- Service - The implementation of the WCF Service Contract which uses the Data.
- Client - A consumer of the WCF Service.

#### Project targets
- Contracts - netstandard2.0
- Data - Both netcoreapp2.2 and netstandard2.0
- Service - net472
- Client - netcoreapp2.2

To run demo 5 you will have to have SQL Server installed locally or you can adjust the file [DemoDbContextDesignTimeFactory](https://github.com/unscrum/MultitargetingDemo/blob/Demo5/src/MultitargetingDemo.Data/DemoDbContextDesignTimeFactory.cs) to have your connection string.  Then run this command from the project root to create the database.  It will be named Demo with a single Table called Note with one row in it.

    cd src/MultitargetingDemo.Data
    dotnet ef database update
