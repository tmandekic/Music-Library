# To create migrations db

In Package Manager Console:
	- select this (MusicLibDbCtx) project in Default project dropdown
	- execute:
		Add-Migration {migrationName} -OutputDir Migrations\
		{if required, manually update migration c# script}
		Update-Database
		{open db in db editor and confirm changes were successfully/correctly applied}
		

Resources:
https://learn.microsoft.com/en-us/ef/core/cli/powershell
https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/managing?tabs=vs#customize-migration-code

Errors encountered during coding:
1) Add-Migration command: 
	Error: No DbContext was found in assembly 'MusicLibSample'. Ensure that you're using the correct assembly and that the type is neither abstract nor generic.	
	
	Solution: make sure Default project is correctly selected


