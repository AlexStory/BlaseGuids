namespace Home

open Giraffe.GiraffeViewEngine
open Saturn
open BlaseGuids.Data

module Views = 
    let teamView (team: Models.Team) =
        div [_class "column is-one-third"] [
            div [_class "card"; attr "x-data" "{}"] [
                div [_class "card-header"; attr "style" (sprintf "background-color: %s" team.MainColor)] [
                    div [_class "card-header-title" ] [
                        rawText (sprintf "%s" (if team.Emoji.[0] = '0' then "&#" + team.Emoji.[1..] + ";" else team.Emoji) )
                    ]
                ]

                div [_class "card-body"] [
                    div [_class "card-content"] [
                        a [_href ("/teams/" + team.Id); _class "is-size-4"] [
                            rawText team.Nickname
                        ]

                        div [] [rawText <| string team.Id]
                    ]
                ]

                footer [_class "card-footer"] [
                    button [_class "button card-footer-item"; attr "x-on:click" (sprintf "copyText('%s')" team.Id)] [
                        rawText "Copy to Clipboard"
                    ]
                ]
            ]
        ]

    let index (teams: Models.Team list) = 
        [
            div [_class "columns is-multiline"] [
            for team in teams do
                yield teamView team
            ]
        ]

    let indexView (teams: Models.Team list) =
        App.layout (index teams)
