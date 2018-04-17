module AddressBook.Web.Handlers.HomeHandler

open Giraffe

let index: HttpHandler =
    //Initialization Code
    fun next context ->
        task {
            //Happens in Every Request
            return! redirectTo false "/contacts" next context
        }


let route: HttpHandler = 
    choose [
        route "/" >=> index
    ]