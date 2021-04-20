namespace Home

open Saturn
open Giraffe.ResponseWriters
open BlaseGuids.Data.Data

module Controller = 
    let indexAction =

        let teams = 
            getTeams 
            |> Async.RunSynchronously
        htmlView (Views.indexView teams)

    let homeView = router {
        get "" indexAction
    }