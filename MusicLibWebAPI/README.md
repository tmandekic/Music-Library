# MusicLibWebAPI service

Using ASP.NET core 6, service-repository pattern, Entity Framework code-to-database generation and a standalone SQL Server (running in a separate container). 
API itself is running inside a container. 


## How to run

1. Confirm that Sql Server Docker container is running and confirm its IP (run `ipconfig` in cmd)
2. If needed, update connection string in secrets manager (right click on the project in a solution -> Manage User Secrets)
3. Run the solution


## Service-repository pattern

Entity Framework data access is separated into:
    - repository layer which manages CRUD data access, and
    - service layer that provides business logic functionality
To facilitate testing, each repository class has matching interface: services are initialized with repository interfaces to access data.
That way, testing framework can inject its own repository to use for unit tests.

Resources:
[Matthew Jones: The Repository-Service Pattern with DI and ASP.NET 5.0][1]


## Entity Framework 

Using code-first approach: C# classes are created first, and then used to create database tables.
This is done using migrations (see readme.md in MusicLibDbCtx project for details)
Migration are applied (database is created) during application startup, in Program.cs 
MusicLibDbCtx project holds C# data-classes and is used for EF migrations.

Resources:
[MSDN: Migrations Overview][3]


## Docker implementation for standalone Sql Server database 

Creating Docker container based on a SQL Server Docker image:
- create Docker container (make sure the password is at least 8 characters long, and it contains a combination of any 3 of: lower case letters, upper case letters, numbers and symbols):
<br/>`docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Pass@Word1" -p 21143:1433 -e "MSSQL_PID=Express" --name sql19-23t -v sqlvolume:/var/opt/mssql -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04`
- confirm container has been created: 
`docker container ls -a`
- check new server is accessible:
	- open Sql Server manager and try connecting by using following parameters (might need to check Trust server certificate checkbox):
		<br/>Server: *localhost,21143*
		<br/>Authentication: *SQL Server Authentication*
		<br/>Login: *sa*
		<br/>Password: *Pass@Word1*

- get IP address of the machine on which Sql Server container is running (execute `ipconfig` in cmd)
- update connection string in secrets manager as:
<br/>`Server=[IP address],21143;Database=MusicLib;User ID=sa;Password=Pass@Word1;TrustServerCertificate=true;`

Resources: [Sam Walpole: A guide to runing ASP.NET Core and SQL Server from Docker][2]

## Storing secrets 

**In development, using [secrets manager][4]**

To enable secret storage (run in command line, cd into project directory): 

`dotnet user-secrets init`

`set secret: dotnet user-secrets set "Movies:ServiceApiKey" "12345"`


**In production, [using Azure Key Vault][5]**

*Options for accessing secrets in production:*
- [use X.509 or managed identities for Azure Key Vault access][6]
		- access key vault with x.509 (for non-Azure-hosted applications) or managed identities for Azure-hosted apps
- [using kubernetes to access key-vault][7] 
	- asp.net core app needs to read kubernetes-generated files to get secret values
	- pros: can be used on any cloud as it is Kubernetes access + file read (nothing Azure specific in accessing the Key Vault; but Key Vault is Azure specific)
	- cons: file access might be slow; secrets stores in base64 encoded text in files
- [Azure workload identity][8]
	- [managed identities for Azure resources][9]
	- enables Kubernetes applications to access cloud resources securely with Azure Active Directory
	- "Using Kubernetes primitives, administrators configure identities and bindings to match pods. Then without any code modifications, your containerized applications can leverage any resource in the cloud that depends on AAD as an identity provider."
	- old version: https://github.com/Azure/aad-pod-identity


## Kubernetes

[Using Kubernetes][10]

[1]: https://exceptionnotfound.net/the-repository-service-pattern-with-dependency-injection-and-asp-net-core/
[2]: https://hackernoon.com/a-guide-to-running-aspnet-core-and-sql-server-from-docker-wu4034xc
[3]: https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli
[4]: https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-6.0&tabs=windows
[5]: https://learn.microsoft.com/en-us/azure/key-vault/secrets/quick-create-net?tabs=azure-cli
[6]: https://learn.microsoft.com/en-us/aspnet/core/security/key-vault-configuration?view=aspnetcore-6.0
[7]: https://shailender-choudhary.medium.com/access-secrets-from-azure-key-vault-in-azure-kubernetes-service-e8efffe49427
[8]: https://azure.github.io/azure-workload-identity/docs/introduction.html
[9]: https://learn.microsoft.com/en-us/azure/active-directory/managed-identities-azure-resources/overview
[10]: https://learn.microsoft.com/en-us/azure/aks/tutorial-kubernetes-prepare-app
