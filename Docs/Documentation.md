# DOCUMENTATION

You need to install tne next nugets on your project layers:

| Packages                                           | Layer                  |
|----------------------------------------------------|------------------------|
| Microsoft.EntityFrameworkCore                      | .Infrastructure        |
| Microsoft.EntityFrameworkCore.Design               | .Infrastructure - .Api |
| Pomelo.EntityFrameworkCore.MySql                   | .Infrastructure        |
| Microsoft.AspNetCore.Authentication.JwtBearer      | .Api                   |
| Microsoft.AspNetCore.OpenApi                       | .Api                   |
| Swashbuckle.AspNetCore                             | .Api                   |
| BCrypt.Net-Next                                    | .Application           |
| Microsoft.IdentityModel.JsonWebTokens              | .Application           |
| System.IdentityModel.Tokens.Jwt                    | .Application           |
| Microsoft.Extensions.Configuration                 | .Application           |

Usefull comands




| Command | What for |
|----------|-----------|
| `dotnet new sln -n projName` | To create the solution |
| `dotnet new webapi -n projName.Api` | To create the .Api |
| `dotnet new classlib -n projName.Application` | To create .Application |
| `dotnet new classlib -n projName.Domain` | To create .Domain |
| `dotnet new classlib -n projName.Infrastructure` | To create .Infrastructure |
| `dotnet sln add projName.Api projName.Application projName.Domain projName.Infrastructure` | To add projects to the solution |
| `dotnet add projName.Api reference projName.Application` | Adding reference between .Api and .Application |
| `dotnet add projName.Application reference projName.Domain` | Adding reference between .Application and .Domain |
| `dotnet add projName.Infrastructure reference projName.Domain` | Adding reference between .Infrastructure and .Domain |
| `dotnet add projName.Application reference projName.Infrastructure` | Adding reference between .Application and .Infrastructure |
| `dotnet ef migrations add NameMigration --project projName.Infrastructure --startup-project projName.Api` | To create a migration |
| `dotnet ef database update --project projName.Infrastructure --startup-project projName.Api` | To create the database |
| `dotnet new gitignore` | To create a gitignore file |
| `docker compose build` | Builds the Docker images defined in your docker-compose.yml or compose.yaml |


