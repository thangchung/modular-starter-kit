# modular-starter-kits
The starter kits with entire modular approach to help remove boilerplate code in developing

# Migration

```
dotnet ef migrations add InitialId4ConfigDbMigration -c ConfigurationDbContext -o Migrations/ConfigDb
```

```
dotnet ef migrations add InitialId4PersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/PersistedGrantDb
```

```
dotnet ef migrations add InitDb  -c ApplicationDbContext  -o Migrations/AppDb
```
