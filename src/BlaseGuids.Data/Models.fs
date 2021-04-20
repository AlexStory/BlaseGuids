namespace BlaseGuids.Data

module Models =
    type Team = { 
        Id: string
        Bench: string list
        Bullpen: string list
        Emoji: string
        FullName: string 
        Lineup: string list
        MainColor: string
        Nickname: string 
        Rotation: string list
        SecondaryColor: string
        Slogan: string
    }

    type Player = {
        Id: string
        Name: string
    }