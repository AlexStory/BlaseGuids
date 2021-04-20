module App

open Giraffe.GiraffeViewEngine

let layout (content: XmlNode list) =
    html [_class "has-navbar-fixed-top"] [
        head [] [
            meta [_charset "utf-8"]
            meta [_name "viewport"; _content "width=device-width, initial-scale=1" ]
            title [] [encodedText "BlaseGuids"]
            link [_rel "stylesheet"; _href "https://cdnjs.cloudflare.com/ajax/libs/bulma/0.9.2/css/bulma.min.css"]
            link [_rel "stylesheet"; _href "https://cdn.jsdelivr.net/npm/@fortawesome/fontawesome-free@5.15.3/css/fontawesome.min.css" ; _crossorigin "anonymous"]
            link [_rel "stylesheet"; _href "/app.css" ]
            script [_type "module"; _src "https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine.min.js"] []
            script [attr "nomodule" "" ; _src "https://cdn.jsdelivr.net/gh/alpinejs/alpine@v2.x.x/dist/alpine-ie11.min.js"; attr "defer" ""] []

        ]
        body [] [
            yield nav [ _class "navbar is-fixed-top has-shadow"; attr "x-data" "{open: false}"] [
                div [_class "navbar-brand"] [
                    a [_class "navbar-item is-size-4"; _href "/"] [rawText "BlaseGuids"]
                    div [_class "navbar-burger burger"; attr "@click" "open=true"; attr ":class" "{ 'active': 'open'}"; attr "@click.away" "open = false"] [
                        span [] []
                        span [] []
                        span [] []
                    ]
                ]
            ]
            yield div [_class "container py-2"] [
                yield! content
            ]
            yield script [_src "/app.js"] []
        ]
    ]
