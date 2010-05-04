module Stories
 
open System

let private parseStory (rawValue:string) = 
  match rawValue.Split [|','|] with
    | [| user; title; text |] -> (user, title, text)
    | _ -> failwithf "Unrecognized format '%s'" rawValue

let private unParseStory story = 
  let user,title,text = story
  String.Format("\n{0},{1},{2}",user,title,text)

let find = Data.readAll "stories" parseStory

let save x = Data.store "stories" unParseStory x