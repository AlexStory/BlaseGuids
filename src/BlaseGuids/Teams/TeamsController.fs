namespace Teams

open Saturn
open Giraffe.ResponseWriters
open BlaseGuids.Data.Data

module Controller =
    let showAction id =
        let team =
            id
            |> getTeam 
            |> Async.RunSynchronously

        let playerIds = List.concat [ team.Lineup; team.Rotation; team.Bench; team.Bullpen ]
        let players = 
            playerIds
            |> getPlayers
            |> Async.RunSynchronously
        htmlView (Views.showView team players)

    let teamView = router {
        getf "/%s" showAction
    }

