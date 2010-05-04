module Topics

  open System
  open Utils

  //Just a passthrough parser - we don't need to do anything here
  let private passThrough rawValue = rawValue

  let templates = Data.readAll "templates" passThrough all
  let nouns = Data.readAll "nouns" passThrough all

  let rec private asTuples = function
    | [] -> []
    | [x] -> [(x, x)]
    | first :: second :: tail -> (first, second) :: asTuples tail

  let generateTopics n = 
    let rand = new System.Random()

    let nounPairings = 
      nouns
        |> List.sortBy (fun x -> rand.Next(templates.Length))
        |> asTuples
        |> Seq.take n

    templates
      |> List.sortBy (fun x -> rand.Next(templates.Length))
      |> Seq.take n
      |> Seq.map2 (fun (noun1,noun2) template -> String.Format(template, noun1, noun2)) nounPairings 