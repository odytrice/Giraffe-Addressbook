module AddressBook.Web.Handlers.ContactHandler

open Giraffe
open Giraffe.Razor
open AddressBook.Domain.Models

let getContacts: HttpHandler = 
    fun next context ->
        task {
            let contacts = [
                {
                    ContactId = 0
                    FirstName = "Ody"
                    LastName = "Mbegbu"
                    Email = "odytrice@gmail.com"
                    MobileNo = "08099672925" 
                }
            ]
            return! razorHtmlView "Contacts/List" contacts next context
        }

let route: HttpHandler =
    route "/contacts" >=> 
        choose [
            GET >=> getContacts
        ]