# The Shop - coding challenge

The solution consists of two web APIs: 
- Shop.WebApi – for displaying and buying articles 
- Vendor.WebApi – acts like third party provider mock

## Before start

Before start plese install .NET 7. The solution is using Visual Studio 2022 Community Edition.

## Starting the project

Start project by running the folowing commands:
 1. Clone the repository
    
    ````
    git clone https://github.com/lazarkrstic/coding-challenge.git
    cd coding-challenge\TheShop
    ````
2. Start Solution

    ### Option 1 - using Visual Studio 2022

    Start solution by starting multiple projects -  `Shop.WebApi` and `Vendor.WebApi`
    
    ### Option 2 - using .NET cli

    ````
    dotnet build
    ````
    Start `Shop.WebApi`:
    ````
    dotnet run --project .\Shop.WebApi\Shop.WebApi.csproj
    ````
    Start `Vendor.WebApi`:
    ````
    dotnet run --project .\Vendor.WebApi\Vendor.WebApi.csproj
    ````


## Run tests

Run tests by running the folowing command:
````
dotnet test
````

## Publis apps

Publis apps by running the folowing command:
````
dotnet publish -c Release
````

