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
           div [_class "box is-radiusless"; attr "x-data" "{}" ; attr "x-init" (sprintf "function() {document.body.style.backgroundColor = '%s'}" team.MainColor)] [
            h2 [_class "title has-text-centered"] [rawText team.FullName]
            p   [_class "subtitle has-text-centered"] [rawText team.Slogan]
           ]
           div [_class "section columns is-multiline"] [
               for player in players do
                yield playerView player 
           ]
        ]