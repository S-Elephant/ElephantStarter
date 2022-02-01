# Required NuGets

- Microsoft.EntityFrameworkCore.Design (in startup project)
- Microsoft.EntityFrameworkCore.Tools

# Migrations

[RMB] on the project that (should) contain all migrations (= ElephantStarter.Persistence) and click on "Open in Terminal" (located near the bottom). Then type:

```bash
dotnet ef migrations add Initial --startup-project ..\ElephantStarter --verbose
```

# Update database

[RMB] on the project that (should) contain all migrations (= ElephantStarter.Persistence) and click on "Open in Terminal" (located near the bottom). Then type:

```bash
dotnet ef database update --startup-project ..\ElephantStarter --verbose --connection "Data Source=e:\VS_Projects\ElephantStarter\ElephantStarter\Main.db"
```

