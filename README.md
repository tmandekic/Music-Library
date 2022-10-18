# MusicLib

This is a sample project which uses:
- entity framework migrations to generate database from code 
	- [MSDN: Migrations Overview][3]
- service/repository pattern; each entity has its own repository and service. 
	- [Matthew Jones: The Repository-Service Pattern with DI and ASP.NET 5.0][1]
- REST services supporting all http verbs required for CRUD operations
- XUnit unit tests for the services
- Web API and SQL database running in container. 
	- [Sam Walpole: A guide to runing ASP.NET Core and SQL Server from Docker][2]
<br/>

Outstanding tasks: 

- **migrations**
	- [ ] change data types (id from bigint to int; name from nvarchar(max) to nvarchar(255))
	- [ ] set db default for Created datetime 
	- [ ] set id as db identity(1,1)
	- [ ] change column names to have underscores between words
	- [ ] change table names to singular (from plural)			
- **framework** (service/repository pattern)
	- repository:    
		- [ ] implement paging
	- service     
- **webAPI** (controllers providing http REST endpoints for API access)
	- [ ] update for paging
- **XUnit**: 
	- [ ] unit tests
	
[1]: https://exceptionnotfound.net/the-repository-service-pattern-with-dependency-injection-and-asp-net-core/
[2]: https://hackernoon.com/a-guide-to-running-aspnet-core-and-sql-server-from-docker-wu4034xc
[3]: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
