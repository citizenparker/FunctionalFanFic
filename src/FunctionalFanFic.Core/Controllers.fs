module Controllers
  
  open Bistro.FS.Definitions
  open Bistro.FS.Inference
    
  open Bistro.Controllers.Descriptor
  open Bistro.Controllers.Descriptor.Data

  open Utils


  [<Bind("")>]
  [<RenderWith("Views/home.django")>]
  [<ReflectedDefinition>]
  let home (ctx : ictx) = 
    Stories.find all |> named "stories"

  [<Bind("get /new")>]
  [<RenderWith("Views/new.django")>]
  [<ReflectedDefinition>]
  let newStory (ctx: ictx) = ()

  [<Bind("post /new")>]
  [<ReflectedDefinition>]
  let createStory (ctx: ictx) (user:string form) (title:string form) (body:string form) = 
    Stories.save (user.Value,title.Value,body.Value)
    ctx.Transfer("/");
