# BlazorWasmHostedMudBlazorGraphqlTemplate

A template for an ASP.NET Hosted Blazor WASM project, including:

- [MudBlazor](https://mudblazor.com/) Material Design components
- [HotChocolate](https://chillicream.com/docs/hotchocolate/v13) GraphQL server
- [StrawberryShake](https://chillicream.com/docs/strawberryshake/v13) GraphQL client
- [Serilog](https://serilog.net/) structured logging library

## Usage

1. Clone/download repository and rename the `.sln` and `.csproj` files
1. Update references in `.csproj` to new names
1. Update all namespace/using lines in the code to new names
1. Update app name in `MainLayout.razor`
1. Open in VS2022 or VSCode and run

Optional:

1. Configure `AddDbContext` in `Server/Program.cs` to use SQLite, Postgresql, SQL Server, etc
1. Add [Authentication](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/?view=aspnetcore-7.0) and replace setting LastUpdateBy to use `context.User.Identity.Name`
1. Update `appsettings.json` with [Serilog config](https://github.com/serilog/serilog-settings-configuration) (or update fluently in `Program.cs` if you want it for all environments)

## Domain & GraphQL

1. Add domain entities and then update `Query.cs` and `Mutation.cs`
1. Update GraphQL client-side:
```
cd Client
dotnet graphql update
```
