param(
    [string] $action = "build"
)

switch($action){
    "Run" {
        SET-LOCATION .\AddressBook.Web
        dotnet run
    }
    "Build"{
        # Restore Bower Components
        Push-Location .\AddressBook.Web
            "Restore Bower Packages"
            bower install
        Pop-Location

        "Restore Nuget Packages"
        # Restore Packages
        dotnet restore

        "Building Applications"
        # Build Existing Projects
        dotnet build
    }
}