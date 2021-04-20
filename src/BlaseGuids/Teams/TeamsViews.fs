namespace Teams

open Giraffe.GiraffeViewEngine
open Saturn
open BlaseGuids.Data

module Views =
    let playerView (player: Models.Player) =
        div [_class "column is-one-third"] [
            div [_class "card"] [
                div [_class "card-header"] [
                    div [_class "card-header-title"] [
                        rawText player.Name
                    ]
                ]

                div [_class "card-body"] [
                    div [_class "card-content"] [
                        rawText player.Id
                    ]
                ]

                footer [_class "card-footer"; attr "x-data" "{}"] [
                    button [_class "card-footer-item button"; attr "x-on:click" (sprintf "copyText('%s')" player.Id)] [
                        rawText "Copy To Clipboard"
                    ]
                ]
            ]
        ]

    let showView (team: Models.Team) (players: Models.Player list) =
       App.layout [
           h2 [_class "is-size-2 has-text-centered"] [rawText team.FullName]
           div [_class "section columns is-multiline"] [
               for player in players do
                yield playerView player 
           ]
        ]