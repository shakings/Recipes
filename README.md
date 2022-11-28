# Recipes

I've build an web application to manage a list of recipes using VueJs & Web-Api.
The Recipes portal have been design on the microsoft .NET Core Platfrom. The web application consist of GUI, API, MSSQL 
Visual Studio 2022 & Visual Studio Code was used to build the application.

# Overview Diagram

![image](https://user-images.githubusercontent.com/4200022/204269324-25716f06-e570-41c0-be92-99f34ee401cf.png)

## Get Started
These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

1.  Clone https://github.com/shakings/Recipes.git 
    (Use Git or checkout with SVN using the web URL.)
2.  The .bak file for the MSSQL database can be found in the root directory (filename: RecipesDb.bak) 
    if you require any assistance (https://support.solarwinds.com/SuccessCenter/s/article/Back-up-and-restore-SQL-database-instance-using-a-BAK-file?language=en_US)

### Configure API ConnetionStrings
The Recipes Web-Api will be the project where the connectionString will be required to be configured.

The appsettings.json file can be found in the project of the API.

1.  Will be require to change your server name in the connectionString to ensure that API will connect to your database server or your localhost(development environment).
2.  After the database has been restored you also need to ensure that you change the databaseName if it's not the same in the connectionString.

"ConnectionStrings": {
    "ConnectionString": "Server=ServerName;Database=DatabaseName;Trusted_Connection=True;MultipleActiveResultSets=true;"
  }


# Database Diagram

![image](https://user-images.githubusercontent.com/4200022/204296813-36c733d4-3357-443d-b57a-d93a5c304eb9.png)
