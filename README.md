# Introduction 
There is an API endpoint that calculates the amount of time left before user's next birthday. 
In order to use this endpoint user needs to specify 2 query parameters (both parameters are required)
>> dateofbirth - date of user's birth in YYYY-MM-DD format 
>> unit -  in which units you want to see the result (available options: hour/day/week/month)

# Getting Started
1.	Installation process
    >> Install visual studio
2.	Software dependencies
    <PackageReference Include="FluentAssertions" Version="6.11.0" />
    <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.6.0" />
    <PackageReference Include="NUnit" Version="3.13.3" />
    <PackageReference Include="NUnit3TestAdapter" Version="4.4.2" />
    <PackageReference Include="NUnit.Analyzers" Version="3.6.1">
    <PackageReference Include="coverlet.collector" Version="3.2.0">
    <PackageReference Include="RestSharp" Version="110.2.0" />
    
# Build and Test
1. Clone the project repository in visual studio 
      HTTPS - https://github.com/ravisalunkhe/TestProject.git
2. Build the project 
3. Open the Test Explorer 
4. Run the tests
