using AppAny.HotChocolate.FluentValidation;
using BlazorWasmHostedMudBlazorGraphqlTemplate.Domain;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

var logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .WriteTo.Console()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

// Add services to the container.
builder.Services.AddScoped<IValidator<OrderInput>, OrderInputValidator>();
builder.Services.AddDbContext<SampleContext>(opt => opt
    .EnableSensitiveDataLogging(builder.Environment.IsDevelopment())
    .UseInMemoryDatabase("Sample")
    .UseProjectables());
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddAuthorization()
    .AddFluentValidation();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
    {
        opt.Authority = builder.Configuration["Auth0:Authority"];
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = builder.Configuration["Auth0:Audience"],
            ValidIssuer = builder.Configuration["Auth0:Authority"],
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapGraphQL();
app.MapFallbackToFile("index.html");

using var scope = app.Services.CreateScope();
scope.ServiceProvider.GetRequiredService<SampleContext>().Database.EnsureCreated();

app.Run();
