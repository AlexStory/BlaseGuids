namespace BlaseGuids.Data

open FSharp.Control.Tasks
open System.Net.Http
open Ply
open Newtonsoft.Json

module Data =
    let baseUrl = "https://www.blaseball.com/"

    let getTeams =
        task {
            let client = new HttpClient()
            let! res = client.GetAsync(baseUrl + "database/allTeams")
            let! results = res.Content.ReadAsStringAsync()
            return results
                |> JsonConvert.DeserializeObject<Models.Team list>
        } |> Async.AwaitTask 

    let getTeam id =
        task {
            let client = new HttpClient()
            let! res = client.GetAsync(baseUrl + "database/team?id=" + id)
            let! results = res.Content.ReadAsStringAsync()
            return results
                |>JsonConvert.DeserializeObject<Models.Team>
        } |> Async.AwaitTask

    let getPlayers (ids: string list) =
        let combinedIds = String.concat "," ids
        task {
            let client = new HttpClient()
            let! res = client.GetAsync(baseUrl + "database/players?ids=" + combinedIds)
            let! results = res.Content.ReadAsStringAsync()
            return results
                |> JsonConvert.DeserializeObject<Models.Player list>
        } |> Async.AwaitTask