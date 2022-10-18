# MusicLibrary

This is a sample project that uses:
- Entity framework migrations to generate database from code (code-first approach)
- Service/repository pattern; each entity has its own repository and service. 
- REST services supporting all http verbs required for CRUD operations
- XUnit unit tests for the services
- Web API and SQL database running in container. 
<br/>

Projects in a solution: 

- **Migrations** MusicLibDbCtx		
- **Framework** MusicLibFramework
	- repository: data repository
	- service: business logic
- **WebAPI** controllers providing http REST endpoints for API access
- **XUnit**: unit tests
