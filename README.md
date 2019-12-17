# Environment .NET Core

**.NET Core** can offer many resources for developers and one of them is the possibility to set enviroments to work in. Imagine  you have 3 kinds of environments (Production, Development and QA) and you need to set different connection strings for each of them. How to configure this stack? The first thought would be to change the file with the connection before each deploy. It works, but over the course of time it becomes hard and failures can happen. But there is a simple way to do it with less risks for your application: through using profiles configuration.

## Step One - LaunchSettings.json

The file launchSettings.json is responsible for defining the available profiles in your application. There is a common profile already configured (Development), so we need to insert two more to support our stack, as follow:

    
    {
      "$schema": "http://json.schemastore.org/launchsettings.json",
      "iisSettings": {
        "windowsAuthentication": false,
        "anonymousAuthentication": true,
        "iisExpress": {
          "applicationUrl": "http://localhost:53696",
          "sslPort": 44315
        }
      },
      "profiles": {
        "Development": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          }
        },
        "QA": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "QA"
          }
        },
        "Production": {
          "commandName": "IISExpress",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Production"
          }
        },
        "EnvironmentNet": {
          "commandName": "Project",
          "launchBrowser": true,
          "launchUrl": "api/values",
          "applicationUrl": "https://localhost:5001;http://localhost:5000",
          "environmentVariables": {
            "ASPNETCORE_ENVIRONMENT": "Development"
          }
        }
      }
    }
	

## Step Two - AppSettings.Environmet.json

After defining all the profiles, we can create the appsettings.json for each of them. They must have the same name of ASPNETCORE_ENVIRONMENT for their environment.

![AppSettings](https://i.ibb.co/qnWQrcJ/Sem-t-tulo.png "AppSettings")

Now it is possible to define the individual configuration for each environment, as a connection string.

## Step Three - Set the environment file to read

At this point, we just need to change our Startup.cs to read the appsettings depeding on the profile. 

![](https://i.ibb.co/26NpBTZ/Sem-t-tulo.png)

## Step Four - Build

After all these steps, the application is ready to run with many environments.

![](https://i.ibb.co/dgwhVby/Sem-t-tulo.png)
