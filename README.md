# CarParkAvailability
CarParkAvailability API with ASP.NET Core

1. Clone/Download the repo
2. Open the sln file in root directory with Visual Studio (preferably **Visual Studio 2019**)
3. Change the db connection string according to your db setting (i.e., ConnectionStrings > DbConn) in **appsetting.json** file
4. Build the solution in Visual Studio to download dependencies
5. Create a new database in **SQL Express** (must be the same name as the db name in connection string)
6. Run command `Update-Database` in Visual Studio 2019's Powershell to migrate tables
7. Execute/Debug the solution in Visual Studio (IIS server as of now)
