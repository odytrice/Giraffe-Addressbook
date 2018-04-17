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
