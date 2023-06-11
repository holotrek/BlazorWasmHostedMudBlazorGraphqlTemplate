# BlazorWasmHostedMudBlazorGraphqlTemplate

A template for an ASP.NET Hosted Blazor WASM project, including:

- [MudBlazor](https://mudblazor.com/) Material Design components
- [HotChocolate](https://chillicream.com/docs/hotchocolate/v13) GraphQL server
- [StrawberryShake](https://chillicream.com/docs/strawberryshake/v13) GraphQL client
- [Serilog](https://serilog.net/) structured logging library
- Authentication with [Auth0](https://auth0.com/)

## Usage

1. Clone/download repository and rename the `.sln` and `.csproj` files
1. Update references in `.csproj` to new names
1. Update all namespace/using lines in the code to new names
1. Update app name in `MainLayout.razor`
1. Enable Auth0
    1. Create account and sign in to https://manage.auth0.com/
    1. In navigation go to `Applications -> Applications`
    1. Click Create Application
    1. Enter a name for your application and select "Single Page Web Applications". Click Create.
    1. Click "Settings"
    1. Under Allowed Callback URLs, enter https://localhost:7080/authentication/login-callback
    1. Under Allowed Logout URLs, enter https://localhost:7080
    1. Click Save Changes
    1. Scroll back to the top and copy and save off the values for "Domain" and "Client ID"
    1. In navigation go to `Applications -> APIs`
    1. Click Create API
    1. Enter a name and any URL (does not need to be a real URL). Click Create.
    1. Edit the Client [appsettings.json](./Client/wwwroot/appsettings.json) and replace the placeholders with the copied values.
    1. Edit the Server [appsettings.Development.json](./Server/appsettings.json) and replace the placeholders.
    1. Authority is the Domain value with `https://` prepended. Audience is the URL created in the previous step.
1. Open in VS2022 or VSCode and run

Optional:

1. Configure `AddDbContext` in `Server/Program.cs` to use SQLite, Postgresql, SQL Server, etc
1. Update `appsettings.json` with [Serilog config](https://github.com/serilog/serilog-settings-configuration) (or update fluently in `Program.cs` if you want it for all environments)

## Domain & GraphQL

1. Add domain entities and then update `Query.cs` and `Mutation.cs`
1. Update GraphQL client-side:
```
cd Client
dotnet graphql update
```
