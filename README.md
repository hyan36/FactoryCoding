# FactoryCoding
This is a dotnet core application which trying to resolve the automated factory code challenge. 

## Environment Requirement
To be able to run the code you need to have either
* dotnet core 3.1 installed
* docker installed

## Building & Running solution via dotnet core cli
```
cd src\FactoryCodingChallenge
dotnet restore
dotnet run . -b recipe_elec_engine -q 1
```

Sample Output
```
PS C:\Projects\Coles\FactoryCoding\src\FactoryCodingChallenge> dotnet run . -b recipe_elec_engine -q 1
Inventory loaded: 5 unique components
Recipes loaded: 7 total
Inventory:
* iron_plate: 40
* iron_gear: 5
* copper_plate: 20
* copper_cable: 10
* lubricant: 100

         > building recipe 'recipe_circuit' in 1.5s (11.5s total)
                 > building recipe 'recipe_steel' in 16s (37.5s total)
                 > building recipe 'recipe_pipe' in 0.5s (38s total)
         > building recipe 'recipe_engine_block' in 10s (38s total)
 > building recipe 'recipe_elec_engine' in 10s (38s total)
Built Electric Engine in 38s

Inventory:
* iron_plate: 31
* iron_gear: 4
* copper_plate: 20
* copper_cable: 4
* lubricant: 85
* electric_circuit: 0
* steel_plate: 0
* pipe: 0
* engine_block: 0
* electric_engine: 1
```

## Building & Running solution via docker
We can also use docker to run the application, if you don't want to install .net core on your local environment.

### Building Docker Image
If you've previously build the solution via command line on windows, we need to remove all content under /obj & /bin folder before building docker image. 

```
cd src\FactoryCodingChallenge
docker build -t coles/autofactory .
```

Output
```
PS C:\Projects\Coles\FactoryCoding\src\FactoryCodingChallenge> docker build -t coles/autofactory .
Sending build context to Docker daemon  33.79kB
Step 1/10 : FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
 ---> ec3ca8a1472c
Step 2/10 : WORKDIR /app
 ---> Using cache
 ---> 5a573b143e5f
Step 3/10 : COPY *.csproj ./
 ---> Using cache
 ---> c499fc6bd312
Step 4/10 : RUN dotnet restore
 ---> Using cache
 ---> 3f0d8df2d1a2
Step 5/10 : COPY . ./
 ---> 9e2b2da2d127
Step 6/10 : RUN dotnet publish -c Release -o out
 ---> Running in ff421fd519bb
Microsoft (R) Build Engine version 16.7.2+b60ddb6f4 for .NET
Copyright (C) Microsoft Corporation. All rights reserved.

  Determining projects to restore...
  All projects are up-to-date for restore.
  FactoryCodingChallenge -> /app/bin/Release/netcoreapp3.1/FactoryCodingChallenge.dll
  FactoryCodingChallenge -> /app/out/
Removing intermediate container ff421fd519bb
 ---> f84ed74b7066
Step 7/10 : FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
 ---> d329c7e66ea8
Step 8/10 : WORKDIR /app
 ---> Using cache
 ---> c64e3e61f2b9
Step 9/10 : COPY --from=build-env /app/out .
 ---> Using cache
 ---> 0632aa33a401
Step 10/10 : ENTRYPOINT ["dotnet", "FactoryCodingChallenge.dll"]
 ---> Using cache
 ---> 315754dae1ad
Successfully built 315754dae1ad
Successfully tagged coles/autofactory:latest
SECURITY WARNING: You are building a Docker image from Windows against a non-Windows Docker host. All files and directories added to build context will have '-rwxr-xr-x' permissions. It is recommended to double check and reset permissions for sensitive files and directories.
```

### Running AutoFactory in Container
```
docker run coles/autofactory -b recipe_elec_engine -q 3
```
Output
```
PS C:\Projects\Coles\FactoryCoding\src\FactoryCodingChallenge> docker run coles/autofactory -b recipe_elec_engine -q 3
Inventory loaded: 5 unique components
Recipes loaded: 7 total
Inventory:
* iron_plate: 40
* iron_gear: 5
* copper_plate: 20
* copper_cable: 10
* lubricant: 100

         > building recipe 'recipe_circuit' in 1.5s (11.5s total)
                 > building recipe 'recipe_steel' in 16s (37.5s total)
                 > building recipe 'recipe_pipe' in 0.5s (38s total)
         > building recipe 'recipe_engine_block' in 10s (38s total)
 > building recipe 'recipe_elec_engine' in 10s (38s total)
Built Electric Engine in 38s

                 > building recipe 'recipe_cables' in 0.5s (12s total)
         > building recipe 'recipe_circuit' in 1.5s (12s total)
                 > building recipe 'recipe_steel' in 16s (38s total)
                 > building recipe 'recipe_pipe' in 0.5s (38.5s total)
         > building recipe 'recipe_engine_block' in 10s (38.5s total)
 > building recipe 'recipe_elec_engine' in 10s (38.5s total)
Built Electric Engine in 38.5s

         > building recipe 'recipe_circuit' in 1.5s (11.5s total)
                 > building recipe 'recipe_steel' in 16s (37.5s total)
                 > building recipe 'recipe_pipe' in 0.5s (38s total)
         > building recipe 'recipe_engine_block' in 10s (38s total)
 > building recipe 'recipe_elec_engine' in 10s (38s total)
Built Electric Engine in 38s

Inventory:
* iron_plate: 13
* iron_gear: 2
* copper_plate: 17
* copper_cable: 1
* lubricant: 55
* electric_circuit: 0
* steel_plate: 0
* pipe: 0
* engine_block: 0
* electric_engine: 3
```

## To run the unit test
```
cd src\FactoryCodingChallenge.Test
dotnet restore
dotnet test .
```

Output
```
PS C:\Projects\Coles\FactoryCoding\src\FactoryCodingChallenge.Test> dotnet test .
Test run for C:\Projects\Coles\FactoryCoding\src\FactoryCodingChallenge.Test\bin\Debug\netcoreapp3.1\FactoryCodingChallenge.Test.dll(.NETCoreApp,Version=v3.1)
Microsoft (R) Test Execution Command Line Tool Version 16.3.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

A total of 1 test files matched the specified pattern.


Test Run Successful.
Total tests: 10
     Passed: 10
 Total time: 1.1474 Seconds
```
