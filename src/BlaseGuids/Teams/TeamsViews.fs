namespace Teams

open Giraffe.GiraffeViewEngine
open Saturn
open BlaseGuids.Data

module Views =
    let playersView (players: Models.Player list) =
        div [_class "columns is-multiline"] [
            for player in players do
                div [_class "column is-one-third-widescreen is-half-tablet"] [
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

                        footer [_class "card-footer"] [
                                button [_class "card-footer-item button"; attr "x-data" "{}"; attr "@click" (sprintf "copyText(%s)" player.Id)] [
                                rawText "Copy to Clipboard"
                            ]
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

            div [_class "section has-background-white"; attr "x-data" "{active: 'lineup'}"] [
                div [_class "tabs is-medium is-fullwidth"] [
                    ul [] [
                        li [attr ":class" "{ 'is-active': active === 'lineup' }"] [
                            a [attr "@click" "active = 'lineup'"] [rawText "Lineup"]
                        ]
                        li [attr ":class" "{ 'is-active': active === 'rotation' }"] [
                            a [attr "@click" "active = 'rotation'"] [rawText "Rotation"]
                        ]
                        li [attr ":class" "{ 'is-active': active === 'bench' }"] [
                            a [attr "@click" "active = 'bench'"] [rawText "Bench"]
                        ]
                        li [attr ":class" "{'is-active': active === 'bullpen' }"] [
                            a [attr "@click" "active = 'bullpen'"] [rawText "Bullpen"]
                        ]
                    ]
                ]

                div [attr "x-show" "active === 'lineup'"] [
                    playersView (List.filter (fun x -> List.contains x.Id team.Lineup) players)
                ]

                div [attr "x-show" "active === 'rotation'"] [
                    playersView (List.filter (fun x -> List.contains x.Id team.Rotation) players)
                ]

                div [attr "x-show" "active === 'bench'"] [
                    playersView (List.filter (fun x -> List.contains x.Id team.Bench) players)
                ]

                div [attr "x-show" "active === 'bullpen'"] [
                    playersView (List.filter (fun x -> List.contains x.Id team.Bullpen) players)
                ]

            ]
        ]