# modular-starter-kits (a.k.a MSK)

The starter kits with entire modular approach to help remove boilerplate code in developing

# Modular Architecture

- Module Dependency

﻿<p align="center">
  <img align="center" class="image" src="https://github.com/thangchung/modular-starter-kits/blob/master/assets/module-dependency.png">  
</p>

# Migration

```
dotnet ef migrations add InitialConfigDbMigration -c ConfigurationDbContext -o Migrations/ConfigDb
```

```
dotnet ef migrations add InitialPersistedGrantDbMigration -c PersistedGrantDbContext -o Migrations/PersistedGrantDb
```

```
dotnet ef migrations add InitDb  -c ApplicationDbContext  -o Migrations/AppDb
```
