# modular-starter-kits (a.k.a MSK)

The starter kits with entire modular approach to help remove boilerplate code in developing

# Modular Architecture

- Module Dependency

﻿<p align="center">
  <img align="center" class="image" src="https://github.com/thangchung/modular-starter-kits/blob/master/assets/module-dependency.png">  
</p>

# Routers

- http://localhost:8888/ui-swagger
- http://localhost:8888/ui/graphiql
- http://localhost:8888/ui/playground

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

# Contributing

1. Fork it!
2. Create your feature branch: `git checkout -b my-new-feature`
3. Commit your changes: `git commit -am 'Add some feature'`
4. Push to the branch: `git push origin my-new-feature`
5. Submit a pull request :p

# Licence

Code released under [the MIT license](https://github.com/thangchung/modular-starter-kits/blob/master/LICENSE).
