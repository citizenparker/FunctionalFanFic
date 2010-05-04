module Stories
 
open System

type Story = {User:string; Title:string; Story:string}

let private parseStory (rawValue:string) = 
  match rawValue.Split [|','|] with
    | [| user; title; story |] -> {User=user; Title=title; Story=story}
    | _ -> failwithf "Unrecognized format '%s'" rawValue

let private unParseStory story = 
  String.Format("\n{0},{1},{2}",story.User,story.Title,story.Story)

let find = Data.readAll "stories" parseStory

let findByTitle title = 
  find (fun x -> x.Title = title)
    |> List.head

let save x = Data.store "stories" unParseStory x