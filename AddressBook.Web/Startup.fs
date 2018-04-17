module AddressBook.Web.Startup

open Microsoft.AspNetCore.Builder
open Microsoft.AspNetCore.Hosting
open Microsoft.Extensions.DependencyInjection
open Giraffe
open Giraffe.Razor
open System.IO
open System
open Microsoft.Extensions.Logging
open AddressBook.Web.Handlers


let myApp = 
    choose [
        HomeHandler.route
        ContactHandler.route
    ]


let ErrorHandler (ex: Exception) (logger: ILogger) =
    logger.LogError(EventId(), ex, "An unhandled exception has occurred while executing the request.")
    clearResponse >=> setStatusCode 500 >=> text ex.Message


let ConfigureServices(services: IServiceCollection) = 
    let provider = services.BuildServiceProvider()
    let env = provider.GetService<IHostingEnvironment>()
    let viewsFolderPath = Path.Combine(env.ContentRootPath, "Views")

    services
        .AddGiraffe()
        .AddRazorEngine(viewsFolderPath) |> ignore

let Configure(app: IApplicationBuilder) =

    let services = app.ApplicationServices

    let env = services.GetRequiredService<IHostingEnvironment>()
    
    if env.IsDevelopment() then 
        app.UseDeveloperExceptionPage()
    else
        app.UseGiraffeErrorHandler(ErrorHandler)
    |> ignore

    app.UseStaticFiles().UseGiraffe(myApp)