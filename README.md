# Introduction 
This project is to validate an API endpoint that calculates the amount of time left before user's next birthday using the 
C# with RestSharp open-source HTTP Client library.
In order to use this endpoint user needs to specify 2 query parameters (both parameters are required)
- dateofbirth - date of user's birth in YYYY-MM-DD format 
- unit -  in which units you want to see the result (available options: hour/day/week/month)

# Getting Started
1.	Installation process
    - Install Visual Studio    
2. Clone the project repository in visual studio 
      HTTPS - https://github.com/ravisalunkhe/TestProject.git
    
# Build and Test
1. Build the project in Visual Studio
2. Open the Test Explorer
3. Select & Run the tests

#	Software/Library dependencies
    PackageReference Include="FluentAssertions" Version="6.11.0"
    PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.6.0"
    PackageReference Include="NUnit" Version="3.13.3"
    PackageReference Include="NUnit3TestAdapter" Version="4.4.2"
    PackageReference Include="NUnit.Analyzers" Version="3.6.1"
    PackageReference Include="coverlet.collector" Version="3.2.0"
    PackageReference Include="RestSharp" Version="110.2.0"
